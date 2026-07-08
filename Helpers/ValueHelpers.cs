using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BepInEx;
using BepInEx.Logging;
using Newtonsoft.Json;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.CharacterStats;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Weapons;
using UnityEngine;

public class ValueHelpers
{
    public Dictionary<string, float> GetCaliberRecoil(List<CaliberKickDefinition> kickPowerList)
    {
        Dictionary<string, float> recoil = [];
        foreach (var kick in kickPowerList)
        {
            recoil.Add(EnumConversion.CaliberTypeToString(kick.Caliber), kick.KickPower);
        }
        return recoil;
    }

    public float CalculatedBaseWeaponDamage(WeaponSO weaponSO, float caliberDamage)
    {
        return weaponSO.damageMultiplier * WeaponTypeDataExt.GetDamageMultiplier(weaponSO.weaponType) * caliberDamage;
    }

    public Dictionary<string, float> GetCaliberSpread(List<SpreadOverrideDefinition> spreadPerCaliber)
    {
        Dictionary<string, float> spread = [];
        foreach (var spr in spreadPerCaliber)
        {
            spread.Add(EnumConversion.CaliberTypeToString(spr.Caliber), spr.Spread);
        }
        return spread;
    }

    public List<string> GetCompatibleAttachments(List<ItemDefinition> compatibleAttachments)
    {
        List<string> attachments = [];
        foreach (var att in compatibleAttachments)
        {
            attachments.Add(att.displayName);
        }
        return attachments;
    }

    public class PRWrapper : Holdable
    {
        public StatModifier ExposeWeightClassConversion(HoldableWeightClass holdableWeightClass)
        {
            return GetRunSpeedModifier();
        }
    }

    public class PRWrapperWeapon : Weapon
    {
        public void SetupWeaponStats(PRWrapperWeapon weapon)
        {
            weapon.SetupStats();
        }
    }
}