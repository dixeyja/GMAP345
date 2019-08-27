using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioManager))]
public class Sword : MonoBehaviour
{
    private AudioManager am;
    private BoxCollider hitbox;

    // Start is called before the first frame update
    void Start()
    {
        am = this.GetComponent<AudioManager>();
        hitbox = GetComponentInChildren<BoxCollider>();
    }

    public void PlayAttack()
    {
        am.PlaySound("SwordSwing");
        Debug.Log("Playing SwordSwing...");
    }

    public void BeginAttack()
    {
        hitbox.enabled = true;
    }

    public void EndAttack()
    {
        hitbox.enabled = false;
    }
}
