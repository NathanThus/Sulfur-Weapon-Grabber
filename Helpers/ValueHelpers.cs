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
using System.Reflection;

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

    public List<string> IterateCompatibleAttachments(List<ItemDefinition> compatibleAttachments)
    {
        List<string> attachments = [];
        foreach (var att in compatibleAttachments)
        {
            if (attachments.Contains(att.LocalizedDisplayName))
            {
                continue;
            }
            else {
                attachments.Add(att.LocalizedDisplayName);
            }
        }
        return attachments;
    }

    public StatModifier GetRunSpeedMod(Weapon weapon)
    {
        Type targetType = weapon.GetType();
        MethodInfo methodInfo = targetType.GetMethod("GetRunSpeedModifier", 
            BindingFlags.NonPublic | BindingFlags.Instance);

        if (methodInfo != null)
        {
            var speedMod = methodInfo.Invoke(weapon, null); 
            return speedMod as StatModifier;
        }
        else
        {
            Debug.LogError("Method not found!");
            return null;
        } 
    }
    public float GetAimPenalty(Weapon weapon)
    {
        Type targetType = weapon.GetType();
        MethodInfo methodInfo = targetType.GetMethod("get_aimPenalty", 
            BindingFlags.NonPublic | BindingFlags.Instance);

        if (methodInfo != null)
        {
            return (float)methodInfo.Invoke(weapon, null); 
        }
        else
        {
            return 0f;
        } 
    }
    public List<string> GetCompatibleAttachments(Weapon weapon)
    {
        Type targetType = weapon.GetType();
        FieldInfo fieldInfo = targetType.GetField("compatibleAttachments", 
            BindingFlags.NonPublic | BindingFlags.Instance);

        if (fieldInfo != null)
        {
            return IterateCompatibleAttachments(fieldInfo.GetValue(weapon) as List<ItemDefinition>);
        }
        else
        {
            return null;
        } 
    }
    public float GetChargeAmount(Weapon weapon)
    {
        Type targetType = weapon.GetType();
        FieldInfo fieldInfo = targetType.GetField("chargeAmount", 
            BindingFlags.NonPublic | BindingFlags.Instance);

        if (fieldInfo != null)
        {
            return (float)fieldInfo.GetValue(weapon);
        }
        else
        {
            return 0f;
        } 
    }
}