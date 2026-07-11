using System;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Weapons;

[Serializable]
public class ThrowableDTO : BaseDTO
{
    public static ThrowableDTO CreateThrowableDTO(Weapon weapon)
    {
        return new ThrowableDTO
        {
            name = weapon.name,
            displayName = weapon.weaponDefinition.LocalizedDisplayName,
            weaponType = EnumConversion.WeaponClassToString(weapon.weaponDefinition.weaponType)
        };
    }
}