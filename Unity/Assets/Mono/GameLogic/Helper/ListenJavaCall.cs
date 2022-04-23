using UnityEngine;

namespace ET
{
    public class ListenJavaCall: MonoBehaviour
    {
        public void Listening(string args)
        {
            MyCodeLoader.Instance.appDomain.Invoke("ET.ListeningJavaMessgae", "Listening", null, args);
        }
    }
}