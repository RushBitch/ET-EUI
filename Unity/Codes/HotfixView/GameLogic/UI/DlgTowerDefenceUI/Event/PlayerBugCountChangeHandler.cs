namespace ET
{
    [NumericalWatcher(NumericalType.PlayerBuyCount)]
    public class PlayerBugCountChangeHandler:INumericalWatcher
    {
        public void Run(long id, long value)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            if (id == scene.GetComponent<PlayerComponent>().MyId)
            {
                UIBaseWindow dlgTowerDefenceUI;
                scene.GetComponent<UIComponent>().VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_TowerDefenceUI,out dlgTowerDefenceUI) ;
                if (dlgTowerDefenceUI!=null)
                {
                    dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUIViewComponent>().ELabel_CostText.text = $"{value*10}";
                }
            }
        }
    }
}