
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgSettleUIViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_LoseRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LoseRectTransform == null )
     			{
		    		this.m_EG_LoseRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Lose");
     			}
     			return this.m_EG_LoseRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_VicyoryRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_VicyoryRectTransform == null )
     			{
		    		this.m_EG_VicyoryRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Vicyory");
     			}
     			return this.m_EG_VicyoryRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_CoinRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_CoinRectTransform == null )
     			{
		    		this.m_EG_CoinRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Coin");
     			}
     			return this.m_EG_CoinRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_TrophyRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TrophyRectTransform == null )
     			{
		    		this.m_EG_TrophyRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Trophy");
     			}
     			return this.m_EG_TrophyRectTransform;
     		}
     	}

		public UnityEngine.UI.Button EButton_BackToMainButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_BackToMainButton == null )
     			{
		    		this.m_EButton_BackToMainButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_BackToMain");
     			}
     			return this.m_EButton_BackToMainButton;
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

		public void DestroyWidget()
		{
			this.m_EG_LoseRectTransform = null;
			this.m_EG_VicyoryRectTransform = null;
			this.m_EG_CoinRectTransform = null;
			this.m_EG_TrophyRectTransform = null;
			this.m_EButton_BackToMainButton = null;
			this.m_EButton_BackToMainImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_LoseRectTransform = null;
		private UnityEngine.RectTransform m_EG_VicyoryRectTransform = null;
		private UnityEngine.RectTransform m_EG_CoinRectTransform = null;
		private UnityEngine.RectTransform m_EG_TrophyRectTransform = null;
		private UnityEngine.UI.Button m_EButton_BackToMainButton = null;
		private UnityEngine.UI.Image m_EButton_BackToMainImage = null;
		public Transform uiTransform = null;
	}
}
