using System;
using UnityEngine.Networking;

namespace ET
{
    public class UnityWebRequestAsync: IDisposable
    {
        public class AcceptAllCertificate: CertificateHandler
        {
            protected override bool ValidateCertificate(byte[] certificateData)
            {
                return true;
            }
        }

        public static AcceptAllCertificate certificateHandler = new AcceptAllCertificate();

        public UnityWebRequest Request;

        public bool isCancel;

        public ETTask tcs;

        public float Progress
        {
            get
            {
                if (this.Request == null)
                {
                    return 0;
                }

                return this.Request.downloadProgress;
            }
        }

        public ulong ByteDownloaded
        {
            get
            {
                if (this.Request == null)
                {
                    return 0;
                }

                return this.Request.downloadedBytes;
            }
        }

        public void Update()
        {
            if (this.isCancel)
            {
                this.tcs.SetException(new Exception($"request error: {this.Request.error}"));
                return;
            }

            if (!this.Request.isDone)
            {
                return;
            }

            if (!string.IsNullOrEmpty(this.Request.error))
            {
                this.tcs.SetException(new Exception($"request error: {this.Request.error}"));
                return;
            }

            this.tcs.SetResult();
        }

        public ETTask DownloadAsync(string url)
        {
            this.tcs = ETTask.Create();
            url = url.Replace(" ", "%20");
            this.Request = UnityWebRequest.Get(url);
            this.Request.certificateHandler = certificateHandler;
            this.Request.SendWebRequest();
            return this.tcs;
        }

        public void Dispose()
        {
            this.Request?.Dispose();
            this.Request = null;
            this.isCancel = false;
        }
    }
}