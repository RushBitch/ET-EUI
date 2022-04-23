using ET.EventType;

namespace ET
{
    public class LoginFailHandler:AEvent<MyLoginFail>
    {
        protected override async ETTask Run(MyLoginFail a)
        {
            Log.Info("登录失败了！！！");
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            UIBaseWindow dWindow;
            scene.GetComponent<UIComponent>().VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_MenuUI, out dWindow);
            if (dWindow != null)
            {
                dWindow.GetComponent<DlgMenuUI>().View.EButton_Pvp.gameObject.SetActive(true);
            }

            await ETTask.CompletedTask;
        }
    }
}