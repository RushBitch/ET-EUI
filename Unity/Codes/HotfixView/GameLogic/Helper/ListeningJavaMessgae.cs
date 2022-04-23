using ET.EventType;

namespace ET
{
    public static class ListeningJavaMessgae
    {
        public static void Listening(string args)
        {
            Log.Info($"unity监听到java消息：{args}");
            switch (args)
            {
                case "LoginFinished":
                    Game.EventSystem.Publish(new MyLoginFinished());
                    break;
                case "LoginFail":
                    Game.EventSystem.Publish(new MyLoginFail());
                    break;
            }
        }
    }
}