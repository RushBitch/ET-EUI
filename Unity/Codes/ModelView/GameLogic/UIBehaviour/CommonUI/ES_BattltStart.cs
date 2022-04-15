
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class ES_BattltStart : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.RectTransform EG_CommingRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_CommingRectTransform == null )
     			{
		    		this.m_EG_CommingRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Comming");
     			}
     			return this.m_EG_CommingRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_MonsterMonsterRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MonsterMonsterRectTransform == null )
     			{
		    		this.m_EG_MonsterMonsterRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_MonsterMonster");
     			}
     			return this.m_EG_MonsterMonsterRectTransform;
     		}
     	}

		public UnityEngine.UI.Text ELabel_TextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_TextText == null )
     			{
		    		this.m_ELabel_TextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Text");
     			}
     			return this.m_ELabel_TextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_CommingRectTransform = null;
			this.m_EG_MonsterMonsterRectTransform = null;
			this.m_ELabel_TextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_CommingRectTransform = null;
		private UnityEngine.RectTransform m_EG_MonsterMonsterRectTransform = null;
		private UnityEngine.UI.Text m_ELabel_TextText = null;
		public Transform uiTransform = null;
	}
}
