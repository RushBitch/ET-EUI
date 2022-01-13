
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
			self.m_EButton_BackToMainImage = null;
			self.m_EButton_BackToMain = null;
			self.m_ELabel_BackToMain = null;
			self.uiTransform = null;
		}
	}
}
