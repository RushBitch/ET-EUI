namespace ET
{
    public static class PlayerFactory
    {
        public static Player Create(Scene scene, long id)
        {
            Player player = scene.GetComponent<PlayerComponent>().AddChildWithId<Player>(id);
            player.AddComponent<NumericalComponent>();
            return player;
        }
    }
}