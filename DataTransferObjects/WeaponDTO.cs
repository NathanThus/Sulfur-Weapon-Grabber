using System;
using System.Collections.Generic;
using System.Diagnostics;
using Mono.Cecil.Cil;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.CharacterStats;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Stats;
using PerfectRandom.Sulfur.Core.Weapons;

[Serializable]
public class WeaponDTO : BaseDTO
{
    public string Name;
    public CoreDTO Core;
    public Dictionary<string, float> Modifiable;
    public ExtraDTO Extra;
    //public StatModifier weaponWeight;

    /*public static WeaponDTO CreateWeaponDTO(WeaponSO weaponSO, ValueHelpers helpers)
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
            //weaponWeight = protectedHelpers.ExposeWeightClassConversion(weaponSO.
            shotsToReachFullSpread = weaponSO.shotsToReachFullSpread,
            timeToCooldownSpread = weaponSO.timeToCooldownSpread,
            damageType = EnumConversion.DamageTypeToString(weaponSO.damageType),
            projectileType = EnumConversion.ProjectileTypeToString(weaponSO.projectileType),
            weaponType = EnumConversion.WeaponClassToString(weaponSO.weaponType),
        };
    }*/
    public static WeaponDTO CreateWeaponDTO(Weapon weapon, ValueHelpers helpers)
    {
        ModifiableHelper modifiableHelper = new();
        return new WeaponDTO
        {
            Name = weapon.weaponDefinition.LocalizedDisplayName,
            Core = CoreDTO.SetCoreWeaponStats(weapon, helpers),
            Modifiable = modifiableHelper.GetModifiableStats(weapon),
            Extra = ExtraDTO.SetExtraWeaponStats(weapon, helpers)
        };
    }
}
