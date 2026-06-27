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
                var caliberEntry = grabber.GetCaliberEntry(weaponSO);

                weaponList.Add(new WeaponDTO
                {
                    name = weaponSO.name,
                    displayName = weaponSO.displayName,
                    baseCaliber = EnumConversion.CaliberTypeToString(weaponSO.caliber),
                    baseCaliberDamagePerProjectile = caliberEntry.baseDamage,
                    innateDamageMultiplier = weaponSO.damageMultiplier,
                    weaponTypeMultiplier = WeaponTypeDataExt.GetDamageMultiplier(weaponSO.weaponType),
                    calculatedWeaponDamagePerProjectile = helper.CalculatedBaseWeaponDamage(weaponSO, caliberEntry.baseDamage),
                    numberOfProjectiles = caliberEntry.numberOfProjectiles,
                    roundsPerMinute = weaponSO.rpm,
                    spread = helper.GetCaliberSpread(weaponSO.spreadPerCaliber),
                    recoil = helper.GetCaliberRecoil(weaponSO.kickPower),
                    magazineSize = weaponSO.iAmmoMax,
                    ammoPerShot = weaponSO.iMaxAmmoPerShot,
                    bulletSpeed = weaponSO.bulletSpeed,
                    weightClass = weaponSO.weightClass,
                    //weaponWeight = protectedHelpers.ExposeWeightClassConversion(weaponSO.
                    shotsToReachFullSpread = weaponSO.shotsToReachFullSpread,
                    timeToCooldownSpread = weaponSO.timeToCooldownSpread,
                    damageType = EnumConversion.DamageTypeToString(weaponSO.damageType),
                    projectileType = EnumConversion.ProjectileTypeToString(weaponSO.projectileType),
                    weaponType = EnumConversion.WeaponClassToString(weaponSO.weaponType),
                    deprecated = itemDef.deprecated,
                    itemType = itemDef.ItemType
                });
            }
        }

        string json = JsonConvert.SerializeObject(weaponList, Formatting.Indented);

        string path = Path.Combine(Paths.GameRootPath, nameof(weaponList) + ".json");
        File.WriteAllText(path, json);
    }
}
