
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgTowerDefenceUIViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EButton_BackToMain
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_BackToMain == null )
     			{
		    		this.m_EButton_BackToMain = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_BackToMain");
     			}
     			return this.m_EButton_BackToMain;
     		}
     	}

		public UnityEngine.UI.Image EButton_BackToMainImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_BackToMainImage == null )
     			{
		    		this.m_EButton_BackToMainImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_BackToMain");
     			}
     			return this.m_EButton_BackToMainImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_BackToMain
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_BackToMain == null )
     			{
		    		this.m_ELabel_BackToMain = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_BackToMain/ELabel_BackToMain");
     			}
     			return this.m_ELabel_BackToMain;
     		}
     	}

		public UnityEngine.UI.Image m_EButton_BackToMainImage = null;
		public UnityEngine.UI.Button m_EButton_BackToMain = null;
		public UnityEngine.UI.Text m_ELabel_BackToMain = null;
		public Transform uiTransform = null;
	}
}
