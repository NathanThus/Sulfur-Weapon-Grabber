using System;
using PerfectRandom.Sulfur.Core.Items;

[Serializable]
public class MeleeDTO : BaseDTO
{
    public static MeleeDTO CreateMeleeDTO(WeaponSO weaponSO)
    {
        return new MeleeDTO
        {
            name = weaponSO.name,
            displayName = weaponSO.displayName,
            weaponType = EnumConversion.WeaponClassToString(weaponSO.weaponType)
        };
    }
}