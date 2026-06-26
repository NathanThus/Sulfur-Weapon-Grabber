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
}