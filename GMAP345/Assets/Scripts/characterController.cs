using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private Transform arenaPosition;

    private Vector3 moveDirection;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
        float translate = Input.GetAxis("Vertical");
        float strafe = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(strafe, 0, translate);

        transform.Translate(moveDirection.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            gameObject.transform.position = arenaPosition.position;
        }
    }

}
