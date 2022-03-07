using System;
using System.IO;
using System.Text;
using SimpleJson;

namespace ET
{
    public class CreateZoneScene: AEvent<EventType.CreateZoneScene>
    {
        protected override async ETTask Run(EventType.CreateZoneScene a)
        {
            Scene zoneScene = EntitySceneFactory.CreateScene(Game.IdGenerater.GenerateInstanceId(), 1, SceneType.Zone, "Game", Game.Scene);
            zoneScene.AddComponent<ZoneSceneFlagComponent>();
            zoneScene.AddComponent<NetKcpComponent, int>(SessionStreamDispatcherType.SessionStreamDispatcherClientOuter);
            zoneScene.AddComponent<CurrentScenesComponent>();
            zoneScene.AddComponent<ObjectWait>();
            zoneScene.AddComponent<PlayerComponent>();
            zoneScene.AddComponent<UnitComponent>();
            zoneScene.AddComponent<AIDispatcherComponent>();
            NetPcpComponent netPcpComponent =
                    zoneScene.AddComponent<NetPcpComponent, int>(SessionStreamDispatcherType.SessionStreamDispatcherPomelo);
            Session session = netPcpComponent.Create(NetworkHelper.ToIPEndPoint("121.4.31.76:3014"));
            await session.AddComponent<HandShakeServiceComponent>().StartServer();
            gate_gateHandler_queryEnter_Request message = new gate_gateHandler_queryEnter_Request() { uid = "123" };
            gate_gateHandler_queryEnter_Response response = (gate_gateHandler_queryEnter_Response) await session.Call(message);
            session.Dispose();
            Session connectorSession = netPcpComponent.Create(NetworkHelper.ToIPEndPoint($"{response.host}:{response.port} "));
            await connectorSession.AddComponent<HandShakeServiceComponent>().StartServer();
            connectorSession.AddComponent<HeartBeatComponent>();
            connector_entryHandler_enter_Response connectorEntryHandlerEnterResponse =(connector_entryHandler_enter_Response) await connectorSession.Call(new connector_entryHandler_enter_Request() { username = "123",rid = "123"});
            chat_chatHandler_send_Response chatChatHandlerSendResponse = (chat_chatHandler_send_Response)await connectorSession.Call(new chat_chatHandler_send_Request() { content = "aaa", from = "123",target = "*",rid = "123"});

            await Game.EventSystem.PublishAsync(new EventType.MyAfterCreateZoneScene() { zoneScene = zoneScene });
            await ETTask.CompletedTask;
        }
        
        private static int BytesToInt(byte[] src, int offset, int length)
        {
            int value = 0;
            for (int i = offset; i < length - offset; i++)
            {
                value |= ((src[i] & 0xFF) << (i + 1) * 8);
            }

            return value;
        }
    }
}