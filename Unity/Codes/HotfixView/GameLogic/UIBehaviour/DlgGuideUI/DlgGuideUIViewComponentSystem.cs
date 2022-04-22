
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgGuideUIViewComponentAwakeSystem : AwakeSystem<DlgGuideUIViewComponent> 
	{
		public override void Awake(DlgGuideUIViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgGuideUIViewComponentDestroySystem : DestroySystem<DlgGuideUIViewComponent> 
	{
		public override void Destroy(DlgGuideUIViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
