using System;
using UnityEngine.UI;

namespace ET
{
    public class LanguageComponentAwakeSystem: AwakeSystem<LanguageComponent, LangueageType>
    {
        public override void Awake(LanguageComponent self, LangueageType langueageType)
        {
            LanguageComponent.Instance = self;
            self.languageType = langueageType;
            MulitLanguageText.SetText = (text, i) => { text.text =  self.Get(i); };
        }
    }

    public enum LangueageType
    {
        中文,
        英文
    }

    public class LanguageComponent: Entity, IAwake<LangueageType>
    {
        public LangueageType languageType;
        public static LanguageComponent Instance { get; set; }

        public string Get(int id)
        {
            LanguageConfig languageConfig = LanguageConfigCategory.Instance.Get(id);
            switch (Instance.languageType)
            {
                case LangueageType.中文:
                    return languageConfig.Chinese;
                case LangueageType.英文:
                    return languageConfig.English;
                default:
                    return null;
            }
        }
    }
}