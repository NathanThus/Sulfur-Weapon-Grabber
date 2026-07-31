using System;
using PerfectRandom.Sulfur.Core.Weapons;

[Serializable]
public class WeaponDTO : BaseDTO
{
    public static WeaponDTO CreateWeaponDTO(Weapon weapon, ValueHelpers helpers)
    {
        ModifiableHelper modifiableHelper = new();
        return new WeaponDTO
        {
            Name = weapon.weaponDefinition.LocalizedDisplayName,
            Core = CoreDTO.SetCoreWeaponStats(weapon, helpers),
            Modifiable = modifiableHelper.GetModifiableStats(weapon),
            Extra = ExtraDTO.SetExtraWeaponStats(weapon, helpers)
        };
    }
}
