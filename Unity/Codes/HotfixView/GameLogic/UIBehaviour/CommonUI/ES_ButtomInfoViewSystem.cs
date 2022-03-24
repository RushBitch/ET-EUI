
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ES_ButtomInfoAwakeSystem : AwakeSystem<ES_ButtomInfo,Transform> 
	{
		public override void Awake(ES_ButtomInfo self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_ButtomInfoDestroySystem : DestroySystem<ES_ButtomInfo> 
	{
		public override void Destroy(ES_ButtomInfo self)
		{
			self.DestroyWidget();
		}
	}
}
