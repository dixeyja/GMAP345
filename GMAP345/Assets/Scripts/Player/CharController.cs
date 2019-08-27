using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;

public class CharController : MonoBehaviour
{
    public PlayerStatus ps;
    private Rigidbody rb;
    private bool map_open;
    private Vector3 moveDirection;
    private bool canWalk;
    private bool moving;
    private bool attacking = false;
    private float attackCooldown = 0;
    public bool inCombat = false;
    private double accelaration = 0.01;
    private double accelaration_time = 0;
    //public TextMeshProUGUI lightTextGUI;
    //public UnityAction<HitData> hitEvent;
    #region Audio
    private AudioManager am;

    private string[] footsteps;
    #endregion

    #region Item Variables

    public GameObject sword;
    private Animator swordAnim;

    public Animator torchAnim;

    public Animator mapAnim;
    #endregion

    #region TEMP
    public combatManager cManager;
    #endregion

    void Start()
    {
        swordAnim = sword.GetComponent<Animator>();

        canWalk = true;
        rb = GetComponent<Rigidbody>();

        am = gameObject.GetComponent<AudioManager>();

        footsteps = new string[2];
        footsteps[0] = "Step1";
        footsteps[1] = "Step2";

    }

    // Update is called once per frame
    void Update()
    {
        //lightTextGUI.text = ps.GetLightLevel().ToString();

        attackCooldown -= Time.deltaTime;

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        if (inCombat)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (attackCooldown <= 0)
                {
                    swordAnim.SetBool("isAttacking", true);
                    swordAnim.SetBool("isIdle", false);
                    attackCooldown = 1 / ps.attackSpeed;
                }
            }
            else
            {
                swordAnim.SetBool("isAttacking", false);
                swordAnim.SetBool("isIdle", true);
            }
        }
        

        if (inCombat == false && Input.GetButtonDown("Equip Torch"))
        {
            if (torchAnim.GetBool("isOut"))
            {
                torchAnim.SetBool("isOut", false);
                am.PlaySound("TorchEquip");
            }
            else
            {
                torchAnim.SetBool("isOut", true);
                am.PlaySound("TorchEquip");
            }
        }

        if (inCombat == false && Input.GetButtonDown("Equip Map"))
        {
            if (mapAnim.GetBool("isOut"))
            {
                mapAnim.SetBool("isOut", false);
                am.PlaySound("TorchEquip");
            }
            else
            {
                mapAnim.SetBool("isOut", true);
                
                am.PlaySound("TorchEquip");
            }
        }

        if (torchAnim.GetBool("isOut"))
        {
            ps.ConfigureLightLevel(30);
        }
        else
        {
                //ps.SetLightLevel(0);
        }

        if (ps.getHp() <= 0)
        {
            ps.sanLoss(40);
            ps.max_sanLoss(30);
            cManager.EndCombat();
            ps.hpGain(30);
        }
        if (ps.getSan() <= 0)
        {
            Debug.Log("game over");
            SceneManager.LoadScene(2);
        }


        //Debug.Log("Player's Speed: " + speed.ToString());
        //Debug.Log("Player's Health: " + healthbar.value.ToString());
        //Debug.Log("Player's Damage: " + damage.ToString());
    }

    private void FixedUpdate()
    {
        
        
        if (canWalk)
        {
            float translate = Input.GetAxis("Vertical");
            float strafe = Input.GetAxis("Horizontal");

            moveDirection = new Vector3(strafe, 0, translate);

            if (moveDirection != new Vector3(0, 0, 0))
            {
                if (moving == false)
                {
                    swordAnim.SetFloat("IdleToRun", 1.5f);
                    torchAnim.SetFloat("IdleToRun", 1.5f);
                    mapAnim.SetFloat("IdleToRun", 1.5f);
                    moving = true;
                    StartCoroutine("Moving");

                }
                accelaration_time += Time.fixedDeltaTime;
                
            }
            else
            {
                accelaration_time = 0;
                if (moving != false)
                {
                    am.PlaySound(footsteps[Random.Range(0, 2)]);
                }
                swordAnim.SetFloat("IdleToRun", 1.0f);
                torchAnim.SetFloat("IdleToRun", 1.0f);
                mapAnim.SetFloat("IdleToRun", 1.0f);
                moving = false;
                StopCoroutine("Moving");
            }

            transform.Translate(moveDirection.normalized * (ps.getSpeed() * Time.fixedDeltaTime + (float) (accelaration * accelaration_time * accelaration_time))) ;

        }

        //if (Input.GetKey(KeyCode.Space)) {
        //    if (rb.position.y <= 0) {
        //        rb.AddForce(0, 50, 0);
        //    }
        //}
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            cManager.EnterCombat();
            other.gameObject.SetActive(false);
            ps.sanLoss(10);
        }

        if (other.transform.tag == "EnemyWeapon")
        {
            ps.HpLoss(20);
            
        }
    }


    public void SetCanWalk(bool b)
    {
        canWalk = b;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            Debug.Log(other.isTrigger.ToString());
            if (other.isTrigger) {
                other.isTrigger = false;                    
                ps.damageUp(10);
                ps.sanGain(20);
                ps.hpGain(30);
            } 
        }
        else if (other.tag == "LitArea")
        {
            ps.ConfigureLightLevel(other.transform.GetComponent<LitArea>().GetLightValue());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "LitArea")
        {
            ps.SetLightLevel(0);
        }
    }

    public void stowTools()
    {
        mapAnim.SetBool("isOut", false);
        torchAnim.SetBool("isOut", false);
    }

    private IEnumerator Moving()
    {
        while (moving)
        {
            
            am.PlaySound(footsteps[Random.Range(0, 2)]);
            yield return new WaitForSeconds(.5f);
        }
    }
}
