using UnityEngine;

namespace ET
{
    public static class TransformConvert
    {
        public static Vector3 ConvertPositon(Unit unit, Vector3 position)
        {
            TowerDefenceCompoment towerDefenceCompoment = unit.DomainScene().GetComponent<TowerDefenceCompoment>();
            if (towerDefenceCompoment.towerDefenceMode == TowerDefenceMode.Pvp)
            {
                long playerId = unit.DomainScene().GetComponent<PlayerComponent>().MyId;
                long id = unit.GetComponent<TowerDefenceIdComponent>().ID;
                TowerDefence towerDefence = towerDefenceCompoment.GetChild<TowerDefence>(id);
                if (towerDefence.playerIds.Contains(playerId))
                {
                    return position + new Vector3(0, 0, -4.25f);
                }
                else
                {
                    return Vector3.Scale(position + new Vector3(0, 0, -4.25f), new Vector3(1, 1, -1));
                }
            }
            else
            {
                return position;
            }
            
        }
    }
}