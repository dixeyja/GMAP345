using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatus : ScriptableObject
{
    // Start is called before the first frame update
    private float speed;
    public float baseSpeed;
    public int baseDamage;
    private float hp;
    public float maxHp;
    private float san;
    private float max_san;
    public float base_san;
    private int lightLevel = 0;
    public float attackSpeed = 1.0f;

    public HitData hitData;


    void OnEnable()
    {
        ResetStatus();
    }

    public int getDamage() {
        return hitData.hDamage;
    }

    public void damageUp(int d) {
        hitData.hDamage += d;
    }

    public float getSpeed()
    {
        return speed;
    }

    public void setSpeed(float s) {
        speed = s;
    }

    public float getHp()
    {
        return hp;
    }

    public void HpLoss(int h) {
        hp -= h;
    }

    public float getSan()
    {
        return san;
    }

    public float getMaxHp()
    {
        return maxHp;
    }

    public float getMaxSan() {
        return max_san;
    }

    public float getBaseSan()
    {
        return base_san;
    }

    public void sanLoss(float s) {
        san -= s;
    }

    public void max_sanLoss(float s) {
        max_san -= s;
    }

    public void sanGain(float s) {
        san += s;
        if (san >= max_san)
        {
            san = max_san;
        }
    }
    
    public void hpGain(float f)
    {
        hp += f;
        if (hp >= maxHp)
        {
            hp = maxHp;
        }
    }

    public int GetLightLevel()
    {
        return lightLevel;
    }

    public void ConfigureLightLevel(int i)
    {
        if (lightLevel < i)
        {
            lightLevel = i;
        }
    }

    public void SetLightLevel(int i)
    {
        lightLevel = i;
 
    }

    public float getAttackSpeed()
    {
        return attackSpeed;
    }

    public void setAttackSpeed(float s)
    {
        attackSpeed = s;
    }

    public void ResetStatus()
    {
        speed = baseSpeed;
        hp = maxHp;
        san = base_san;
        max_san = base_san;
        hitData.hDamage = baseDamage;
    }
}
