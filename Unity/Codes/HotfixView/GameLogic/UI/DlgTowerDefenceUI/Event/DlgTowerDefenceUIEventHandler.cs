namespace ET
{
	[AUIEvent(WindowID.WindowID_TowerDefenceUI)]
	public  class DlgTowerDefenceUIEventHandler : IAUIEventHandler
	{

		public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.WindowData.windowType = UIWindowType.Normal; 
		}

		public void OnInitComponent(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.AddComponent<DlgTowerDefenceUIViewComponent>(); 
		  uiBaseWindow.AddComponent<DlgTowerDefenceUI>(); 
		}

		public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.GetComponent<DlgTowerDefenceUI>().RegisterUIEvent(); 
		}

		public void OnShowWindow(UIBaseWindow uiBaseWindow, Entity contextData = null)
		{
		  uiBaseWindow.GetComponent<DlgTowerDefenceUI>().ShowWindow(contextData); 
		}

		public void OnHideWindow(UIBaseWindow uiBaseWindow)
		{
<<<<<<< HEAD:Unity/Codes/HotfixView/GameLogic/UI/DlgTowerDefenceUI/Event/DlgTowerDefenceUIEventHandler.cs
=======
			
>>>>>>> upstream/main:Unity/Codes/HotfixView/Demo/UI/DlgTest/Event/DlgTestEventHandler.cs
		}

		public void BeforeUnload(UIBaseWindow uiBaseWindow)
		{
		}

	}
}
