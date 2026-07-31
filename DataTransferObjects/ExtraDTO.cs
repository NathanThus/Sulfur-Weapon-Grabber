using System;
using System.Collections.Generic;
using System.Diagnostics;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.CharacterStats;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Stats;
using PerfectRandom.Sulfur.Core.Weapons;

[Serializable]
public class ExtraDTO : BaseDTO
{
    public int shotsToReachFullSpread;
    public float timeToCooldownSpread;
    public float DurabilityLossMultiplier;
    public int InventorySizeX;
    public int InventorySizeY;
    public float cooldown;
    public float cooldownBeforeReload;
    public float SpreadStrength;
    public string ProjectileType;
    public string DamageType;

    
    public static ExtraDTO SetExtraWeaponStats(Weapon weapon, ValueHelpers helpers)
    {
        return new ExtraDTO
        {
            shotsToReachFullSpread = weapon.weaponDefinition.shotsToReachFullSpread,
            timeToCooldownSpread = weapon.weaponDefinition.timeToCooldownSpread,
            DurabilityLossMultiplier = weapon.inventoryItem.DurabilityLossMultiplier,
            InventorySizeX = weapon.inventoryItem.InventorySize.x,
            InventorySizeY = weapon.inventoryItem.InventorySize.y,
            cooldown = weapon.cooldown,
            cooldownBeforeReload = weapon.cooldownBeforeReload,
            SpreadStrength = weapon.SpreadStrength,
            ProjectileType = EnumConversion.ProjectileTypeToString(weapon.ProjectileType),
            DamageType = weapon.GetDamageType().ToString(),
        };
    }
    public static ExtraDTO SetExtraMeleeStats(Weapon weapon, ValueHelpers helpers)
    {
        return new ExtraDTO
        {
            InventorySizeX = weapon.inventoryItem.InventorySize.x,
            InventorySizeY = weapon.inventoryItem.InventorySize.y,
            DamageType = weapon.GetDamageType().ToString()
        };
    }
    public static ExtraDTO SetExtraThrowableStats(Weapon weapon, ValueHelpers helpers)
    {
        return new ExtraDTO
        {
            InventorySizeX = weapon.inventoryItem.InventorySize.x,
            InventorySizeY = weapon.inventoryItem.InventorySize.y,
            ProjectileType = EnumConversion.ProjectileTypeToString(weapon.ProjectileType),
            DamageType = weapon.GetDamageType().ToString()
        };
    }
}