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
                            VARIABLE.GetComponent<EnemySpawnComponent>().StopSpawnEnemy();
                        }
                    }
                }

                if (args.count == 5)
                {
                    dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUI>().PlayBossCommingAnim().Coroutine();
                }

                dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUIViewComponent>().ES_BattleInfo.ELabel_CountDownText.text = valueStr;
            }

            if (CountDownComponent.additionCount == 60)
            {
                NativeHelper.Instance.SdkDataAnalysisCustomEvents(AnalysisCustomEvents.开始游戏1分钟);
            }

            if (CountDownComponent.additionCount == 120)
            {
                NativeHelper.Instance.SdkDataAnalysisCustomEvents(AnalysisCustomEvents.开始游戏2分钟);
            }

            if (CountDownComponent.additionCount == 180)
            {
                NativeHelper.Instance.SdkDataAnalysisCustomEvents(AnalysisCustomEvents.开始游戏3分钟);
            }

            if (CountDownComponent.additionCount == 300)
            {
                NativeHelper.Instance.SdkDataAnalysisCustomEvents(AnalysisCustomEvents.开始游戏5分钟);
            }

            if (CountDownComponent.additionCount == 600)
            {
                NativeHelper.Instance.SdkDataAnalysisCustomEvents(AnalysisCustomEvents.开始游戏10分钟);
            }

            await ETTask.CompletedTask;
        }
    }
}