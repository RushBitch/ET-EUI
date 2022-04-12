
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgSettleUIViewComponentAwakeSystem : AwakeSystem<DlgSettleUIViewComponent> 
	{
		public override void Awake(DlgSettleUIViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgSettleUIViewComponentDestroySystem : DestroySystem<DlgSettleUIViewComponent> 
	{
		public override void Destroy(DlgSettleUIViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
