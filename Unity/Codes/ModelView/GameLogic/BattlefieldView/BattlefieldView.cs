using UnityEngine;

namespace ET
{
    public class BattlefieldView: Entity, IAwake<GameObject>, IDestroy
    {
        public GameObject BattleRoot;
    }
}