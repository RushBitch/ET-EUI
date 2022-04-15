using ET.EventType;

namespace ET
{
    public class StartNextRoundHandler: AEvent<StartNextRound>
    {
        protected override async ETTask Run(StartNextRound args)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            UIBaseWindow dlgTowerDefenceUI;
            scene.GetComponent<UIComponent>().VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_TowerDefenceUI, out dlgTowerDefenceUI);
            if (dlgTowerDefenceUI != null)
            {
                await TimerComponent.Instance.WaitAsync(2000);
                dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUI>().ShowStartAnim().Coroutine();
            }

            await ETTask.CompletedTask;
        }
    }
}