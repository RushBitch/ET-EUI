using UnityEngine;

namespace ET
{
    namespace EventType
    {
        public struct MyAppStart
        {
        }

        public struct MyAppStartInitFinish
        {
        }

        public struct CreateZoneScene
        {
        }

        public struct MyAfterCreateZoneScene
        {
            public Scene zoneScene;
        }

        public struct CreateTowerDefenceSolo
        {
            public Scene zoneScene;
            public long myId;
        }

        public struct CreateTowerDefencePvp
        {
            public Scene zoneScene;
            public long myId;
            public long opponentId;
        }

        public struct CreateTowerDefenceTeam
        {
            public Scene zoneScene;
            public long myId;
            public long opponentId;
            public long myIndex;
            public long opponentIndex;
        }

        public struct AfterCreateTowerDefence
        {
            public TowerDefenceCompoment towerDefenceCompoment;
        }
        
        public struct StartNextRound
        {
            public Scene scene;
        }

        public struct FinishCreateTowerDefence
        {
            public TowerDefenceCompoment towerDefenceCompoment;
        }

        public struct AfterCreateEnemy
        {
            public Unit unit;
        }

        public struct AfterCreateHero
        {
            public Unit unit;
        }

        public struct AfterCreateWeapon
        {
            public Unit unit;
        }

        public struct ChangeHeroPosition
        {
            public Unit unit;
        }

        public struct UnitAttacked
        {
            public Unit unit;
            public int damage;
        }

        public struct CleanMaxMoveDistance
        {
            public Unit unit;
        }

        public struct HeroAttackBefore
        {
            public Unit unit;
        }

        public struct HeroAttackAfter
        {
            public Unit unit;
        }

        public struct HeroSkillBefore
        {
            public Unit unit;
        }

        public struct HeroExecuteAttack
        {
            public Unit unit;
        }

        public struct HeroEnterSkillReady
        {
            public Unit unit;
        }

        public struct HeroExecuteSkill
        {
            public Unit unit;
        }

        public struct HeroSkillAfter
        {
            public Unit unit;
        }

        public struct EnemyKilledByHero
        {
            public long id;
        }

        public struct AfterCreateSkill
        {
            public Unit unit;
        }

        public struct AfterEnemyDead
        {
            public Unit unit;
        }

        public struct SpawnReverseEnemy
        {
            public Unit unit;
        }
        
        public struct AfterDestroyWeapon
        {
            public Unit unit;
        }

        public struct PlayerEffect
        {
            public Vector3 pos;
            public int effectId;
            public int effectTime;
        }

        public struct EnemySpeedBuffStart
        {
            public Unit unit;
        }

        public struct EnemySpeedBuffEnd
        {
            public Unit unit;
        }

        public struct HeroStartIdelState
        {
            public Unit unit;
        }

        public struct StopBattle
        {
            public long TowerDecenceId;
        }
        
        public struct AfterStopBattle
        {
            public long TowerDecenceId;
        }

        public struct AfterCompoundHero
        {
            public long towerDefenceId;
            public long heroType;
        }

        public struct MyLoginFinished
        {
            
        }
        
        public struct MyLoginFail
        {
            
        }
    }
}