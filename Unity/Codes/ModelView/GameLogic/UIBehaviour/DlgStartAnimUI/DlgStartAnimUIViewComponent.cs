
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgStartAnimUIViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_TopBarRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TopBarRectTransform == null )
     			{
		    		this.m_EG_TopBarRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_TopBar");
     			}
     			return this.m_EG_TopBarRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_VTextImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_VTextImage == null )
     			{
		    		this.m_E_VTextImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_TopBar/E_VText");
     			}
     			return this.m_E_VTextImage;
     		}
     	}

		public UnityEngine.RectTransform EG_ButtonBarRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ButtonBarRectTransform == null )
     			{
		    		this.m_EG_ButtonBarRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_ButtonBar");
     			}
     			return this.m_EG_ButtonBarRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_STextImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_STextImage == null )
     			{
		    		this.m_E_STextImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_ButtonBar/E_SText");
     			}
     			return this.m_E_STextImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_TopBarRectTransform = null;
			this.m_E_VTextImage = null;
			this.m_EG_ButtonBarRectTransform = null;
			this.m_E_STextImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_TopBarRectTransform = null;
		private UnityEngine.UI.Image m_E_VTextImage = null;
		private UnityEngine.RectTransform m_EG_ButtonBarRectTransform = null;
		private UnityEngine.UI.Image m_E_STextImage = null;
		public Transform uiTransform = null;
	}
}
