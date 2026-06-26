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

class ValueHelpers
{
    public float GetCaliberRecoil(List<CaliberKickDefinition> kickPowerList, string caliber)
    {
        foreach (var kick in kickPowerList)
        {
            if (kick.Caliber.ToString() == caliber)
            {
                return kick.KickPower;
            }
        }
        return 0;
    }

    public float CalculatedBaseWeaponDamage(WeaponSO weaponSO, CaliberType[] Caliberdatabase)
    {
        return weaponSO.damageMultiplier * WeaponTypeDataExt.GetDamageMultiplier(weaponSO.weaponType) * Caliberdatabase[(int)weaponSO.caliber].baseDamage;
    }
}