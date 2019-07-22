using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 10.0f;
    private int damage = 10;
    private float hp = 100;
    private float san = 100;
    private float max_san = 100;


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

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
        return max_san;
    }

    public void sanLoss(float s) {
        san -= s;
    }

    public void max_sanLoss(float s) {
        max_san -= s;
    }
}
