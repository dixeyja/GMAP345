using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyDungeonBehavior : MonoBehaviour
{
    public float speed;
    public Transform playerCharacter;
    public CharController cc;
    static Animator anim;
    //distance in which the enemy can see the player
    public float sightRange = 20f;
    public float sightAngle = 45f;

    public bool spotted = false;

    private AudioManager am;

    public GameEvent PlayerSpotted;
    public GameEvent PlayerEscaped;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        am = GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Subtraction between two vectors gives you the direction from on point to another
        Vector3 direction = playerCharacter.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);


        if (cc.torchAnim.GetBool("isOut"))
        {
            if (Vector3.Distance(playerCharacter.position, this.transform.position) < 0.33 * sightRange && angle < sightAngle)
            {
                direction.y = 0;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
                transform.Translate(0, 0, 2 * speed * Time.deltaTime);
                if (!spotted)
                {
                    PlayerSpotted.Raise();
                    am.PlaySound("AgroNoise");
                    spotted = true;
                }
            }
            else
            {
                if (spotted)
                {
                    PlayerEscaped.Raise();
                }
                spotted = false;
                anim.SetBool("isIdle", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);
            }
        }
        else
        {
            if (Vector3.Distance(playerCharacter.position, this.transform.position) < sightRange && angle < 3.0 * sightAngle)
            {
                direction.y = 0;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
                transform.Translate(0, 0, speed * Time.deltaTime);
                if (!spotted)
                {
                    PlayerSpotted.Raise();
                    am.PlaySound("AgroNoise");
                    spotted = true;
                }
            }
            else
            {
                if (spotted)
                {
                    PlayerEscaped.Raise();
                }
                spotted = false;
                anim.SetBool("isIdle", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);
            }
        }
    }

}
