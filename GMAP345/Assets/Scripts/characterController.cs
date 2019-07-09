using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField]
    private float speed = 50.0f;
    public Rigidbody rb;
    [SerializeField]
    private Transform arenaPosition;

    private Vector3 moveDirection;

    private bool canWalk;

    #region Weapon variables

    public GameObject sword;
    private Animator swordAnim;
    public Collider bladeCollider;
    #endregion

    #region TEMP
    public combatManager cManager;
    #endregion

    void Start()
    {
        swordAnim = sword.GetComponent<Animator>();
        bladeCollider.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        canWalk = true;
        rb.useGravity = true;
        rb.AddForce(0, -10, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetButton("Fire1"))
        {
            bladeCollider.enabled = true;
            swordAnim.SetBool("isAttacking", true);
            swordAnim.SetBool("isIdle", false);
        }
        else
        {
            swordAnim.SetBool("isAttacking", false);
            swordAnim.SetBool("isIdle", true);
        }
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
        }
    }


    public void SetCanWalk(bool b)
    {
        canWalk = b;
    }
}
