﻿using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AfterCreateSkillHandler: AEvent<AfterCreateSkill>
    {
        protected async override ETTask Run(AfterCreateSkill args)
        {
            ResourcesComponent.Instance.LoadBundle("Effect.unity3d");
            GameObject bundle = (GameObject) ResourcesComponent.Instance.GetAsset("Effect.unity3d", args.unit.Config.EngName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Unit);
            args.unit.AddComponent<GameObjectComponent>().GameObject = gameObject;
            switch ((UnitType) args.unit.Config.Type)
            {
                case UnitType.DrunkardSkill:
                    ConfigDrunkardSkill(gameObject, args.unit);
                    break;
                case UnitType.StoneBoySkill:
                    ConfigStoneBoySkill(gameObject, args.unit);
                    break;
                case UnitType.MasterSkill:
                    ConfigMasterSkill(gameObject, args.unit);
                    break;
            }

            await ETTask.CompletedTask;
        }

        private void ConfigDrunkardSkill(GameObject gameObject, Unit unit)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit hero = unitComponent.Get(unit.GetComponent<FireSkillComponent>().heroId);
            Vector3 pos = hero.GetComponent<GameObjectComponent>().GameObject.transform.position;
            Quaternion rotation = hero.GetComponent<GameObjectComponent>().GameObject.transform.rotation;
            gameObject.transform.localScale = hero.GetComponent<GameObjectComponent>().GameObject.transform.localScale;
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).localScale = hero.GetComponent<GameObjectComponent>().GameObject.transform.localScale;
            }

            gameObject.transform.position = pos + new Vector3(0, 0.5f, 0);
            gameObject.transform.rotation = rotation;
        }

        private void ConfigStoneBoySkill(GameObject gameObject, Unit unit)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit hero = unitComponent.Get(unit.GetComponent<StoneSkillComponent>().heroId);
            Vector3 pos;
            // Log.Info(hero.GetComponent<AttackComponent>().attackEnemy.IsDisposed.ToString());
            // Log.Info(hero.GetComponent<AttackComponent>().skillPosition.ToString());
            // Log.Info(hero.GetComponent<AttackComponent>().attackEnemy.Position.ToString());
            pos = (hero.GetComponent<AttackComponent>().attackEnemy != null && hero.GetComponent<AttackComponent>().attackEnemy.IsDisposed)
                    ? hero.GetComponent<AttackComponent>().skillPosition
                    : hero.GetComponent<AttackComponent>().attackEnemy.Position;
            pos = TransformConvert.ConvertPositon(unit, pos);
            gameObject.transform.position = pos;
        }

        private void ConfigMasterSkill(GameObject gameObject, Unit unit)
        {
            Vector3 pos;
            pos = TransformConvert.ConvertPositon(unit, unit.Position);
            gameObject.transform.position = pos + new Vector3(0, 4, 0);
        }
    }
}