using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitData
{

    public float hDamage;
    public float sDamage;
    public float knockback;

    public HitData()
    {
        hDamage = 5f;
        sDamage = 0f;
        knockback = 0f;
    }
}
