using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class LoadingUI: MonoBehaviour
    {
        public Text text = null;
        public Slider slider = null;

        private Func<string> getProgressTipCallback = null;
        private Func<float> getProgressCallback = null;

        public void Update()
        {
            this.text.text = this.getProgressTipCallback?.Invoke();
            if (this.getProgressCallback != null)
            {
                this.slider.value = this.getProgressCallback.Invoke();
            }
        }

        public void setProgressTipCallback(Func<string> func)
        {
            this.getProgressTipCallback = func;
        }

        public void setProgressCallback(Func<float> func)
        {
            this.getProgressCallback = func;
        }
    }
}