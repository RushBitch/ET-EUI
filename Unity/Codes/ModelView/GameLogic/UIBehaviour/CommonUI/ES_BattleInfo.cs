
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class ES_BattleInfo : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.RectTransform EG_MyHpRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MyHpRectTransform == null )
     			{
		    		this.m_EG_MyHpRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_MyHp");
     			}
     			return this.m_EG_MyHpRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_EnemyMyHpRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EnemyMyHpRectTransform == null )
     			{
		    		this.m_EG_EnemyMyHpRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_EnemyMyHp");
     			}
     			return this.m_EG_EnemyMyHpRectTransform;
     		}
     	}

		public UnityEngine.UI.Text ELabel_CountDownText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_CountDownText == null )
     			{
		    		this.m_ELabel_CountDownText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_CountDown");
     			}
     			return this.m_ELabel_CountDownText;
     		}
     	}

		public UnityEngine.RectTransform EG_MyEnemyCountRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MyEnemyCountRectTransform == null )
     			{
		    		this.m_EG_MyEnemyCountRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_MyEnemyCount");
     			}
     			return this.m_EG_MyEnemyCountRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_EnemyEnemyCountRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EnemyEnemyCountRectTransform == null )
     			{
		    		this.m_EG_EnemyEnemyCountRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_EnemyEnemyCount");
     			}
     			return this.m_EG_EnemyEnemyCountRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_MyHpRectTransform = null;
			this.m_EG_EnemyMyHpRectTransform = null;
			this.m_ELabel_CountDownText = null;
			this.m_EG_MyEnemyCountRectTransform = null;
			this.m_EG_EnemyEnemyCountRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_MyHpRectTransform = null;
		private UnityEngine.RectTransform m_EG_EnemyMyHpRectTransform = null;
		private UnityEngine.UI.Text m_ELabel_CountDownText = null;
		private UnityEngine.RectTransform m_EG_MyEnemyCountRectTransform = null;
		private UnityEngine.RectTransform m_EG_EnemyEnemyCountRectTransform = null;
		public Transform uiTransform = null;
	}
}
