
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class ES_ButtomInfo : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image EnergyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EnergyImage == null )
     			{
		    		this.m_EnergyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Energy");
     			}
     			return this.m_EnergyImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_EnergyText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_EnergyText == null )
     			{
		    		this.m_ELabel_EnergyText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Energy/ELabel_Energy");
     			}
     			return this.m_ELabel_EnergyText;
     		}
     	}

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

		public void DestroyWidget()
		{
			this.m_EnergyImage = null;
			this.m_ELabel_EnergyText = null;
			this.m_EG_MyHpRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EnergyImage = null;
		private UnityEngine.UI.Text m_ELabel_EnergyText = null;
		private UnityEngine.RectTransform m_EG_MyHpRectTransform = null;
		public Transform uiTransform = null;
	}
}
