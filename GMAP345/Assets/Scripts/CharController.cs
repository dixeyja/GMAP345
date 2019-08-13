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

    public Slider healthbar;
    public Slider sanBar;
    public TextMeshProUGUI damageTextGUI;
    public TextMeshProUGUI lightTextGUI;
    public UnityAction<HitData> hitEvent;

    private AudioManager am;

    private string[] footsteps;

    public bool inCombat = false;

    #region Item Variables

    public GameObject sword;
    private Animator swordAnim;
    public Collider bladeCollider;

    public GameObject torch;
    private Animator torchAnim;
    #endregion

    #region TEMP
    public combatManager cManager;
    #endregion

    void Start()
    {
        
        swordAnim = sword.GetComponent<Animator>();
        torchAnim = torch.GetComponent<Animator>();
        bladeCollider.enabled = false;
        canWalk = true;
        rb = GetComponent<Rigidbody>();

        healthbar.value = ps.getHp();
        sanBar.value = ps.getSan();
        sanBar.maxValue = ps.getMaxSan();

        am = gameObject.GetComponent<AudioManager>();

        footsteps = new string[2];
        footsteps[0] = "Step1";
        footsteps[1] = "Step2";

    }

    // Update is called once per frame
    void Update()
    {
        damageTextGUI.text = ps.getDamage().ToString();
        lightTextGUI.text = ps.GetLightLevel().ToString();
        healthbar.value = ps.getHp();
        sanBar.value = ps.getSan();


        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        if (inCombat)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                bladeCollider.enabled = true;
                swordAnim.SetBool("isAttacking", true);
                swordAnim.SetBool("isIdle", false);
                if (attacking == false)
                {
                    attacking = true;
                    StartCoroutine("SwordSwing");
                }
            }
            else
            {
                bladeCollider.enabled = false;
                swordAnim.SetBool("isAttacking", false);
                swordAnim.SetBool("isIdle", true);
            }
        }
        

        if (Input.GetButtonDown("Equip Torch"))
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
            Application.Quit();
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
                swordAnim.SetFloat("IdleToRun", 1.5f);
                if (moving == false)
                {
                    moving = true;
                    StartCoroutine("Moving");

                }
                
            }
            else
            {
                if (moving != false)
                {
                    am.PlaySound(footsteps[Random.Range(0, 2)]);
                }
                swordAnim.SetFloat("IdleToRun", 1.0f);
                moving = false;
                StopCoroutine("Moving");
            }

            transform.Translate(moveDirection.normalized * ps.getSpeed() * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.Space)) {
            if (rb.position.y <= 0) {
                rb.AddForce(0, 50, 0);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            cManager.EnterCombat();
            other.gameObject.SetActive(false);
            sanBar.gameObject.SetActive(false);
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
        if (other.tag == "EnemyWeapon")
        {
            ps.HpLoss(10);
            healthbar.value = ps.getHp();
        }
        else if (other.tag == "Pickup")
        {
            Debug.Log(other.isTrigger.ToString());
            if (other.isTrigger) {
                other.isTrigger = false;                    
                ps.damageUp(10);
                ps.sanGain(20);
                ps.hpGain(30);

                damageTextGUI.text = ps.getDamage().ToString();
                sanBar.value = ps.getSan();
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


    public IEnumerator SwordSwing()
    {

        yield return new WaitForSeconds(.25f);
        am.PlaySound("SwordUnsheath");
        yield return new WaitForSeconds(.25f);
        attacking = false;
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
