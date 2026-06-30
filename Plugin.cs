using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BepInEx;
using BepInEx.Logging;
using Mono.Cecil.Cil;
using Newtonsoft.Json;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.CharacterStats;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Weapons;
using UnityEngine;

namespace WeaponDataGrabber;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    CaliberType[] Caliberdatabase;
    List<ItemDefinition> weaponDatabase;
    DatabaseGrabber grabber = new();
    ValueHelpers helper = new();
    ValueHelpers.PRWrapper protectedHelpers = new();

    private IEnumerator Start()
    {
        while (!StaticInstance<AsyncAssetLoading>.Instance.loadingDone)
        {
            yield return null;
        }

        weaponDatabase = grabber.GetListOfItemDefinitions();
        Caliberdatabase = DatabaseGrabber.GetCaliberDatabase();

        List<BaseDTO> weaponList = [];

        foreach (var itemDef in weaponDatabase)
        {
            if (itemDef?.slotType != SlotType.Weapon & itemDef?.slotType != SlotType.BasicMelee) continue;

            if (itemDef is not WeaponSO) continue;

            var weaponSO = itemDef as WeaponSO;
            BaseDTO returnDTO = GetRelevantDTO(weaponSO);

            if (returnDTO == null) continue;

            weaponList.Add(returnDTO);
        }

        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CustomContractResolver(),
            Formatting = Formatting.Indented
        };

        string json = JsonConvert.SerializeObject(weaponList, settings);

        string path = Path.Combine(Paths.GameRootPath, nameof(weaponList) + ".json");
        File.WriteAllText(path, json);
    }

    private BaseDTO GetRelevantDTO(WeaponSO weaponSO)
    {
        switch (weaponSO?.weaponType)
        {
            case WeaponTypes.Throwable:
                return ThrowableDTO.CreateThrowableDTO(weaponSO);
            case WeaponTypes.Melee:
                return MeleeDTO.CreateMeleeDTO(weaponSO);
            case null:
                return null;
            case WeaponTypes.End:
                return null;
            default: // This covers all guns.
                return WeaponDTO.CreateWeaponDTO(weaponSO, helper);
        }
    }
}
