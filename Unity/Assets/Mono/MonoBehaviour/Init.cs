using System;
using System.Threading;
using UnityEngine;

namespace ET
{
    // 1 mono模式 2 ILRuntime模式 3 mono热重载模式
    public enum CodeMode
    {
        Mono = 1,
        ILRuntime = 2,
        Reload = 3,
    }

    public class Init: MonoBehaviour
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

            CodeLoader.Instance.CodeMode = this.CodeMode;
        }

        private async ETTask StartAsync()
        {
            if (Define.IsAsync)
            {
                await this.CheckAndLoadBundle();
            }

            CodeLoader.Instance.Start();
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
            if (CodeLoader.Instance.Update != null)
                CodeLoader.Instance.Update();
        }

        private void LateUpdate()
        {
            if (CodeLoader.Instance.LateUpdate != null)
                CodeLoader.Instance.LateUpdate();
        }

        private void OnApplicationQuit()
        {
            if (CodeLoader.Instance.OnApplicationQuit != null)
                CodeLoader.Instance.OnApplicationQuit();
            CodeLoader.Instance.Dispose();
        }
    }
}