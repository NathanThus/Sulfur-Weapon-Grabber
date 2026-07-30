using System;
using System.Collections.Generic;
using System.Diagnostics;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.CharacterStats;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Stats;
using PerfectRandom.Sulfur.Core.Weapons;
using UnityEngine;

[Serializable]
public class CoreDTO : BaseDTO
{
    public string baseCaliber;
    public float damageMultiplier;
    public float weaponTypeMultiplier;
    public float totalDamageMultiplier;
    public float Damage;
    public float magazineSize;
    public float ammoPerShot;
    public float bulletSpeed;
    public string damageType;
    public string projectileType;
    public float loudness;
    public HoldableWeightClass weightClass;
    public double RunSpeedModifier;
    public Dictionary<string, float> caliberSpread;
    public Dictionary<string, float> caliberRecoil;
    public float computedSpread;
    public int priceBuy;
    public int priceSell;
    public List<string> CompatibleAttachments;
    public float ParryAngle;
    public int meleeHitsGiven;
    public int MeleeHitsPerAttackMax;
    public int maxParries;
    public string typeToParry;


    public static CoreDTO SetCoreWeaponStats(Weapon weapon, ValueHelpers helpers)
    {
        return new CoreDTO
        {
            baseCaliber = EnumConversion.CaliberTypeToString(weapon.Caliber),
            Damage = weapon.Damage,
            damageMultiplier = weapon.weaponDefinition.damageMultiplier,
            weaponTypeMultiplier = WeaponTypeDataExt.GetDamageMultiplier(weapon.weaponDefinition.weaponType),
            totalDamageMultiplier = weapon.weaponDefinition.damageMultiplier * WeaponTypeDataExt.GetDamageMultiplier(weapon.weaponDefinition.weaponType),
            weaponType = EnumConversion.WeaponClassToString(weapon.weaponDefinition.weaponType),
            bulletSpeed = weapon.bulletSpeed,
            weightClass = weapon.weaponDefinition.weightClass,
            magazineSize = weapon.weaponDefinition.iAmmoMax,
            ammoPerShot = weapon.weaponDefinition.iMaxAmmoPerShot,
            caliberSpread = helpers.GetCaliberSpread(weapon.weaponDefinition.spreadPerCaliber),
            caliberRecoil = helpers.GetCaliberRecoil(weapon.weaponDefinition.kickPower),
            computedSpread = weapon.computedSpread,
            priceBuy = weapon.inventoryItem.PriceBuy,
            priceSell = weapon.inventoryItem.PriceSell,
            RunSpeedModifier = Math.Round(helpers.GetRunSpeedMod(weapon).Value, 2),
            CompatibleAttachments = helpers.GetCompatibleAttachments(weapon),
        };
    }

    public static CoreDTO SetCoreMeleeStats(Weapon weapon, ValueHelpers helpers)
    {
        return new CoreDTO
        {
            Damage = weapon.Damage,
            weaponType = EnumConversion.WeaponClassToString(weapon.weaponDefinition.weaponType),
            weightClass = weapon.weaponDefinition.weightClass,
            priceBuy = weapon.inventoryItem.PriceBuy,
            priceSell = weapon.inventoryItem.PriceSell,
            RunSpeedModifier = Math.Round(helpers.GetRunSpeedMod(weapon).Value, 2),
            ParryAngle = weapon.ParryAngle,
            meleeHitsGiven = weapon.meleeHitsGiven,
            MeleeHitsPerAttackMax = weapon.MeleeHitsPerAttackMax,
            maxParries = weapon.weaponDefinition.maxParries,
            typeToParry = weapon.weaponDefinition.typeToParry.ToString()
        };
    }
    public static CoreDTO SetCoreThrowableStats(Weapon weapon, ValueHelpers helpers)
    {
        return new CoreDTO
        {
            Damage = weapon.Damage,
            weaponType = EnumConversion.WeaponClassToString(weapon.weaponDefinition.weaponType),
            weightClass = weapon.weaponDefinition.weightClass,
            priceBuy = weapon.inventoryItem.PriceBuy,
            priceSell = weapon.inventoryItem.PriceSell,
            RunSpeedModifier = Math.Round(helpers.GetRunSpeedMod(weapon).Value, 2)
        };
    }
}