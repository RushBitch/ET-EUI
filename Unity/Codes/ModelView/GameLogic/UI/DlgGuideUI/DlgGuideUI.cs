using System;
using DG.Tweening;

namespace ET
{
	public  class DlgGuideUI :Entity,IAwake
	{

		public DlgGuideUIViewComponent View { get => this.Parent.GetComponent<DlgGuideUIViewComponent>();}
		public Sequence TouchSequence;
	}
}
