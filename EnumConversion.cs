using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.Items;

public static class EnumConversion
{
    public static string ToProjectileTypeString(ProjectileTypes type) => type switch
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

    public static string ToWeaponClassString(WeaponTypes type) => type switch
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
}