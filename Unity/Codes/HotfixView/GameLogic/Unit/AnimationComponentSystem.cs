using UnityEngine;

namespace ET
{
    public struct AnimType
    {
        public const string 攻击 = "gj";
        public const string 闲置 = "id";
        public const string 技能 = "jn";
        public const string 走路 = "zou";
        public const string 死亡 = "sw";
    }

    public class AnimationComponentAwaleSystem: AwakeSystem<AnimationComponent, GameObject>
    {
        public override void Awake(AnimationComponent self, GameObject gameObject)
        {
            self.animation = gameObject.GetComponent<Animation>();
        }
    }

    public static class AnimationComponentSystem
    {
        public static void Play(this AnimationComponent self, string animName)
        {
            if (self.animation == null) return;
            if (self.animation.GetClip(animName) == null) return;
            self.animation.Play(animName);
        }

        public static void CrossFade(this AnimationComponent self, string animName)
        {
            if (self.animation == null) return;
            if (self.animation.GetClip(animName) == null) return;
            self.animation.CrossFade(animName,0.5f);
        }

        public static void SetSpeed(this AnimationComponent self, float speed)
        {
            Animation anim = self.animation;
            foreach (AnimationState state in anim)
            {
                state.speed = speed;
            }
        }
    }
}