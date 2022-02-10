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
    }
}