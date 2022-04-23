using ET.EventType;

namespace ET
{
    public class LoginFinishedHandler:AEvent<MyLoginFinished>
    {
        protected override async ETTask Run(MyLoginFinished a)
        {
            Log.Info("登录成功了！！！");
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            UIBaseWindow dWindow;
            scene.GetComponent<UIComponent>().VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_MenuUI, out dWindow);
            if (dWindow != null)
            {
                dWindow.GetComponent<DlgMenuUI>().HadLogin = true;
                dWindow.GetComponent<DlgMenuUI>().View.EButton_Pvp.gameObject.SetActive(true);
            }
            
            await ETTask.CompletedTask;
        }
    }
}