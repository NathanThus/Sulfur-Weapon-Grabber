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
}