using System;
using System.Collections.Generic;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Stats;

[Serializable]
public class WeaponDTO
{
    public string name;
    public float caliberDamage;
    public float innateDamageMultiplier;
    public float weaponTypeMultiplier;
    public float numberOfProjectiles;
    public float reloadTime;
    public float roundsPerMinute;
    public bool usesGravity = true;
    public float spread;
    public float ammoMax;
    public float ammoPershot;
    public float bulletSpeed;
    public float recoil9mm;
    public float recoil556;
    public float recoil762;
    public float recoil50bmg;
    public float recoil12ga;
    public float recoilEnergy = 0;
    public float weight;
    public float loudness;
    public float calculatedWeaponDamage;
    public string baseCaliber;
}
