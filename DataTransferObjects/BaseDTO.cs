using System;
using System.Collections.Generic;
using PerfectRandom.Sulfur.Core.Weapons;

[Serializable]
public class BaseDTO
{
    public string Name;
    public string displayName;
    public string weaponType;
    public string LocalizedFlavor;
    public CoreDTO Core;
    public Dictionary<string, float> Modifiable;
    public ExtraDTO Extra;
}