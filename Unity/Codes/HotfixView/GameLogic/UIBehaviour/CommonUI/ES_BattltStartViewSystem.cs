
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ES_BattltStartAwakeSystem : AwakeSystem<ES_BattltStart,Transform> 
	{
		public override void Awake(ES_BattltStart self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_BattltStartDestroySystem : DestroySystem<ES_BattltStart> 
	{
		public override void Destroy(ES_BattltStart self)
		{
			self.DestroyWidget();
		}
	}
}
