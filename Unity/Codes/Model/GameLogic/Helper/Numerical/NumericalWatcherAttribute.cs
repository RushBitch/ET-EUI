namespace ET
{
	public class NumericalWatcherAttribute : BaseAttribute
	{
		public NumericalType NumericalType { get; }

		public NumericalWatcherAttribute(NumericalType type)
		{
			this.NumericalType = type;
		}
	}
}