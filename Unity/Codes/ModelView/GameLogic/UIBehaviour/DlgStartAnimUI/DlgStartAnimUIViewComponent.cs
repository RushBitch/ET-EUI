
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

		public UnityEngine.RectTransform EG_AnimalsTopIconRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AnimalsTopIconRectTransform == null )
     			{
		    		this.m_EG_AnimalsTopIconRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_TopBar/EG_AnimalsTopIcon");
     			}
     			return this.m_EG_AnimalsTopIconRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_ClashminiTopIconRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ClashminiTopIconRectTransform == null )
     			{
		    		this.m_EG_ClashminiTopIconRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_TopBar/EG_ClashminiTopIcon");
     			}
     			return this.m_EG_ClashminiTopIconRectTransform;
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

		public UnityEngine.RectTransform EG_AnimalsButtomIconRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AnimalsButtomIconRectTransform == null )
     			{
		    		this.m_EG_AnimalsButtomIconRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_ButtonBar/EG_AnimalsButtomIcon");
     			}
     			return this.m_EG_AnimalsButtomIconRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_ClashminiButtomIconRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ClashminiButtomIconRectTransform == null )
     			{
		    		this.m_EG_ClashminiButtomIconRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_ButtonBar/EG_ClashminiButtomIcon");
     			}
     			return this.m_EG_ClashminiButtomIconRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_TopBarRectTransform = null;
			this.m_E_VTextImage = null;
			this.m_EG_AnimalsTopIconRectTransform = null;
			this.m_EG_ClashminiTopIconRectTransform = null;
			this.m_EG_ButtonBarRectTransform = null;
			this.m_E_STextImage = null;
			this.m_EG_AnimalsButtomIconRectTransform = null;
			this.m_EG_ClashminiButtomIconRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_TopBarRectTransform = null;
		private UnityEngine.UI.Image m_E_VTextImage = null;
		private UnityEngine.RectTransform m_EG_AnimalsTopIconRectTransform = null;
		private UnityEngine.RectTransform m_EG_ClashminiTopIconRectTransform = null;
		private UnityEngine.RectTransform m_EG_ButtonBarRectTransform = null;
		private UnityEngine.UI.Image m_E_STextImage = null;
		private UnityEngine.RectTransform m_EG_AnimalsButtomIconRectTransform = null;
		private UnityEngine.RectTransform m_EG_ClashminiButtomIconRectTransform = null;
		public Transform uiTransform = null;
	}
}
