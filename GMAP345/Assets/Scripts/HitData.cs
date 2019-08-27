using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HitData
{

    public int hDamage;
    public int sDamage;
    public float knockback;

    public HitData()
    {
        hDamage = 5;
        sDamage = 0;
        knockback = 1f;
    }
}
