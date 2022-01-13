
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgMenuUIViewComponentAwakeSystem : AwakeSystem<DlgMenuUIViewComponent> 
	{
		public override void Awake(DlgMenuUIViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgMenuUIViewComponentDestroySystem : DestroySystem<DlgMenuUIViewComponent> 
	{
		public override void Destroy(DlgMenuUIViewComponent self)
		{
			self.m_EButton_SoloImage = null;
			self.m_EButton_Solo = null;
			self.m_ELabel_Solo = null;
			self.m_EButton_PvpImage = null;
			self.m_EButton_Pvp = null;
			self.m_ELabel_Pvp = null;
			self.m_EButton_TeamImage = null;
			self.m_EButton_Team = null;
			self.m_ELabel_Team = null;
			self.uiTransform = null;
		}
	}
}
