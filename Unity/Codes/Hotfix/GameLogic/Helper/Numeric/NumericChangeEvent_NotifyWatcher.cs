namespace ET
{
	// 分发数值监听
	public class NumericalChangeEvent_NotifyWatcher: AEvent<EventType.NumericalChange>
	{
		protected override async ETTask Run(EventType.NumericalChange args)
		{
			NumericalWatcherComponent.Instance.Run(args.NumericalType, args.Parent.Id, args.New);
			await ETTask.CompletedTask;
		}
	}
}
