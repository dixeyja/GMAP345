using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Collider mCollider;
    private bool used;


    void Start()
    {
        mCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            gameObject.SetActive(false);
        }
    }
}
