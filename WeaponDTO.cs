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
    public float reloadTime;
    public float roundsPerMinute;
    public bool usesGravity = true;
    public float spread;
    public float ammoMax;
    public float ammoPershot;
    public float bulletSpeed;
    public float recoil;
    public float weight;
    public float loudness;
}
