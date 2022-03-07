namespace ET
{
    public static class PlayerComponentSystem
    {
        public static Player Get(this PlayerComponent self, long id)
        {
            Player unit = self.GetChild<Player>(id);
            return unit;
        }

        public static void Remove(this PlayerComponent self, long id)
        {
            Player unit = self.GetChild<Player>(id);
            unit?.Dispose();
        }
    }
}