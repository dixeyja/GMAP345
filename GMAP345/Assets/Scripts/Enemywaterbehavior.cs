using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemywaterbehavior : MonoBehaviour
{
    public string type;
    public float speed;
    public Transform playerCharacter;
    //static Animator anim;
    private int health;
    public int maxHealth;
    public int attackRange;
    public combatManager cM;
    private TurretShooter tShoot;

    private bool alive = true;
    private bool spotted = false;

    private void OnEnable()
    {
        ResetStatus();
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetStatus();
        tShoot = GetComponent<TurretShooter>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(playerCharacter.position, this.transform.position) < 20 && alive)
        {
            Vector3 direction = playerCharacter.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            if (type == "water")
            {
                if (direction.magnitude > attackRange)
                {
                    transform.Translate(0, 0, speed * Time.deltaTime);

                }
                else
                {
                    tShoot.Fire();
                }
            }
            else
            {

                if (direction.magnitude > 1)
                {
                    transform.Translate(0, 0, speed * Time.deltaTime);
                    tShoot.Fire();
                }
                else
                {
                    tShoot.Fire();

                }

            }
            

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
                alive = false;
                playerCharacter.GetComponent<CharController>().ps.sanGain(10);
                ResetStatus();
                if (type == "boss")
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    SceneManager.LoadScene(3);
                }
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
