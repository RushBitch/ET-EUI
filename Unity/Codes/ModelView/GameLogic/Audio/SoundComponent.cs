using UnityEngine;

namespace ET
{
    public enum Sound
    {
        匹配界面鼓声,
        VS碰撞音效,
        点击购买失败音效,
        Boss吼叫,
        Boss消失音效,
        撞击水晶掉血音效,
        水晶爆炸完整,
        胜利页面音效,
        失败页面音效,
        首页BGM,
        英雄倒地
    }
    public class SoundComponent:Entity,IAwake<GameObject>
    {
        public static SoundComponent Instance;
        public GameObject audioRoot;
        public AudioSource audioSource;
    }
}