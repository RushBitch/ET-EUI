namespace ET
{
    [NumericalWatcher(NumericalType.PlayerEnergy)]
    public class PlayerEnergyChangeHandle:INumericalWatcher
    {
        public async void Run(long id, long value)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            if (id == scene.GetComponent<PlayerComponent>().MyId)
            {
                UIBaseWindow dlgTowerDefenceUI;
                scene.GetComponent<UIComponent>().VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_TowerDefenceUI,out dlgTowerDefenceUI) ;
                if (dlgTowerDefenceUI!=null)
                {
                    dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUIViewComponent>().ELabel_EnergyText.text = value.ToString();
                }
            }
            await ETTask.CompletedTask;
        }
    }
}