using System;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.Weapons;

[Serializable]
public class MeleeDTO : BaseDTO
{
    public static MeleeDTO CreateMeleeDTO(Weapon weapon, ValueHelpers helpers)
    {
        ModifiableHelper modifiableHelper = new();
        return new MeleeDTO
        {
            Name = weapon.weaponDefinition.LocalizedDisplayName,
            Core = CoreDTO.SetCoreMeleeStats(weapon, helpers),
            Modifiable = modifiableHelper.GetModifiableStats(weapon),
            Extra = ExtraDTO.SetExtraMeleeStats(weapon, helpers)
        };
    }
}