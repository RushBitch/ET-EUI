
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ES_BossCommingAwakeSystem : AwakeSystem<ES_BossComming,Transform> 
	{
		public override void Awake(ES_BossComming self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_BossCommingDestroySystem : DestroySystem<ES_BossComming> 
	{
		public override void Destroy(ES_BossComming self)
		{
			self.DestroyWidget();
		}
	}
}
