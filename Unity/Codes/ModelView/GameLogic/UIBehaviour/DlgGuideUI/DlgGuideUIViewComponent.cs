
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgGuideUIViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_BgRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BgRectTransform == null )
     			{
		    		this.m_EG_BgRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Bg");
     			}
     			return this.m_EG_BgRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_FingerRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_FingerRectTransform == null )
     			{
		    		this.m_EG_FingerRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Finger");
     			}
     			return this.m_EG_FingerRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_TouchFingerRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TouchFingerRectTransform == null )
     			{
		    		this.m_EG_TouchFingerRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_TouchFinger");
     			}
     			return this.m_EG_TouchFingerRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_BgRectTransform = null;
			this.m_EG_FingerRectTransform = null;
			this.m_EG_TouchFingerRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_BgRectTransform = null;
		private UnityEngine.RectTransform m_EG_FingerRectTransform = null;
		private UnityEngine.RectTransform m_EG_TouchFingerRectTransform = null;
		public Transform uiTransform = null;
	}
}
