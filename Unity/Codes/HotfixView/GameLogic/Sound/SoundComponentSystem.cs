using UnityEditor.UI;
using UnityEngine;

namespace ET
{
    public class SoundComponentAwakeSystem: AwakeSystem<SoundComponent, GameObject>
    {
        public override void Awake(SoundComponent self, GameObject gameObject)
        {
            self.audioRoot = gameObject;
            SoundComponent.Instance = self;
            self.audioSource = self.audioRoot.GetComponent<AudioSource>();
        }
    }

    public static class SoundComponentSystem
    {
        public static void Play(this SoundComponent self, Sound sound)
        {
            ResourcesComponent.Instance.LoadBundle("sound.unity3d");
            AudioClip audioClip = (AudioClip) ResourcesComponent.Instance.GetAsset("sound.unity3d", sound.ToString());
            self.audioSource.clip = UnityEngine.Object.Instantiate(audioClip);
            self.audioSource.PlayOneShot(audioClip);
        }
    }
}