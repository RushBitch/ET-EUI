using System.Collections.Generic;
using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AfterCreateTowerDefecceHandler: AEvent<AfterCreateTowerDefence>
    {
        protected override async ETTask Run(AfterCreateTowerDefence args)
        {
            ResourcesComponent.Instance.LoadBundle("Enemy.unity3d");
            ResourcesComponent.Instance.LoadBundle("ui.unity3d");
            ResourcesComponent.Instance.LoadBundle("Hero.unity3d");
            ResourcesComponent.Instance.LoadBundle("levelFlag.unity3d");
            ResourcesComponent.Instance.LoadBundle("Effect.unity3d");
            ResourcesComponent.Instance.LoadBundle("Weapon.unity3d");
            ResourcesComponent.Instance.LoadBundle("mat.unity3d");
            ResourcesComponent.Instance.LoadBundle("Map.unity3d");
            ResourcesComponent.Instance.LoadBundle("music.unity3d");
            await Inistance();
            args.towerDefenceCompoment.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_MenuUI);

            UnityEngine.Object bundle = ResourcesComponent.Instance.GetAsset("Map.unity3d", args.towerDefenceCompoment.towerDefenceMode.ToString());
            GameObject gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            args.towerDefenceCompoment.AddComponent<GameObjectComponent>().GameObject = gameObject;
            args.towerDefenceCompoment.AddComponent<HeroCompoundComponent>();
            args.towerDefenceCompoment.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_StartAnimUI);
            args.towerDefenceCompoment.AddComponent<TowerDefenceCameraComponent, GameObject>(GlobalComponent.Instance.Global.Find("MainCamera")
                    .gameObject);
            BgmComponent.Instance.Play(Music.BGM, 0.5f);
            GameObject.Find("cj_2/shuijingtai").transform.localScale = new Vector3(1, 0.2f, 1);
            GameObject.Find("cj_2/shuijingtai (1)").transform.localScale = new Vector3(1, 0.2f, 1);
            await ETTask.CompletedTask;
        }

        private async ETTask Inistance()
        {
            List<GameObject> list = new List<GameObject>();
            UnityEngine.Object bundle = ResourcesComponent.Instance.GetAsset("Enemy.unity3d", UnitType.Boss.ToString());
            GameObject gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Enemy.unity3d", UnitType.Monster.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Hero.unity3d", UnitType.Drunkard.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Hero.unity3d", UnitType.Peot.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Hero.unity3d", UnitType.StoneBoy.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Hero.unity3d", UnitType.Acrobat.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Hero.unity3d", UnitType.Master.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);

            bundle = ResourcesComponent.Instance.GetAsset("Hero.unity3d", UnitType.Buffalo.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);

            bundle = ResourcesComponent.Instance.GetAsset("Hero.unity3d", UnitType.Fox.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Hero.unity3d", UnitType.Rebbit.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);

            bundle = ResourcesComponent.Instance.GetAsset("Weapon.unity3d", UnitType.DrunkardWeapon.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Weapon.unity3d", UnitType.StoneBoyWeapon.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Weapon.unity3d", UnitType.AcrobatWeapon.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Weapon.unity3d", UnitType.MasterWeapon.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Weapon.unity3d", UnitType.PeotWeapon.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Weapon.unity3d", UnitType.StoneBoyWeapon.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Weapon.unity3d", UnitType.FoxWeapon.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Weapon.unity3d", UnitType.RebbitWeapon.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);

            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", "DrunkardSkillEffect");
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", "StoneBoySkillEffect");
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", "NormalTrailEffect");
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", "BuffaloTrailEffect");
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", "FoxTrailEffect");
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", "RebbitTrailEffect");
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", UnitType.DrunkardAttackEffect.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", UnitType.HeroSpawnEffect.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", UnitType.AddAttackSpeedEffect.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", UnitType.AddAttackDamageEffect.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", UnitType.RebbitSkillEffect.ToString());
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", "RebbitSkillWeapon");
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", "MasterSkillEffect");
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);
            bundle = ResourcesComponent.Instance.GetAsset("Effect.unity3d", "StoneBoySkillEffect");
            gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Global);
            //UnityEngine.Object.Destroy(gameObject);
            list.Add(gameObject);

            foreach (var VARIABLE in list)
            {
                VARIABLE.transform.position = new Vector3(0, -100, 0);
            }

            await TimerComponent.Instance.WaitAsync(2000);
            foreach (var VARIABLE in list)
            {
                UnityEngine.Object.Destroy(VARIABLE);
            }

            await ETTask.CompletedTask;
        }
    }
}