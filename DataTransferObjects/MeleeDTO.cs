using System;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Weapons;

[Serializable]
public class MeleeDTO : BaseDTO
{
    public static MeleeDTO CreateMeleeDTO(Weapon weapon)
    {
        return new MeleeDTO
        {
            name = weapon.name,
            displayName = weapon.weaponDefinition.LocalizedDisplayName,
            weaponType = EnumConversion.WeaponClassToString(weapon.weaponDefinition.weaponType)
        };
    }
}