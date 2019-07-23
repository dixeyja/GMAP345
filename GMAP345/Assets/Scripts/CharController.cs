using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float hp;
    public int damage;
    private float san;
    private float max_san;
    private Rigidbody rb;

    private Vector3 moveDirection;

    private bool canWalk;

    public Slider healthbar;
    public Slider sanBar;
    
    public TextMeshProUGUI damageTextGUI;

    #region Weapon variables

    public GameObject sword;
    private Animator swordAnim;
    public Collider bladeCollider;
    #endregion

    #region TEMP
    public combatManager cManager;
    public PlayerStatus ps;
    #endregion

    void Start()
    {
        getData();


        swordAnim = sword.GetComponent<Animator>();
        bladeCollider.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        canWalk = true;
        rb = GetComponent<Rigidbody>();

        healthbar.value = hp;
        sanBar.value = san;
        sanBar.maxValue = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        getData();
        damageTextGUI.text = damage.ToString();

        if (Input.GetKeyDown("escape"))
        {
            //Cursor.lockState = CursorLockMode.None;
            Application.Quit();
        }

        if (Input.GetButton("Fire1"))
        {
            bladeCollider.enabled = true;
            swordAnim.SetBool("isAttacking", true);
            swordAnim.SetBool("isIdle", false);
        }
        else
        {
            bladeCollider.enabled = false;
            swordAnim.SetBool("isAttacking", false);
            swordAnim.SetBool("isIdle", true);
        }

        if (hp <= 0)
        {
            ps.sanLoss(100);
            ps.max_sanLoss(30);
            SceneManager.LoadScene(0);
        }
        if (san <= 0)
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
            }
            else
            {
                swordAnim.SetFloat("IdleToRun", 1.0f);
            }

            transform.Translate(moveDirection.normalized * speed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.Space)) {
            if (rb.position.y <= 0) {
                rb.AddForce(0, 50, 0);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            cManager.EnterCombat();
            collision.gameObject.SetActive(false);
            sanBar.gameObject.SetActive(false);
            ps.sanLoss(10);
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
            ps.HpLoss(60);
            getData();
            healthbar.value = hp;
        }
        else if (other.tag == "Pickup")
        {
            Debug.Log(other.isTrigger.ToString());
            if (other.isTrigger) {
                other.isTrigger = false;                    
                ps.damageUp(10);
                ps.sanGain(20);
                getData();
                damageTextGUI.text = damage.ToString();
                sanBar.value = san;
            } 
        }
    }


    public void getData() {
        speed = ps.getSpeed();
        damage = ps.getDamage();
        hp = ps.getHp();
        san = ps.getSan();
        max_san = ps.getMaxSan();
    }
}
