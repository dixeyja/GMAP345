using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combatManager : MonoBehaviour
{
    public CharController player;
    public List<GameObject> enemies;
    public Transform playerArenaPostion;
    public Transform enemyArenaPosition;
    public Light spotlight;

    private Vector3 currentDungeonPosition;
    private Quaternion currentDungeonRotation;

    //public Image blackScreen;
    //public float transitionRate = .02f;

    private int encounterNumber = 0;

    public GameEvent combatStart;
    public GameEvent combatEnd;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Combat Manager's number of Encounters: " + encounterNumber.ToString());
    }
    
    public void EnterCombat()
    {
        //StartCoroutine("Transition");
        spotlight.spotAngle = player.ps.GetLightLevel();
        currentDungeonPosition = player.transform.position;
        currentDungeonRotation = player.transform.rotation;
        player.transform.position = playerArenaPostion.position;
        enemies[encounterNumber].SetActive(true);
        enemies[encounterNumber].transform.position = enemyArenaPosition.position;
        player.sword.SetActive(true);
        player.inCombat = true;
        player.stowTools();
        combatStart.Raise();
    }

    public void EndCombat()
    {
        StartCoroutine("FinishUpCombat");
        player.inCombat = false;
        combatEnd.Raise();
    }

    IEnumerator FinishUpCombat()
    {
        //yield return new WaitForSeconds(3);
        yield return null;
        player.transform.position = currentDungeonPosition;
        player.transform.rotation = currentDungeonRotation;
        //player.sanBar.fillAmount = player.ps.getSan()/player.ps.getMaxSan();
        enemies[encounterNumber].SetActive(false);
        player.sword.SetActive(false);
        
        encounterNumber++;
    }
}
