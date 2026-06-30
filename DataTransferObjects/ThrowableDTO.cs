using System;
using PerfectRandom.Sulfur.Core.Items;

[Serializable]
public class ThrowableDTO : BaseDTO
{
    public static ThrowableDTO CreateThrowableDTO(WeaponSO weaponSO)
    {
        return new ThrowableDTO
        {
            name = weaponSO.name,
            displayName = weaponSO.displayName,
            weaponType = EnumConversion.WeaponClassToString(weaponSO.weaponType)
        };
    }
}