using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Stats;

public static class EnumConversion
{
    public static string ProjectileTypeToString(ProjectileTypes type) => type switch
    {
        ProjectileTypes.None => "None",
        ProjectileTypes.Bullet => "Bullet",
        ProjectileTypes.Arrow => "Arrow",
        ProjectileTypes.Laser => "Laser",
        ProjectileTypes.RPG => "RPG",
        ProjectileTypes.Spell => "Spell",
        ProjectileTypes.Custom => "Custom",
        ProjectileTypes.End => "End",
        _ => "Unknown"
    };

    public static string WeaponClassToString(WeaponTypes type) => type switch
    {
        WeaponTypes.None => "None",
        WeaponTypes.AssaultRifle => "AssaultRifle",
        WeaponTypes.Bow => "Bow",
        WeaponTypes.LMG => "LMG",
        WeaponTypes.Melee => "Melee",
        WeaponTypes.Pistol => "Pistol",
        WeaponTypes.Revolver => "Revolver",
        WeaponTypes.Rifle => "Rifle",
        WeaponTypes.Shotgun => "Shotgun",
        WeaponTypes.SMG => "SMG",
        WeaponTypes.Sniper => "Sniper",
        WeaponTypes.Throwable => "Throwable",
        WeaponTypes.End => "End",
        _ => "Unknown",
    };

    public static string CaliberTypeToString(CaliberTypes type) => type switch
    {
        CaliberTypes.None => "None",
        CaliberTypes._9mm => "9mm",
        CaliberTypes._12ga => "12Ga",
        CaliberTypes._556mm => "5.56mm",
        CaliberTypes._762mm => "7.62mm",
        CaliberTypes._50BMG => ".50 BMG",
        CaliberTypes.Arrow => "Arrow",
        CaliberTypes.Laser => "Energy Cell",
        CaliberTypes.Shrapnel => "Shrapnel",
        CaliberTypes.End => "End",
        _ => "Unknown"
    };

    public static string DamageTypeToString(DamageTypes type) => type switch
    {
        DamageTypes.None => "None",
        DamageTypes.Critical => "Critical",
        DamageTypes.Electric => "Electric",
        DamageTypes.Explosive => "Explosive",
        DamageTypes.Fire => "Fire",
        DamageTypes.Frost => "Frost",
        DamageTypes.Holy => "Holy",
        DamageTypes.Normal => "Normal",
        DamageTypes.Physics => "Physics",
        DamageTypes.Poison => "Poison",
        DamageTypes.Punish => "Punish",
        DamageTypes.Shadow => "Shadow",
        DamageTypes.Suffocate => "Suffocate",
        DamageTypes.Water => "Water",
        DamageTypes.Sacrifice => "Sacrifice",
        DamageTypes.Dark => "Dark",
        DamageTypes.Bleed => "Bleed",
        DamageTypes.End => "End",
        _ => "Unknown"
    };
}