using System;
using System.Collections.Generic;
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
}
