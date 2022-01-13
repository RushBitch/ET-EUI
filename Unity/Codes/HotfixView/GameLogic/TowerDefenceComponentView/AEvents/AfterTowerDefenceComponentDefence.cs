namespace ET
{
    public class AfterCreateTowerDefence: AEvent<EventType.AfterCreateTowerDefence>
    {
        protected override async ETTask Run(EventType.AfterCreateTowerDefence args)
        {
            await TowerDefenceComponentViewFactory.Create(args.TowerDefence);
            args.TowerDefence.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_MenuUI);
            ShowWindowData showWindowData = new ShowWindowData();
            showWindowData.contextData = args.TowerDefence;
            args.TowerDefence.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_TowerDefenceUI,WindowID.WindowID_Invaild,showWindowData);

            await ETTask.CompletedTask;
        }
    }
}