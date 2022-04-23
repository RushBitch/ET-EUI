using System;
using UnityEngine;

namespace ET
{
    public class NativeHelper
    {
        private AndroidJavaObject jo;
        private static NativeHelper _instance;

        public static NativeHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NativeHelper();
                }

                return _instance;
            }
        }

        public NativeHelper()
        {
            using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
            }
        }

        public T SDKCall<T>(string method, params object[] param)
        {
            try
            {
                return jo.Call<T>(method, param);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            return default (T);
        }

        public void SDKCall(string method, params object[] param)
        {
            try
            {
                jo.CallStatic(method);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        public void SdkDataAnalysisCustomEvents(string eventName)
        {
            try
            {
                jo.CallStatic("SdkDataAnalysisCustomEvents",eventName);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}