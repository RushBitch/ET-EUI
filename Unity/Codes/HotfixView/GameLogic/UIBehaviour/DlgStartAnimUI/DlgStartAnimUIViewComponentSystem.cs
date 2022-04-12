
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgStartAnimUIViewComponentAwakeSystem : AwakeSystem<DlgStartAnimUIViewComponent> 
	{
		public override void Awake(DlgStartAnimUIViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgStartAnimUIViewComponentDestroySystem : DestroySystem<DlgStartAnimUIViewComponent> 
	{
		public override void Destroy(DlgStartAnimUIViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
