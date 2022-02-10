using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class BattlefieldEnemyPathConfigCategory : ProtoObject
    {
        public static BattlefieldEnemyPathConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, BattlefieldEnemyPathConfig> dict = new Dictionary<int, BattlefieldEnemyPathConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<BattlefieldEnemyPathConfig> list = new List<BattlefieldEnemyPathConfig>();
		
        public BattlefieldEnemyPathConfigCategory()
        {
            Instance = this;
        }
		
        public override void EndInit()
        {
            foreach (BattlefieldEnemyPathConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public BattlefieldEnemyPathConfig Get(int id)
        {
            this.dict.TryGetValue(id, out BattlefieldEnemyPathConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (BattlefieldEnemyPathConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, BattlefieldEnemyPathConfig> GetAll()
        {
            return this.dict;
        }

        public BattlefieldEnemyPathConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class BattlefieldEnemyPathConfig: ProtoObject, IConfig
	{
		[ProtoMember(1)]
		public int Id { get; set; }
		[ProtoMember(3)]
		public string path { get; set; }

	}
}
