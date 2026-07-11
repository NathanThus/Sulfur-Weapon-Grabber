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
using PerfectRandom.Sulfur.Core.Stats;

public class ModifiableHelper
{
    public Dictionary<string, float> GetModifiableStats(Weapon weapon)
    {
        Dictionary<string, float> modifiable = [];
        for (int i = 0; i < weapon.inventoryItem.stats.activeItemAttributes.Count; i++)
            {
                int num = weapon.inventoryItem.stats.activeItemAttributes[i];
                ItemAttribute asset = ((ItemAttributes)num).GetAsset();
                modifiable.Add(asset.GetName(), weapon.inventoryItem.stats.itemAttributes[num].Value);
            }
        return modifiable;
    }
}