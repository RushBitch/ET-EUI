using UnityEngine;

namespace ET
{
    public class AnimationComponent:Entity, IAwake<GameObject>
    {
        public Animation animation;
    }
}