
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgMenuUIViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EButton_Solo
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_Solo == null )
     			{
		    		this.m_EButton_Solo = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Solo");
     			}
     			return this.m_EButton_Solo;
     		}
     	}

		public UnityEngine.UI.Image EButton_SoloImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SoloImage == null )
     			{
		    		this.m_EButton_SoloImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Solo");
     			}
     			return this.m_EButton_SoloImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Solo
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Solo == null )
     			{
		    		this.m_ELabel_Solo = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_Solo/ELabel_Solo");
     			}
     			return this.m_ELabel_Solo;
     		}
     	}

		public UnityEngine.UI.Button EButton_Pvp
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_Pvp == null )
     			{
		    		this.m_EButton_Pvp = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Pvp");
     			}
     			return this.m_EButton_Pvp;
     		}
     	}

		public UnityEngine.UI.Image EButton_PvpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_PvpImage == null )
     			{
		    		this.m_EButton_PvpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Pvp");
     			}
     			return this.m_EButton_PvpImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Pvp
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Pvp == null )
     			{
		    		this.m_ELabel_Pvp = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_Pvp/ELabel_Pvp");
     			}
     			return this.m_ELabel_Pvp;
     		}
     	}

		public UnityEngine.UI.Button EButton_Team
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_Team == null )
     			{
		    		this.m_EButton_Team = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Team");
     			}
     			return this.m_EButton_Team;
     		}
     	}

		public UnityEngine.UI.Image EButton_TeamImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_TeamImage == null )
     			{
		    		this.m_EButton_TeamImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Team");
     			}
     			return this.m_EButton_TeamImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Team
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Team == null )
     			{
		    		this.m_ELabel_Team = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_Team/ELabel_Team");
     			}
     			return this.m_ELabel_Team;
     		}
     	}

		public UnityEngine.UI.Image m_EButton_SoloImage = null;
		public UnityEngine.UI.Button m_EButton_Solo = null;
		public UnityEngine.UI.Text m_ELabel_Solo = null;
		public UnityEngine.UI.Image m_EButton_PvpImage = null;
		public UnityEngine.UI.Button m_EButton_Pvp = null;
		public UnityEngine.UI.Text m_ELabel_Pvp = null;
		public UnityEngine.UI.Image m_EButton_TeamImage = null;
		public UnityEngine.UI.Button m_EButton_Team = null;
		public UnityEngine.UI.Text m_ELabel_Team = null;
		public Transform uiTransform = null;
	}
}
