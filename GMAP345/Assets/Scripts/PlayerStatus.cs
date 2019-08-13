using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatus : ScriptableObject
{
    // Start is called before the first frame update
    private float speed;
    public float baseSpeed;
    private int damage;
    public int baseDamage;
    private float hp;
    public float maxHp;
    private float san;
    private float max_san;
    public float base_san;
    private int lightLevel = 0;

    void OnEnable()
    {
        ResetStatus();
    }

    public int getDamage() {
        return damage;
    }

    public void damageUp(int d) {
        damage += d;
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

    public float getMaxSan() {
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
        if (san >= base_san)
        {
            san = base_san;
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

    public void ResetStatus()
    {
        speed = baseSpeed;
        hp = maxHp;
        san = base_san;
        max_san = base_san;
    }
}
