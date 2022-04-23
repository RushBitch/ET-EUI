namespace ET
{
	public  class DlgMenuUI :Entity,IAwake
	{

		public DlgMenuUIViewComponent View { get => this.Parent.GetComponent<DlgMenuUIViewComponent>();}

		public bool HadLogin = false;

	}
}
