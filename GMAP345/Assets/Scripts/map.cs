using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    private Animator animator;
    private MeshRenderer mRender;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        animator.SetBool("isOut", true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Equip Map"))
        {

        }
    }

    public void MapOff()
    {
        mRender.a;
    }
}
