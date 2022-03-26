
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class ES_BossComming : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image ECommingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECommingImage == null )
     			{
		    		this.m_ECommingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EComming");
     			}
     			return this.m_ECommingImage;
     		}
     	}

		public UnityEngine.UI.Image ETipImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETipImage == null )
     			{
		    		this.m_ETipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EComming/ETip");
     			}
     			return this.m_ETipImage;
     		}
     	}

		public UnityEngine.UI.Image E5Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E5Image == null )
     			{
		    		this.m_E5Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E5");
     			}
     			return this.m_E5Image;
     		}
     	}

		public UnityEngine.UI.Image E4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E4Image == null )
     			{
		    		this.m_E4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E4");
     			}
     			return this.m_E4Image;
     		}
     	}

		public UnityEngine.UI.Image E3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E3Image == null )
     			{
		    		this.m_E3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E3");
     			}
     			return this.m_E3Image;
     		}
     	}

		public UnityEngine.UI.Image E2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E2Image == null )
     			{
		    		this.m_E2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E2");
     			}
     			return this.m_E2Image;
     		}
     	}

		public UnityEngine.UI.Image E1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E1Image == null )
     			{
		    		this.m_E1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E1");
     			}
     			return this.m_E1Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ECommingImage = null;
			this.m_ETipImage = null;
			this.m_E5Image = null;
			this.m_E4Image = null;
			this.m_E3Image = null;
			this.m_E2Image = null;
			this.m_E1Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_ECommingImage = null;
		private UnityEngine.UI.Image m_ETipImage = null;
		private UnityEngine.UI.Image m_E5Image = null;
		private UnityEngine.UI.Image m_E4Image = null;
		private UnityEngine.UI.Image m_E3Image = null;
		private UnityEngine.UI.Image m_E2Image = null;
		private UnityEngine.UI.Image m_E1Image = null;
		public Transform uiTransform = null;
	}
}
