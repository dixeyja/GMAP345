using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyBattleBehavior : MonoBehaviour
{

    public float speed;
    public Transform playerCharacter;
    //static Animator anim;
    private int health;
    public int maxHealth;
    public combatManager cM;

    private bool alive = true;
    private bool spotted = false;


    // Start is called before the first frame update
    void Start()
    {
        ResetStatus();
        //anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ResetStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(playerCharacter.position, this.transform.position) < 10 && alive)
        {
            Vector3 direction = playerCharacter.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            transform.Translate(0, 0, speed * Time.deltaTime);

            //if (direction.magnitude > 2)
           // {
                //anim.SetBool("isWalking", true);
                //anim.SetBool("isIdle", false);
                //anim.SetBool("isAttacking", false);
                //anim.SetBool("isHit", false);
                //if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                //{
                //    transform.Translate(0, 0, speed * Time.deltaTime);
                //}
                
           // }
            //else
           // {
               // anim.SetBool("isAttacking", true);
               // anim.SetBool("isWalking", false);
               // anim.SetBool("isIdle", false);
                //anim.SetBool("isHit", false);
            //}


        }
        else
        {
            //anim.SetBool("isIdle", true);
            //anim.SetBool("isWalking", false);
            //anim.SetBool("isAttacking", false);
            //anim.SetBool("isHit", false);
        }

        if (health <= 0)
        {
           // anim.SetBool("isDead", true);
            //anim.SetBool("isIdle", false);
            //anim.SetBool("isWalking", false);
           // anim.SetBool("isAttacking", false);
            //anim.SetBool("isHit", false);
            speed = 0;
            if (alive)
            {
                cM.addEnemiesBeat();
                playerCharacter.GetComponent<CharController>().ps.sanGain(10);
                alive = false;
                ResetStatus();
                gameObject.SetActive(false);
            }

        }
        Debug.Log("Enemy Battler Health:" + health.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerWeapon")
        {
            health -= other.GetComponentInParent<CharController>().ps.hitData.hDamage;
            //anim.SetBool("isHit", true);
            //anim.SetBool("isIdle", false);
            //anim.SetBool("isWalking", false);
            //anim.SetBool("isAttacking", false);
            
        }


    }

    private void ResetStatus()
    {
        health = maxHealth;
        alive = true;
    }
}
