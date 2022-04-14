using UnityEngine;

namespace ET
{
    public enum Music
    {
        BGM_Battle = 1,
        首页BGM,
    }

    public class BgmComponent: Entity, IAwake
    {
        public static BgmComponent Instance;
        public Music currentMusic;
        public AudioSource AudioSource;
    }
}