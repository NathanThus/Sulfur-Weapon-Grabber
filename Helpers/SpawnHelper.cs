using System;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.UI;
using UnityEngine;

static class SpawnHelper
{
    public static bool IsInLevel()
    {
        try
        {
            GameManager instance = StaticInstance<GameManager>.Instance;
            if (instance == null)
            {
                return false;
            }
            if (instance.gameState != GameState.Running)
            {
                return false;
            }
            if (instance.PlayerUnit == null)
            {
                return false;
            }
            if (StaticInstance<UIManager>.Instance == null)
            {
                return false;
            }
            if (StaticInstance<UIManager>.Instance.PlayerBackpackGrid == null)
            {
                return false;
            }
            if (StaticInstance<UIManager>.Instance.InventoryUI == null)
            {
                return false;
            }
            if (instance.EquipmentManager == null)
            {
                return false;
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static InventoryItem GetItemInWeaponSlot(InventorySlot slot)
    {
        EquipmentManager equipmentManager = GetEquipmentManager();
        if (equipmentManager != null && equipmentManager.EquippedItems.ContainsKey(slot))
        {
            return equipmentManager.EquippedItems[slot];
        }
        return null;
    }

    private static EquipmentManager GetEquipmentManager()
    {
       return StaticInstance<GameManager>.Instance.EquipmentManager;
    }

    public static bool IsWeaponSlotEmpty(InventorySlot slot)
    {
        InventoryItem itemInWeaponSlot = GetItemInWeaponSlot(slot);
        return itemInWeaponSlot == null;
    }

    public static void RemoveGeneratedWeaponSafely(InventoryItem item, string reason)
    {
        if (item == null)
        {
            return;
        }
        try
        {
            item.GetRemovedByExternalFactor(reason);
        }
        catch (Exception ex)
        {
            Debug.LogWarning("Failed to remove generated weapon: " + ex.Message);
        }
    }

    public static InventorySlot ToInventorySlot(SlotType slotType) => slotType switch
    {
        SlotType.Gadget => InventorySlot.Gadget0,
        SlotType.Weapon => InventorySlot.Weapon0,
        SlotType.BasicMelee => InventorySlot.BasicMelee,
        _ => throw new NotImplementedException(nameof(slotType))
    };

    public static void SetupWeaponSpawning()
    {
        GameManager gameManager = StaticInstance<GameManager>.Instance;
        if (gameManager == null) throw new NullReferenceException(nameof(gameManager));
    }
}