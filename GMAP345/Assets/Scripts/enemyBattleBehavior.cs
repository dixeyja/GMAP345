using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBattleBehavior : MonoBehaviour
{

    public float speed;
    public Transform playerCharacter;
    static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(playerCharacter.position, this.transform.position) < 10)
        {
            Vector3 direction = playerCharacter.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            
            if (direction.magnitude > 2)
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
                anim.SetBool("isAttacking", false);
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    transform.Translate(0, 0, speed * Time.deltaTime);
                }
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", false);
            }


        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }
}
