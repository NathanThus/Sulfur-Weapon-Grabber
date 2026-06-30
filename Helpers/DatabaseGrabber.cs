using System;
using System.Collections.Generic;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.Items;

class DatabaseGrabber
{
    public List<ItemDefinition> GetListOfItemDefinitions()
    {
        var weaponDatabase = StaticInstance<AsyncAssetLoading>.Instance.itemDatabase.GetRawList();
        if (weaponDatabase == null)
        {
            throw new ArgumentNullException(nameof(weaponDatabase));
        }

        return weaponDatabase;
    }

    public CaliberType[] GetCaliberDatabase()
    {
        var Caliberdatabase = StaticInstance<AsyncAssetLoading>.Instance.assetSets.caliberTypes;
        if (Caliberdatabase == null)
        {
            throw new ArgumentNullException(nameof(Caliberdatabase));
        }

        return Caliberdatabase;
    }

    public ref CaliberType GetCaliberEntry(WeaponSO weaponSO)
    {
        if (weaponSO == null)
        {
            throw new ArgumentNullException(nameof(weaponSO));
        }

        var caliberDatabase = GetCaliberDatabase();
        var index = (int)weaponSO.caliber;

        if (index < 0 || index >= caliberDatabase.Length)
        {
            throw new IndexOutOfRangeException($"Caliber index {index} is out of range.");
        }

        return ref caliberDatabase[index];
    }

}