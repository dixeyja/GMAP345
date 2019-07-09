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

    public bool canWalk;

    void Start()
    {
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
    }

    private void FixedUpdate()
    {
        if (canWalk)
        {
            float translate = Input.GetAxis("Vertical");
            float strafe = Input.GetAxis("Horizontal");

            moveDirection = new Vector3(strafe, 0, translate);

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
            Vector3 newposition;
            newposition.x = arenaPosition.position.x;
            newposition.y = arenaPosition.position.y + 20;
            newposition.z = arenaPosition.position.z;
            gameObject.transform.position = newposition;


        }
    }

}
