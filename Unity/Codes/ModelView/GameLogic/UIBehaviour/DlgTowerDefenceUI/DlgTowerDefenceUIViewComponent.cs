
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgTowerDefenceUIViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_MyHpShakeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MyHpShakeImage == null )
     			{
		    		this.m_E_MyHpShakeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MyHpShake");
     			}
     			return this.m_E_MyHpShakeImage;
     		}
     	}

		public UnityEngine.UI.Image E_EnemyHpShakeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnemyHpShakeImage == null )
     			{
		    		this.m_E_EnemyHpShakeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_EnemyHpShake");
     			}
     			return this.m_E_EnemyHpShakeImage;
     		}
     	}

		public UnityEngine.RectTransform EGSprite_HeroComboundRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGSprite_HeroComboundRectTransform == null )
     			{
		    		this.m_EGSprite_HeroComboundRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGSprite_HeroCombound");
     			}
     			return this.m_EGSprite_HeroComboundRectTransform;
     		}
     	}

		public ES_TopInfo ES_TopInfo
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_topinfo == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_TopInfo");
		    	   this.m_es_topinfo = this.AddChild<ES_TopInfo,Transform>(subTrans);
     			}
     			return this.m_es_topinfo;
     		}
     	}

		public ES_ButtomInfo ES_ButtomInfo
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_buttominfo == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ButtomInfo");
		    	   this.m_es_buttominfo = this.AddChild<ES_ButtomInfo,Transform>(subTrans);
     			}
     			return this.m_es_buttominfo;
     		}
     	}

		public UnityEngine.UI.Button EButton_CreateHero_PvpButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateHero_PvpButton == null )
     			{
		    		this.m_EButton_CreateHero_PvpButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_CreateHero_Pvp");
     			}
     			return this.m_EButton_CreateHero_PvpButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_CreateHero_PvpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateHero_PvpImage == null )
     			{
		    		this.m_EButton_CreateHero_PvpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_CreateHero_Pvp");
     			}
     			return this.m_EButton_CreateHero_PvpImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_CreateHeroButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateHeroButton == null )
     			{
		    		this.m_EButton_CreateHeroButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_CreateHero");
     			}
     			return this.m_EButton_CreateHeroButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_CreateHeroImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateHeroImage == null )
     			{
		    		this.m_EButton_CreateHeroImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_CreateHero");
     			}
     			return this.m_EButton_CreateHeroImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_CostText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_CostText == null )
     			{
		    		this.m_ELabel_CostText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_CreateHero/ELabel_Cost");
     			}
     			return this.m_ELabel_CostText;
     		}
     	}

		public ES_BattleInfo ES_BattleInfo
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_battleinfo == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_BattleInfo");
		    	   this.m_es_battleinfo = this.AddChild<ES_BattleInfo,Transform>(subTrans);
     			}
     			return this.m_es_battleinfo;
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

		public UnityEngine.UI.Text ELabel_BackToMainText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_BackToMainText == null )
     			{
		    		this.m_ELabel_BackToMainText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_BackToMain/ELabel_BackToMain");
     			}
     			return this.m_ELabel_BackToMainText;
     		}
     	}

		public ES_BossComming ES_BossComming
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_bosscomming == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_BossComming");
		    	   this.m_es_bosscomming = this.AddChild<ES_BossComming,Transform>(subTrans);
     			}
     			return this.m_es_bosscomming;
     		}
     	}

		public ES_BattltStart ES_BattltStart
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_battltstart == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_BattltStart");
		    	   this.m_es_battltstart = this.AddChild<ES_BattltStart,Transform>(subTrans);
     			}
     			return this.m_es_battltstart;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_MyHpShakeImage = null;
			this.m_E_EnemyHpShakeImage = null;
			this.m_EGSprite_HeroComboundRectTransform = null;
			this.m_es_topinfo?.Dispose();
			this.m_es_topinfo = null;
			this.m_es_buttominfo?.Dispose();
			this.m_es_buttominfo = null;
			this.m_EButton_CreateHero_PvpButton = null;
			this.m_EButton_CreateHero_PvpImage = null;
			this.m_EButton_CreateHeroButton = null;
			this.m_EButton_CreateHeroImage = null;
			this.m_ELabel_CostText = null;
			this.m_es_battleinfo?.Dispose();
			this.m_es_battleinfo = null;
			this.m_EButton_BackToMainButton = null;
			this.m_EButton_BackToMainImage = null;
			this.m_ELabel_BackToMainText = null;
			this.m_es_bosscomming?.Dispose();
			this.m_es_bosscomming = null;
			this.m_es_battltstart?.Dispose();
			this.m_es_battltstart = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_MyHpShakeImage = null;
		private UnityEngine.UI.Image m_E_EnemyHpShakeImage = null;
		private UnityEngine.RectTransform m_EGSprite_HeroComboundRectTransform = null;
		private ES_TopInfo m_es_topinfo = null;
		private ES_ButtomInfo m_es_buttominfo = null;
		private UnityEngine.UI.Button m_EButton_CreateHero_PvpButton = null;
		private UnityEngine.UI.Image m_EButton_CreateHero_PvpImage = null;
		private UnityEngine.UI.Button m_EButton_CreateHeroButton = null;
		private UnityEngine.UI.Image m_EButton_CreateHeroImage = null;
		private UnityEngine.UI.Text m_ELabel_CostText = null;
		private ES_BattleInfo m_es_battleinfo = null;
		private UnityEngine.UI.Button m_EButton_BackToMainButton = null;
		private UnityEngine.UI.Image m_EButton_BackToMainImage = null;
		private UnityEngine.UI.Text m_ELabel_BackToMainText = null;
		private ES_BossComming m_es_bosscomming = null;
		private ES_BattltStart m_es_battltstart = null;
		public Transform uiTransform = null;
	}
}
