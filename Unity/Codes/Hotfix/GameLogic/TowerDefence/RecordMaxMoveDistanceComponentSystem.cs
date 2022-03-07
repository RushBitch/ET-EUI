namespace ET
{
    public static class RecordMaxMoveDistanceComponentSystem
    {
        public static void Record(this RecordMaxMoveDistanceComponent self, Unit unit, float distance)
        {
            if (self.maxDistance > distance) return; 
            if (self.maxDistance <= distance) //&& !unit.GetComponent<LifeComponent>().preDead)
            {
                //Log.Info("{0},{1}", self.maxDistance,distance);
                //Log.Info("有最远距离unit更新{0},unitId:{1}",distance,unit.Id);
                self.maxDistance = distance;
                self.unit = unit;
            }
        }
    }
}