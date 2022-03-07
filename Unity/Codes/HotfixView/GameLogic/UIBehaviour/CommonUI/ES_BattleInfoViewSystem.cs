
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ES_BattleInfoAwakeSystem : AwakeSystem<ES_BattleInfo,Transform> 
	{
		public override void Awake(ES_BattleInfo self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_BattleInfoDestroySystem : DestroySystem<ES_BattleInfo> 
	{
		public override void Destroy(ES_BattleInfo self)
		{
			self.DestroyWidget();
		}
	}
}
