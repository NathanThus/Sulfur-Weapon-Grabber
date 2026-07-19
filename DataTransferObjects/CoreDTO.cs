using System;
using System.Collections.Generic;
using System.Diagnostics;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.CharacterStats;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Stats;
using PerfectRandom.Sulfur.Core.Weapons;

[Serializable]
public class CoreDTO : BaseDTO
{
    public string baseCaliber;
    public float innateDamageMultiplier;
    public float weaponTypeMultiplier;
    public float baseCaliberDmgPerProj;
    public float magazineSize;
    public float ammoPerShot;
    public float bulletSpeed;
    public string damageType;
    public string projectileType;
    public float loudness;
    public HoldableWeightClass weightClass;
    public Dictionary<string, float> caliberSpread;
    public Dictionary<string, float> caliberRecoil;
    public float computedSpread;
    public float spreadStrength;
    public int priceBase;
    public int priceBuy;
    public int priceSell;


    public static CoreDTO SetCoreWeaponStats(Weapon weapon, ValueHelpers helpers)
    {
        return new CoreDTO
        {
            baseCaliber = EnumConversion.CaliberTypeToString(weapon.Caliber),
            baseCaliberDmgPerProj = weapon.Damage,
            innateDamageMultiplier = weapon.weaponDefinition.damageMultiplier,
            weaponTypeMultiplier = WeaponTypeDataExt.GetDamageMultiplier(weapon.weaponDefinition.weaponType),
            weaponType = EnumConversion.WeaponClassToString(weapon.weaponDefinition.weaponType),
            bulletSpeed = weapon.bulletSpeed,
            weightClass = weapon.weaponDefinition.weightClass,
            magazineSize = weapon.weaponDefinition.iAmmoMax,
            ammoPerShot = weapon.weaponDefinition.iMaxAmmoPerShot,
            caliberSpread = helpers.GetCaliberSpread(weapon.weaponDefinition.spreadPerCaliber),
            caliberRecoil = helpers.GetCaliberRecoil(weapon.weaponDefinition.kickPower),
            computedSpread = weapon.computedSpread,
            spreadStrength = weapon.SpreadStrength,
            priceBase = weapon.inventoryItem.PriceBase,
            priceBuy = weapon.inventoryItem.PriceBuy,
            priceSell = weapon.inventoryItem.PriceSell,
        };
    }
}