using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [RequireComponent(typeof (Text))]
    public class MulitLanguageText: MonoBehaviour
    {
        public int id = 0;
        public static Action<Text,int> SetText = null;

        private void Awake()
        {
            if (SetText != null)
            {
                SetText.Invoke(this.GetComponent<Text>(),this.id);
            }
        }
    }
}