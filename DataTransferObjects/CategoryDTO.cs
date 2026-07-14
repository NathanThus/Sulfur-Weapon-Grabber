using System;
using System.Collections.Generic;

[Serializable]
public class CategoryDTO
{
    public Dictionary<string, BaseDTO> Guns;
    public Dictionary<string, BaseDTO> Melee;
    public Dictionary<string, BaseDTO> Throwable;
}