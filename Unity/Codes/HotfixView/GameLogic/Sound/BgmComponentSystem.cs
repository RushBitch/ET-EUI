using UnityEngine;

namespace ET
{
    public class BgmComponentAwakeSystem: AwakeSystem<BgmComponent>
    {
        public override void Awake(BgmComponent self)
        {
            BgmComponent.Instance = self;
            self.AudioSource = GlobalComponent.Instance.Global.gameObject.GetComponent<AudioSource>();
        }
    }

    public static class BgmComponentSystem
    {
        public static void Play(this BgmComponent self, Music music,float volume)
        {
            // if (self.currentMusic == music)
            // {
            //     self.AudioSource.volume = volume;
            //     self.AudioSource.loop = true;
            //     self.AudioSource.Play();
            // }

            ResourcesComponent.Instance.LoadBundle("music.unity3d");
            AudioClip audioClip = (AudioClip) ResourcesComponent.Instance.GetAsset("music.unity3d", music.ToString());
            //self.AudioSource.Stop();
            self.AudioSource.clip = audioClip;
            self.AudioSource.volume = volume;
            self.AudioSource.loop = true;
            self.AudioSource.Play();
        }

        public static void Stop(this BgmComponent self)
        {
            if (self.AudioSource.isPlaying)
            {
                self.AudioSource.Stop();
            }
        }
    }
}