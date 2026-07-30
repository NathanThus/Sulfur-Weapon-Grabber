using System;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Weapons;

[Serializable]
public class ThrowableDTO : BaseDTO
{
    public static ThrowableDTO CreateThrowableDTO(Weapon weapon, ValueHelpers helpers)
    {
        ModifiableHelper modifiableHelper = new();
        return new ThrowableDTO
        {
            Name = weapon.weaponDefinition.LocalizedDisplayName,
            Core = CoreDTO.SetCoreThrowableStats(weapon, helpers),
            Modifiable = modifiableHelper.GetModifiableStats(weapon),
            Extra = ExtraDTO.SetExtraThrowableStats(weapon, helpers)
        };
    }
}