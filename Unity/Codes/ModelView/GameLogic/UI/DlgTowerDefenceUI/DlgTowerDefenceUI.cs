using DG.Tweening;

namespace ET
{
	public  class DlgTowerDefenceUI :Entity,IAwake
	{

		public DlgTowerDefenceUIViewComponent View { get => this.Parent.GetComponent<DlgTowerDefenceUIViewComponent>();}
		public bool switchState = true;
		public Sequence Sequence = null;
		public bool canCreateHero = true;
	}
}
