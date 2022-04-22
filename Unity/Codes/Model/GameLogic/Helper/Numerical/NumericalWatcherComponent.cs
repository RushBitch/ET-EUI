using System;
using System.Collections.Generic;

namespace ET
{
	[ObjectSystem]
	public class NumericalWatcherComponentAwakeSystem : AwakeSystem<NumericalWatcherComponent>
	{
		public override void Awake(NumericalWatcherComponent self)
		{
			NumericalWatcherComponent.Instance = self;
			self.Awake();
		}
	}

	
	public class NumericalWatcherComponentLoadSystem : LoadSystem<NumericalWatcherComponent>
	{
		public override void Load(NumericalWatcherComponent self)
		{
			self.Load();
		}
	}

	/// <summary>
	/// 监视数值变化组件,分发监听
	/// </summary>
	public class NumericalWatcherComponent : Entity, IAwake, ILoad
	{
		public static NumericalWatcherComponent Instance { get; set; }
		
		private Dictionary<NumericalType, List<INumericalWatcher>> allWatchers;

		public void Awake()
		{
			this.Load();
		}

		public void Load()
		{
			this.allWatchers = new Dictionary<NumericalType, List<INumericalWatcher>>();

			HashSet<Type> types = Game.EventSystem.GetTypes(typeof(NumericalWatcherAttribute));
			foreach (Type type in types)
			{
				object[] attrs = type.GetCustomAttributes(typeof(NumericalWatcherAttribute), false);

				foreach (object attr in attrs)
				{
					NumericalWatcherAttribute numericalWatcherAttribute = (NumericalWatcherAttribute)attr;
					INumericalWatcher obj = (INumericalWatcher)Activator.CreateInstance(type);
					if (!this.allWatchers.ContainsKey(numericalWatcherAttribute.NumericalType))
					{
						this.allWatchers.Add(numericalWatcherAttribute.NumericalType, new List<INumericalWatcher>());
					}
					this.allWatchers[numericalWatcherAttribute.NumericalType].Add(obj);
				}
			}
		}

		public void Run(NumericalType numericalType, long id, long value)
		{
			if (Game.Scene.IsDisposed) return;
			List<INumericalWatcher> list;
			if (!this.allWatchers.TryGetValue(numericalType, out list))
			{
				return;
			}
			foreach (INumericalWatcher numericalWatcher in list)
			{
				numericalWatcher.Run(id, value);
			}
		}
	}
}