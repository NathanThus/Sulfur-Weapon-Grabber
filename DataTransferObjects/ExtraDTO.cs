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
    
    public static ExtraDTO SetExtraWeaponStats(Weapon weapon, ValueHelpers helpers)
    {
        return new ExtraDTO
        {
            shotsToReachFullSpread = weapon.weaponDefinition.shotsToReachFullSpread,
            timeToCooldownSpread = weapon.weaponDefinition.timeToCooldownSpread,
        };
    }
}