
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class ES_TopInfo : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Button EButton_InfoSwitchButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_InfoSwitchButton == null )
     			{
		    		this.m_EButton_InfoSwitchButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_InfoSwitch");
     			}
     			return this.m_EButton_InfoSwitchButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_InfoSwitchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_InfoSwitchImage == null )
     			{
		    		this.m_EButton_InfoSwitchImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_InfoSwitch");
     			}
     			return this.m_EButton_InfoSwitchImage;
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

		public void DestroyWidget()
		{
			this.m_EButton_InfoSwitchButton = null;
			this.m_EButton_InfoSwitchImage = null;
			this.m_EG_EnemyMyHpRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EButton_InfoSwitchButton = null;
		private UnityEngine.UI.Image m_EButton_InfoSwitchImage = null;
		private UnityEngine.RectTransform m_EG_EnemyMyHpRectTransform = null;
		public Transform uiTransform = null;
	}
}
