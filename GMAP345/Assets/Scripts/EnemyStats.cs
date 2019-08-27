using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyBattleStats : ScriptableObject
{
    public float speed;
    private float hp;
    public float maxHp;

    public HitData hitData;

    private void OnEnable()
    {
        ResetStatus();
    }

    public void HpLoss(int h)
    {
        hp -= h;
    }

    public void HpGain(int h)
    {
        hp += h;
    }

    private void ResetStatus()
    {
        hp = maxHp;
    }
}
