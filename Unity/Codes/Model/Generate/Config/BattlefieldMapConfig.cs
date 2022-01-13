using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class BattlefieldMapConfigCategory : ProtoObject
    {
        public static BattlefieldMapConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, BattlefieldMapConfig> dict = new Dictionary<int, BattlefieldMapConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<BattlefieldMapConfig> list = new List<BattlefieldMapConfig>();
		
        public BattlefieldMapConfigCategory()
        {
            Instance = this;
        }
		
        public override void EndInit()
        {
            foreach (BattlefieldMapConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public BattlefieldMapConfig Get(int id)
        {
            this.dict.TryGetValue(id, out BattlefieldMapConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (BattlefieldMapConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, BattlefieldMapConfig> GetAll()
        {
            return this.dict;
        }

        public BattlefieldMapConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class BattlefieldMapConfig: ProtoObject, IConfig
	{
		[ProtoMember(1)]
		public int Id { get; set; }
		[ProtoMember(3)]
		public string row1 { get; set; }
		[ProtoMember(4)]
		public string row2 { get; set; }
		[ProtoMember(5)]
		public string row3 { get; set; }
		[ProtoMember(6)]
		public string row4 { get; set; }
		[ProtoMember(7)]
		public string row5 { get; set; }
		[ProtoMember(8)]
		public string row6 { get; set; }
		[ProtoMember(9)]
		public string row7 { get; set; }
		[ProtoMember(10)]
		public string row8 { get; set; }
		[ProtoMember(11)]
		public string row9 { get; set; }
		[ProtoMember(12)]
		public string row10 { get; set; }
		[ProtoMember(13)]
		public string row11 { get; set; }

	}
}
