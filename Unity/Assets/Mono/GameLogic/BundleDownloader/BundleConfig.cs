using System.Collections.Generic;
using System.IO;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    public class VersionConfig
    {
        public int Version;

        public long TotalSize;

        [BsonIgnore]
        public Dictionary<string, FileVersionInfo> FileInfoDict = new Dictionary<string, FileVersionInfo>();

        public void EndInit()
        {
            foreach (FileVersionInfo fileVersionInfo in this.FileInfoDict.Values)
            {
                this.TotalSize += fileVersionInfo.Size;
            }
        }
    }
    public class FileVersionInfo
    {
        public string File;
        public string MD5;
        public long Size;
    }

    public static class BundleHelper
    {
        public static string GetBundleMD5(VersionConfig streamingVersionConfig, string bundleName)
        {
            string path = Path.Combine(PathHelper.AppHotfixResPath, bundleName);
            if (File.Exists(path))
            {
                return MD5Helper.FileMD5(path);
            }

            if (streamingVersionConfig.FileInfoDict.ContainsKey(bundleName))
            {
                return streamingVersionConfig.FileInfoDict[bundleName].MD5;
            }

            return "";
        }

        public static string GetUrl()
        {
            return "https://xiaoyudi-1259481479.cos.ap-guangzhou.myqcloud.com/BenFei/Test/UnityDemo/remote26/";
        }
    }
    
    
}