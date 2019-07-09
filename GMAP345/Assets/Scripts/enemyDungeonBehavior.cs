using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDungeonBehavior : MonoBehaviour
{
    public float speed;
    public Transform playerCharacter;
    static Animator anim;
    public GameObject battleVersion;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerCharacter.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(playerCharacter.position, this.transform.position) < 10 && angle < 45 )
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            battleVersion.SetActive(true);
        }
    }
}
