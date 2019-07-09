using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    void Start()
    {
        rb.useGravity = true;
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) {
            Debug.Log("a");
            if (rb.position.x > 95) {
                rb.AddForce(-50, 0, 0);
            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("b");
            if (rb.position.x < 190)
            {
                rb.AddForce(50, 0, 0);
            }

        }
        if (Input.GetKey(KeyCode.W)) {
            Debug.Log("w");
            if (rb.position.z <= 210)
            {
                rb.AddForce(0, 0, 50);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S");
            if (rb.position.x > 121)
            {
                rb.AddForce(0, 0, -50);
            }

        }

        if (Input.GetKey(KeyCode.Space)) {
            Debug.Log("space");
            Debug.Log(rb.position.y);
            if (rb.position.y <= -13)
            {
                Debug.Log("true");

                rb.AddForce(0, 500, 0);
            }

        }
    }
}
