
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgTowerDefenceUIViewComponentAwakeSystem : AwakeSystem<DlgTowerDefenceUIViewComponent> 
	{
		public override void Awake(DlgTowerDefenceUIViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgTowerDefenceUIViewComponentDestroySystem : DestroySystem<DlgTowerDefenceUIViewComponent> 
	{
		public override void Destroy(DlgTowerDefenceUIViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
