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