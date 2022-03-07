using ET.EventType;

namespace ET
{
    public class EnemyKilledByHeroHandler: AEvent<EnemyKilledByHero>
    {
        protected async override ETTask Run(EnemyKilledByHero args)
        {
            long id = args.unit.GetComponent<TowerDefenceIdComponent>().ID;
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            TowerDefence towerDefence = scene.GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id);
            Player player = scene.GetComponent<PlayerComponent>().Get(towerDefence.playerIds[0]);
            player.GetComponent<NumericalComponent>().Set(NumericalType.PlayerEnergyBase,
                player.GetComponent<NumericalComponent>().GetAsInt(NumericalType.PlayerEnergy) + 20);
            await ETTask.CompletedTask;
        }
    }
}