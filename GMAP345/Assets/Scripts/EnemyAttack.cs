using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private HitData hitData;
    //public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.GetComponent<CharController>().ps.HpLoss(hitData.hDamage);
            other.transform.GetComponent<CharController>().ps.sanLoss(hitData.sDamage);
            //Vector3 moveDirection = other.transform.position - enemy.transform.position;
            //moveDirection = moveDirection.normalized;
            //other.transform.GetComponent<CharController>().KnockBack(moveDirection, hitData.knockback);
        }
    }
}
