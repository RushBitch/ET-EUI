using UnityEngine;

namespace ET
{
    public enum Music
    {
        BGM = 1
    }

    public class BgmComponent: Entity, IAwake
    {
        public static BgmComponent Instance;
        public Music currentMusic;
        public AudioSource AudioSource;
    }
}