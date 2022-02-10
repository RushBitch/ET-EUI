using System;
using System.Collections.Generic;
using System.IO;
using MongoDB.Bson.Serialization.Attributes;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// 用来对比web端的资源，比较md5，对比下载资源
    /// </summary>
    public class BundleDownloaderComponent: MonoBehaviour
    {
        private VersionConfig remoteVersionConfig;

        public Queue<string> bundles;

        public long TotalSize;

        public HashSet<string> downloadedBundles;

        public string downloadingBundle;

        public UnityWebRequestAsync webRequest;

        private string progressTip = null;

        public void OnDestroy()
        {
            this.remoteVersionConfig = null;
            this.TotalSize = 0;
            this.bundles = null;
            this.downloadedBundles = null;
            this.downloadingBundle = null;
            this.webRequest?.Dispose();
        }

        public void Update()
        {
            this.webRequest?.Update();
        }

        public async ETTask StartAsync()
        {
            this.progressTip = "校验文件...";
            this.bundles = new Queue<string>();
            this.downloadedBundles = new HashSet<string>();
            this.downloadingBundle = "";
            // 获取远程的Version.txt
            string versionUrl = "";
            try
            {
                this.webRequest = new UnityWebRequestAsync();
                versionUrl = BundleHelper.GetUrl() + "StreamingAssets/" + "Version.txt";
                //Log.Debug(versionUrl);
                await this.webRequest.DownloadAsync(versionUrl);
                remoteVersionConfig = JsonHelper.FromJson<VersionConfig>(this.webRequest.Request.downloadHandler.text);
                //Log.Debug(JsonHelper.ToJson(remoteVersionConfig));
                this.webRequest.Dispose();
                this.webRequest = null;
            }
            catch (Exception e)
            {
                throw new Exception($"url: {versionUrl}", e);
            }

            // 获取streaming目录的Version.txt
            VersionConfig streamingVersionConfig;
            string versionPath = Path.Combine(PathHelper.AppResPath4Web, "Version.txt");
            this.webRequest = new UnityWebRequestAsync();
            await this.webRequest.DownloadAsync(versionPath);
            streamingVersionConfig = JsonHelper.FromJson<VersionConfig>(this.webRequest.Request.downloadHandler.text);
            this.webRequest.Dispose();
            this.webRequest = null;
            // 删掉远程不存在的文件
            DirectoryInfo directoryInfo = new DirectoryInfo(PathHelper.AppHotfixResPath);
            if (directoryInfo.Exists)
            {
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                foreach (FileInfo fileInfo in fileInfos)
                {
                    if (remoteVersionConfig.FileInfoDict.ContainsKey(fileInfo.Name))
                    {
                        continue;
                    }

                    if (fileInfo.Name == "Version.txt")
                    {
                        continue;
                    }

                    fileInfo.Delete();
                }
            }
            else
            {
                directoryInfo.Create();
            }

            // 对比MD5
            foreach (FileVersionInfo fileVersionInfo in remoteVersionConfig.FileInfoDict.Values)
            {
                // 对比md5
                string localFileMD5 = BundleHelper.GetBundleMD5(streamingVersionConfig, fileVersionInfo.File);
                if (fileVersionInfo.MD5 == localFileMD5)
                {
                    continue;
                }

                Debug.Log($"名字：{fileVersionInfo.File},大小{fileVersionInfo.Size}" );
                this.bundles.Enqueue(fileVersionInfo.File);
                this.TotalSize += fileVersionInfo.Size;
            }
        }

        public float Progress
        {
            get
            {
                if (this.TotalSize == 0)
                {
                    return 0;
                }

                Debug.Log($"已下载：{Math.Floor(this.AlreadyDownloadBytes / 1024f)}，全部：{Math.Floor(this.TotalSize / 1024f)}");
                return this.AlreadyDownloadBytes / this.TotalSize;
            }
        }

        public string ProgressTip
        {
            get
            {
                return this.progressTip;
            }
        }

        public float AlreadyDownloadBytes
        {
            get
            {
                long alreadyDownloadBytes = 0;
                foreach (string downloadedBundle in this.downloadedBundles)
                {
                    long size = this.remoteVersionConfig.FileInfoDict[downloadedBundle].Size;
                    alreadyDownloadBytes += size;
                }

                if (this.webRequest != null)
                {
                    alreadyDownloadBytes += (long) this.webRequest.Request.downloadedBytes;
                }

                return alreadyDownloadBytes;
            }
        }

        public async ETTask DownloadAsync()
        {
            if (this.bundles.Count == 0 && this.downloadingBundle == "")
            {
                return;
            }

            try
            {
                this.progressTip = $"下载更新文件...{Math.Floor(this.AlreadyDownloadBytes / 1024f)}kb，全部：{Math.Floor(this.TotalSize / 1024f)}kb";
                while (true)
                {
                    if (this.bundles.Count == 0)
                    {
                        this.progressTip = "加载完成！";
                        break;
                    }

                    this.downloadingBundle = this.bundles.Dequeue();

                    while (true)
                    {
                        try
                        {
                            Log.Debug(this.downloadingBundle);
                            this.webRequest = new UnityWebRequestAsync();
                            await this.webRequest.DownloadAsync(BundleHelper.GetUrl() + "StreamingAssets/" +
                                this.downloadingBundle);
                            byte[] data = this.webRequest.Request.downloadHandler.data;

                            string path = Path.Combine(PathHelper.AppHotfixResPath, this.downloadingBundle);
                            using (FileStream fs = new FileStream(path, FileMode.Create))
                            {
                                fs.Write(data, 0, data.Length);
                            }
                            this.progressTip = $"下载更新文件...{Math.Floor(this.AlreadyDownloadBytes / 1024f)}kb，全部：{Math.Floor(this.TotalSize / 1024f)}kb";
                            this.webRequest.Dispose();
                            //this.webRequest = null;
                        }
                        catch (Exception e)
                        {
                            Log.Error($"download bundle error: {this.downloadingBundle}\n{e}");
                            continue;
                        }
                        break;
                    }

                    this.downloadedBundles.Add(this.downloadingBundle);
                    this.downloadingBundle = "";
                    this.webRequest = null;
                }
                this.progressTip = "文件下载完成";
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}