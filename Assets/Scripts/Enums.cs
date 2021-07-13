using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Enums
{
    public enum Items
    {
        JumpyBoots,
        FlyingFeather,
        Web
    }

    public static Items GetRandomItemEnum()
    {
        return Enum.GetValues(typeof(Items))
             .OfType<Items>()
             .OrderBy(e => Guid.NewGuid())
             .FirstOrDefault();

    }

}
