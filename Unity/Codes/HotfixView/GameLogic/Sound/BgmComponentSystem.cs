using DG.Tweening;
using UnityEngine;

namespace ET
{
    public class BgmComponentAwakeSystem: AwakeSystem<BgmComponent>
    {
        public override void Awake(BgmComponent self)
        {
            BgmComponent.Instance = self;
            self.AudioSource = GlobalComponent.Instance.Global.gameObject.GetComponent<AudioSource>();
            self.volume = 0;
            self.AudioSource.volume = 0;
        }
    }

    public class BgmComponentUpdateSystem: UpdateSystem<BgmComponent>
    {
        public override void Update(BgmComponent self)
        {
            if (self.AudioSource.isPlaying)
            {
                self.AudioSource.volume = Mathf.Lerp(self.AudioSource.volume, self.volume, Time.deltaTime);
            }
            else
            {
                self.AudioSource.volume = Mathf.Lerp(self.AudioSource.volume, self.volume, Time.deltaTime * 0.2f);
            }
        }
    }

    public static class BgmComponentSystem
    {
        public static void Play(this BgmComponent self, Music music, float volume)
        {
            ResourcesComponent.Instance.LoadBundle("music.unity3d");
            AudioClip audioClip = (AudioClip) ResourcesComponent.Instance.GetAsset("music.unity3d", music.ToString());
            self.AudioSource.clip = audioClip;
            self.AudioSource.loop = true;
            self.AudioSource.Play();
            self.AudioSource.volume = 0;
            self.SetVolueme(volume).Coroutine();
        }

        public static async ETTask SetVolueme(this BgmComponent self, float volume)
        {
            self.volume = volume / 4;
            await TimerComponent.Instance.WaitAsync(500);
            self.volume = volume / 2;
            await TimerComponent.Instance.WaitAsync(500);
            self.volume = volume;
        }

        public static void Stop(this BgmComponent self)
        {
            // if (self.AudioSource.isPlaying)
            // {
            //     self.AudioSource.Stop();
            // }
            self.volume = 0;
        }
    }
}