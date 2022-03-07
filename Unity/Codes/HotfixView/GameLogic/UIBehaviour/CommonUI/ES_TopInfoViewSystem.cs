
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ES_TopInfoAwakeSystem : AwakeSystem<ES_TopInfo,Transform> 
	{
		public override void Awake(ES_TopInfo self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_TopInfoDestroySystem : DestroySystem<ES_TopInfo> 
	{
		public override void Destroy(ES_TopInfo self)
		{
			self.DestroyWidget();
		}
	}
}
