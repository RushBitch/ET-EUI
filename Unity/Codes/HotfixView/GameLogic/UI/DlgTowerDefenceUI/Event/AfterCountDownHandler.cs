using ET.EventType;

namespace ET
{
    public class AfterCountDownHandler: AEvent<AfterCountDown>
    {
        protected async override ETTask Run(AfterCountDown args)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            UIBaseWindow dlgTowerDefenceUI;
            scene.GetComponent<UIComponent>().VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_TowerDefenceUI, out dlgTowerDefenceUI);
            if (dlgTowerDefenceUI != null)
            {
                string valueStr = "";
                //Log.Info($"{args.count}");
                if (args.count > 0)
                {
                    valueStr = $"0{args.count / 60}:{args.count % 60}";
                }
                else
                {
                    //Log.Info("倒数结束");
                    foreach (var VARIABLE in scene.GetComponent<TowerDefenceCompoment>().Children.Values)
                    {
                        if (VARIABLE.GetComponent<EnemySpawnComponent>() != null)
                        {
                            VARIABLE.GetComponent<EnemySpawnComponent>().SpawnBoss();
                            VARIABLE.GetComponent<EnemySpawnComponent>().StopSpawnEnemy();
                        }
                    }
                }

                dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUIViewComponent>().ES_BattleInfo.ELabel_CountDownText.text = valueStr;
            }

            await ETTask.CompletedTask;
        }
    }
}