using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
    namespace EventType
    {
        public struct NumericalChange
        {
            public Entity Parent;
            public NumericalType NumericalType;
            public long Old;
            public long New;
        }
    }

    [ObjectSystem]
    public class NumericalComponentAwakeSystem: AwakeSystem<NumericalComponent>
    {
        public override void Awake(NumericalComponent self)
        {
            self.Awake();
        }
    }

    public class NumericalComponent: Entity, IAwake, ITransfer
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, long> NumericDic = new Dictionary<int, long>();

        public void Awake()
        {
            // 这里初始化base值
        }

        public float GetAsFloat(NumericalType numericType)
        {
            return (float) GetByKey((int) numericType) / 10000;
        }

        public float GetAsFloat(int numericType)
        {
            return (float) GetByKey(numericType) / 10000;
        }

        public int GetAsInt(NumericalType numericType)
        {
            return (int) GetByKey((int) numericType);
        }

        public long GetAsLong(NumericalType numericType)
        {
            return GetByKey((int) numericType);
        }

        public int GetAsInt(int numericType)
        {
            return (int) GetByKey(numericType);
        }

        public long GetAsLong(int numericType)
        {
            return GetByKey(numericType);
        }

        public void Set(NumericalType nt, float value)
        {
            this[nt] = (int) (value * 10000);
        }

        public void Set(NumericalType nt, int value)
        {
            this[nt] = value;
        }

        public void Set(NumericalType nt, long value)
        {
            this[nt] = value;
        }

        public long this[NumericalType numericType]
        {
            get
            {
                return this.GetByKey((int) numericType);
            }
            set
            {
                long v = this.GetByKey((int) numericType);
                if (v == value && v != 0)
                {
                    return;
                }

                NumericDic[(int) numericType] = value;

                Update(numericType);
            }
        }

        private long GetByKey(int key)
        {
            long value = 0;
            this.NumericDic.TryGetValue(key, out value);
            return value;
        }

        public void Update(NumericalType numericType)
        {
            if (numericType < NumericalType.Max)
            {
                return;
            }

            int final = (int) numericType / 10;
            int bas = final * 10 + 1;
            int add = final * 10 + 2;
            int pct = final * 10 + 3;
            int finalAdd = final * 10 + 4;
            int finalPct = final * 10 + 5;

            // 一个数值可能会多种情况影响，比如速度,加个buff可能增加速度绝对值100，也有些buff增加10%速度，所以一个值可以由5个值进行控制其最终结果
            // final = (((base + add) * (100 + pct) / 100) + finalAdd) * (100 + finalPct) / 100;
            long old = 0;
            if (this.NumericDic.ContainsKey(final))
            {
                old = this.NumericDic[final];
            }
            else
            {
                this.NumericDic.Add(final, old);
            }

            long result = (long) (((this.GetByKey(bas) + this.GetByKey(add)) * (100 + this.GetAsFloat(pct)) / 100f + this.GetByKey(finalAdd)) *
                (100 + this.GetAsFloat(finalPct)) / 100f);
            this.NumericDic[final] = result;
            Game.EventSystem.Publish(new EventType.NumericalChange()
            {
                Parent = this.Parent, NumericalType = (NumericalType) final, Old = old, New = result
            });
        }
    }
}