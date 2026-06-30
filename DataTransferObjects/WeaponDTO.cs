using System;
using System.Collections.Generic;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.CharacterStats;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Stats;
using PerfectRandom.Sulfur.Core.Weapons;

[Serializable]
public class WeaponDTO : BaseDTO
{
    public string baseCaliber;
    public float innateDamageMultiplier;
    public float weaponTypeMultiplier;
    public float baseCaliberDmgPerProj;
    public float calculatedWeapDmgPerProj;
    public float numberOfProjectiles;
    public float magazineSize;
    public float roundsPerMinute;
    public Dictionary<string, float> recoil;
    public Dictionary<string, float> spread;
    public float reloadTime;
    public float ammoPerShot;
    public float bulletSpeed;
    public HoldableWeightClass weightClass;
    //public StatModifier weaponWeight;
    public float loudness;
    public int shotsToReachFullSpread;
    public float timeToCooldownSpread;
    public string damageType;
    public string projectileType;

    public static WeaponDTO CreateWeaponDTO(WeaponSO weaponSO, ValueHelpers helpers)
    {
        var caliberEntry = DatabaseGrabber.GetCaliberEntry(weaponSO);

        return new WeaponDTO
        {
            name = weaponSO.name,
            displayName = weaponSO.displayName,
            baseCaliber = EnumConversion.CaliberTypeToString(weaponSO.caliber),
            baseCaliberDmgPerProj = caliberEntry.baseDamage,
            innateDamageMultiplier = weaponSO.damageMultiplier,
            weaponTypeMultiplier = WeaponTypeDataExt.GetDamageMultiplier(weaponSO.weaponType),
            calculatedWeapDmgPerProj = helpers.CalculatedBaseWeaponDamage(weaponSO, caliberEntry.baseDamage),
            numberOfProjectiles = caliberEntry.numberOfProjectiles,
            roundsPerMinute = weaponSO.rpm,
            spread = helpers.GetCaliberSpread(weaponSO.spreadPerCaliber),
            recoil = helpers.GetCaliberRecoil(weaponSO.kickPower),
            magazineSize = weaponSO.iAmmoMax,
            ammoPerShot = weaponSO.iMaxAmmoPerShot,
            bulletSpeed = weaponSO.bulletSpeed,
            weightClass = weaponSO.weightClass,
            //weaponWeight = protectedHelpers.ExposeWeightClassConversion(weaponSO.
            shotsToReachFullSpread = weaponSO.shotsToReachFullSpread,
            timeToCooldownSpread = weaponSO.timeToCooldownSpread,
            damageType = EnumConversion.DamageTypeToString(weaponSO.damageType),
            projectileType = EnumConversion.ProjectileTypeToString(weaponSO.projectileType),
            weaponType = EnumConversion.WeaponClassToString(weaponSO.weaponType),
        };
    }
}
