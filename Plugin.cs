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

namespace WeaponDataGrabber;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    CaliberType[] Caliberdatabase;
    List<ItemDefinition> weaponDatabase;
    DatabaseGrabber grabber = new();

    float RecoilHelper(List<CaliberKickDefinition> kickPowerList, string caliber)
    {
        foreach (var kick in kickPowerList)
        {
            if (kick.Caliber.ToString() == caliber)
            {
                return kick.KickPower;
            }
        }
        return 0;
    }
    private IEnumerator Start()
    {
        while (!StaticInstance<AsyncAssetLoading>.Instance.loadingDone)
        {
            yield return null;
        }

        weaponDatabase = grabber.GetListOfItemDefinitions();
        Caliberdatabase = grabber.GetCaliberDatabase();

        List<WeaponDTO> weaponList = [];

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
                    baseCaliber = EnumConversion.CaliberTypeToString(weaponSO.caliber),
                    caliberDamage = Caliberdatabase[(int)weaponSO.caliber].baseDamage,
                    innateDamageMultiplier = weaponSO.damageMultiplier,
                    weaponTypeMultiplier = WeaponTypeDataExt.GetDamageMultiplier(weaponSO.weaponType),
                    calculatedWeaponDamage = (weaponSO.damageMultiplier * WeaponTypeDataExt.GetDamageMultiplier(weaponSO.weaponType)) * Caliberdatabase[(int)weaponSO.caliber].baseDamage,
                    numberOfProjectiles = Caliberdatabase[(int)weaponSO.caliber].numberOfProjectiles,
                    roundsPerMinute = weaponSO.rpm,
                    spread = weaponSO.Spread,
                    recoil9mm = RecoilHelper(weaponSO.kickPower, "_9mm"),
                    recoil556 = RecoilHelper(weaponSO.kickPower, "_556mm"),
                    recoil762 = RecoilHelper(weaponSO.kickPower, "_762mm"),
                    recoil50bmg = RecoilHelper(weaponSO.kickPower, "_50BMG"),
                    recoil12ga = RecoilHelper(weaponSO.kickPower, "_12ga"),
                });
            }
        }

        string json = JsonConvert.SerializeObject(weaponList, Formatting.Indented);

        string path = Path.Combine(Paths.GameRootPath, nameof(weaponList) + ".json");
        File.WriteAllText(path, json);
    }
}
