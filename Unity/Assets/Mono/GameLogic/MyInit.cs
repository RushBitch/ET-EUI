using System;
using System.Threading;
using UnityEngine;

namespace ET
{
    public class MyInit: MonoBehaviour
    {
        public CodeMode CodeMode = CodeMode.Mono;

        private void Awake()
        {
#if ENABLE_IL2CPP
			this.CodeMode = CodeMode.ILRuntime;
#endif

            System.AppDomain.CurrentDomain.UnhandledException += (sender, e) => { Log.Error(e.ExceptionObject.ToString()); };

            SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);

            DontDestroyOnLoad(gameObject);

            ETTask.ExceptionHandler += Log.Error;

            Log.ILog = new UnityLogger();

            Options.Instance = new Options();

            MyCodeLoader.Instance.CodeMode = this.CodeMode;
        }

        private async ETTask StartAsync()
        {
            if (Define.IsAsync)
            {
                await this.CheckAndLoadBundle();
            }

            MyCodeLoader.Instance.Start();
        }

        private async ETTask CheckAndLoadBundle()
        {
            BundleDownloaderComponent bundleDownloaderComponent = this.gameObject.AddComponent<BundleDownloaderComponent>();
            Transform parent = GameObject.Find("Global/UIRoot/NormalRoot").GetComponent<Transform>();
            GameObject loadingUI = (GameObject) Instantiate(Resources.Load("UI/Loading"), parent);
            LoadingUI ui = loadingUI.GetComponent<LoadingUI>();
            Func<float> a = () => bundleDownloaderComponent.Progress;
            ui.setProgressCallback(a);
            Func<string> b = () => bundleDownloaderComponent.ProgressTip;
            ui.setProgressTipCallback(b);
            await bundleDownloaderComponent.StartAsync();
            await bundleDownloaderComponent.DownloadAsync();
            Destroy(bundleDownloaderComponent);
            Destroy(loadingUI);
        }

        private void Start()
        {
            this.StartAsync().Coroutine();
        }

        private void Update()
        {
            if (MyCodeLoader.Instance.Update != null)
                MyCodeLoader.Instance.Update();
        }

        private void LateUpdate()
        {
            if (MyCodeLoader.Instance.LateUpdate != null)
                MyCodeLoader.Instance.LateUpdate();
        }

        private void OnApplicationQuit()
        {
            if (MyCodeLoader.Instance.OnApplicationQuit != null)
                MyCodeLoader.Instance.OnApplicationQuit();
            MyCodeLoader.Instance.Dispose();
        }
    }
}