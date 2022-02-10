using System;

namespace ET
{
    public static class MyEntry
    {
        public static void Start()
        {
            try
            {
                MyCodeLoader.Instance.Update += Game.Update;
                MyCodeLoader.Instance.LateUpdate += Game.LateUpdate;
                MyCodeLoader.Instance.OnApplicationQuit += Game.Close;
				
				
                Game.EventSystem.Add(MyCodeLoader.Instance.GetTypes());

				
                Game.EventSystem.Publish(new EventType.MyAppStart());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}