namespace ET
{
    public enum NumericalType
    {
        Max = 10000,

        Speed = 1000,
        SpeedBase = Speed * 10 + 1,
        SpeedAdd = Speed * 10 + 2,
        SpeedPct = Speed * 10 + 3,
        SpeedFinalAdd = Speed * 10 + 4,
        SpeedFinalPct = Speed * 10 + 5,

        Hp = 1001,
        HpBase = Hp * 10 + 1,

        PreHp = 1002,
        PreHpBase = PreHp * 10 + 1,

        MaxHp = 1003,
        MaxHpBase = MaxHp * 10 + 1,
        MaxHpAdd = MaxHp * 10 + 2,
        MaxHpPct = MaxHp * 10 + 3,
        MaxHpFinalAdd = MaxHp * 10 + 4,
        MaxHpFinalPct = MaxHp * 10 + 5,

        HeroIndex = 1004,
        HeroIndexBase = HeroIndex * 10 + 1,

        HeroDamage = 1005,
        HeroDamageBase = HeroDamage * 10 + 1,

        HeroSpeed = 1006,
        HeroSpeedBase = HeroSpeed * 10 + 1,
        
        TowerDefenceHp = 1007,
        TowerDefenceHpBase = TowerDefenceHp * 10 + 1,
        
        PlayerEnergy = 1008,
        PlayerEnergyBase = PlayerEnergy * 10 + 1,
        
        PlayerBuyCount = 1009,
        PlayerBuyCountBase = PlayerBuyCount * 10 + 1,
        
        AttackToSkillCount = 1010,
        AttackToSkillCountBase = AttackToSkillCount * 10 + 1,
        
        DeltaTimeToSkill = 1011,
        DeltaTimeToSkillBase = DeltaTimeToSkill * 10 + 1,
        
        SkillShowTime = 1012,
        SkillShowTimeBase = SkillShowTime * 10 + 1,
        
        SkillBeforeTime = 1013,
        SkillBeforeTimeBase = SkillBeforeTime * 10 + 1,
        
        SkillAfterTime = 1014,
        SkillAfterTimeBase = SkillAfterTime * 10 + 1,
        
        Level = 1015,
        LevelBase = Level * 10 + 1,
    }
}