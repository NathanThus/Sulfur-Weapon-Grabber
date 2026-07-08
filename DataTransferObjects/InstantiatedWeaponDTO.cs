using System;
using System.Collections.Generic;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.CharacterStats;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Stats;
using PerfectRandom.Sulfur.Core.Weapons;
using PerfectRandom.Sulfur.Core.UI;
using PerfectRandom.Sulfur.Core.UI.Inventory;
using UnityEngine;
using I2.Loc;

[Serializable]
public class InstantiatedWeaponDTO : BaseDTO
{
    public string instanceName;
    public bool instanceEnabled;
    public int priceBase;
    public int priceBuy;
    public int priceSell;
    public string caliber;
    public float bulletSpeed;

    public static InstantiatedWeaponDTO CreateInstantiatedWeaponDTO(Weapon weapon)
    {
        Debug.Log(weapon.SourceName);
        Debug.Log(weapon.bulletSpeed);
        if (weapon == null)
        {
            throw new ArgumentNullException(nameof(weapon));
        }

        if (weapon.inventoryItem == null) {
            Debug.Log("InventoryItem is fucked");
        }
        
        //LocalizationManager.GetTranslation("ItemDescriptions/Label_Rank", true, 0, true, false, null, null, true);

        // Defensive: inventoryItem may be null on a freshly-added Holdable component.
        //var instanceName = weapon.inventoryItem?.name ?? weapon.gameObject?.name ?? "Unknown";
        
        return new InstantiatedWeaponDTO
        {
            instanceName = weapon.SourceName,
            //caliber = weapon.Caliber.ToString(),
            priceBase = weapon.inventoryItem.PriceBase,
            //priceBuy = weapon.inventoryItem.PriceBuy,
            //priceSell = weapon.inventoryItem.PriceSell,
            bulletSpeed = weapon.bulletSpeed
        };
    }
}
