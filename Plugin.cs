using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
using PerfectRandom.Sulfur.Core.Units;
using I2.Loc;
using HarmonyLib;
using PerfectRandom.Sulfur.Core.Stats;
using PerfectRandom.Sulfur.Core.UI;
using PerfectRandom.Sulfur.Core.UI.Inventory;

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
    ValueHelpers.PRWrapperWeapon protectedHelpers2 = new();
    private List<ItemDefinition> weaponList = [];
    private EquipmentManager equipmentManager;

    private void Awake()
    {
        var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        harmony.PatchAll(); 
        Debug.Log("Weapon Stats Grabber Loaded and Patches Applied!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }

    //[HarmonyPatch(typeof(ItemStats), "SetBaseAttributes")]
    //[HarmonyPatch([typeof(ItemDefinition)])]
    [HarmonyPatch(typeof(Weapon), "Initialize")]
    public class WeaponStatsInterceptor
    {
        static void Postfix(object __instance)
        {
            Debug.Log("[Mod] Postfix !!!!!!!!!!!!!!!!!!!!!!!!!!! found an item!");
            if (__instance == null) return;
            System.Type instanceType = __instance.GetType();
            FieldInfo[] fields = instanceType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var field in fields)
            {
                Debug.Log($"[Mod] Found Field: {field.Name} = {field.GetValue(__instance)}");
                /*object fieldValue = field.GetValue(__instance);
                if (fieldValue is PerfectRandom.Sulfur.Core.CharacterStats.CharacterStat[] statArray) {
                    foreach (var characterStat in statArray)
                    {
                        if (characterStat != null)
                        {
                            try 
                            {
                                Debug.Log($"[Mod] Found Character Stat Field: {characterStat.BaseValue}");
                            }
                            catch (System.Exception ex)
                            {
                                Debug.LogError($"[Mod] Error reading value: {ex.Message}");
                            }
                        }
                        else 
                        {
                        }
                    }
                }*/
            }
        }
    }
    
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
            if (itemDef?.slotType != SlotType.Weapon & itemDef?.slotType != SlotType.BasicMelee  & itemDef?.slotType != SlotType.Gadget) continue;

            if (itemDef is not WeaponSO) continue;

            var weaponSO = itemDef as WeaponSO;
            BaseDTO returnDTO = GetRelevantDTO(weaponSO);

            if (returnDTO == null) continue;

            weaponList.Add(returnDTO);

            /*var InstancedDTO = InstantiatedWeaponDTO.CreateInstantiatedWeaponDTO(weaponComp);
            weaponList.Add(InstancedDTO);
            Destroy(weaponInstance);*/
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