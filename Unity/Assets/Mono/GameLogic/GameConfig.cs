namespace ET
{
    public enum GameMode
    {
        Clashmini,
        Animals
    }

    public enum GameView
    {
        Perspective,
        Othro
    }

    public static class GameConfig
    {
        public static GameMode GameMode;
        public static GameView GameView;
    }
}