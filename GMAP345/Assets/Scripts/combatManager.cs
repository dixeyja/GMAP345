using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combatManager : MonoBehaviour
{
    public characterController player;
    public GameObject enemy;
    public Transform playerArenaPostion;
    public Transform enemyArenaPosition;

    private Vector3 currentDungeonPosition;
    private Quaternion currentDungeonRotation;

    public Image blackScreen;
    public float transitionRate = .02f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void EnterCombat()
    {
        //StartCoroutine("Transition");
        currentDungeonPosition = player.transform.position;
        currentDungeonRotation = player.transform.rotation;
        player.transform.position = playerArenaPostion.position;
        enemy.SetActive(true);
        enemy.transform.position = enemyArenaPosition.position;
    }

    public void EndCombat()
    {
        player.transform.position = currentDungeonPosition;
        player.transform.rotation = currentDungeonRotation;
    }

}
