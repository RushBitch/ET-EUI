namespace ET
{
    public class AfterCreateTowerDefence: AEvent<EventType.AfterCreateTowerDefence>
    {
        protected override async ETTask Run(EventType.AfterCreateTowerDefence args)
        {
            await TowerDefenceComponentViewFactory.Create(args.TowerDefence);
            UIComponent.Instance.HideWindow(WindowID.WindowID_MenuUI);
            ShowWindowData showWindowData = new ShowWindowData();
            showWindowData.contextData = args.TowerDefence;
            UIComponent.Instance.ShowWindow(WindowID.WindowID_TowerDefenceUI,WindowID.WindowID_Invaild,showWindowData);

            await ETTask.CompletedTask;
        }
    }
}