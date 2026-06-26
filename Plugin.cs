using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using BepInEx;
using BepInEx.Logging;
using Newtonsoft.Json;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.CharacterStats;
using PerfectRandom.Sulfur.Core.Items;
using UnityEngine;

namespace WeaponDataGrabber;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    CaliberType[] Caliberdatabase;
    List<ItemDefinition> weaponDatabase;
    private IEnumerator Start()
    {
        while (!StaticInstance<AsyncAssetLoading>.Instance.loadingDone)
        {
            yield return null;
        }

        weaponDatabase = StaticInstance<AsyncAssetLoading>.Instance.itemDatabase.GetRawList();
        if (weaponDatabase == null)
        {
            Logger.LogError("Database not found");
            throw new ArgumentNullException(nameof(weaponDatabase));
        }
        
        Caliberdatabase = StaticInstance<AsyncAssetLoading>.Instance.assetSets.caliberTypes;
        if (Caliberdatabase == null)
        {
            Logger.LogError("Database not found");
            throw new ArgumentNullException(nameof(Caliberdatabase));
        }

        List<WeaponDTO> weaponList = [];
        Logger.LogError(weaponDatabase.Count);

        foreach (var itemDef in weaponDatabase)
        {
            if (itemDef?.HasRank != true)
            {
                continue;
            }
            if (itemDef is WeaponSO)
            {
                var weaponSO = itemDef as WeaponSO;
                weaponList.Add(new WeaponDTO
                {
                    name = weaponSO.displayName,
                    caliberDamage = Caliberdatabase[(int)weaponSO.caliber].baseDamage,
                    innateDamageMultiplier = weaponSO.damageMultiplier,
                    weaponTypeMultiplier = WeaponTypeDataExt.GetDamageMultiplier(weaponSO.weaponType)
                });
            }
        }

        string json = JsonConvert.SerializeObject(weaponList, Formatting.Indented);

        string path = Path.Combine(Paths.GameRootPath, nameof(weaponList) + ".json");
        File.WriteAllText(path, json);
    }

    // TBD
    private float CalculateDamage(WeaponSO weaponSO)
    {
        return Caliberdatabase[(int)weaponSO.caliber].baseDamage * WeaponTypeDataExt.GetDamageMultiplier(weaponSO.weaponType) * weaponSO.damageMultiplier;
    }
}
