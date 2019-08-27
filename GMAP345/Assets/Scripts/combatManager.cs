using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combatManager : MonoBehaviour
{
    public CharController player;
    public List<GameObject> fireElementals;
    public List<GameObject> earthElementals;
    public List<GameObject> waterElementals;
    public List<GameObject> boss;
    private List<GameObject> activeEnemies;
    public Transform playerArenaPostion;
    public Transform primarySpawn;
    public Transform secondarySpawn;
    public Transform tertiarySpawn;
    public Light spotlight;
    private int enemyCount = 3;
    private int enemiesBeat = 0;

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
        if (enemiesBeat == enemyCount)
        {
            WinCombat();
            enemyCount = 3;
            enemiesBeat = 0;
        }
    }
    
    public void EnterCombat(string type)
    {
        //StartCoroutine("Transition");
        spotlight.spotAngle = player.ps.GetLightLevel();

        if (player.ps.GetLightLevel() <= 70 && player.ps.GetLightLevel() > 40)
        {
            enemyCount = 1;
        } else if (player.ps.GetLightLevel() <= 40 && player.ps.GetLightLevel() > 20)
        {
            enemyCount = 2;
        }
        else
        {
            enemyCount = 3;
        }

        if(type == "fire")
        {
            activeEnemies = fireElementals;
        }else if (type == "earth")
        {
            activeEnemies = earthElementals;
        }
        else if (type == "water")
        {
            activeEnemies = waterElementals;
        }
        else
        {
            
            activeEnemies = boss;
        }

        currentDungeonPosition = player.transform.position;
        currentDungeonRotation = player.transform.rotation;
        player.transform.position = playerArenaPostion.position;
        //enemies[encounterNumber].SetActive(true);
        //enemies[encounterNumber].transform.position = primarySpawn.position;

        for (int i = 0; i < enemyCount; i++)
        {
            if (type == "boss")
            {
                activeEnemies[0].SetActive(true);
                activeEnemies[0].transform.position = primarySpawn.position;
            }
            else
            {
                if (i == 0)
                {
                    activeEnemies[0].SetActive(true);
                    activeEnemies[0].transform.position = primarySpawn.position;
                }else if (i == 1)
                {
                    activeEnemies[1].SetActive(true);
                    activeEnemies[1].transform.position = secondarySpawn.position;
                }
                else
                {
                    activeEnemies[2].SetActive(true);
                    activeEnemies[2].transform.position = tertiarySpawn.position;
                }
            }
               
            
            
        }
        player.sword.SetActive(true);
        player.inCombat = true;
        player.stowTools();
        combatStart.Raise();
    }

    public void LoseCombat()
    {
        StartCoroutine("FinishUpCombat");
        player.inCombat = false;
        foreach (GameObject obj in activeEnemies)
        {
            obj.SetActive(false);
        }
        combatEnd.Raise();
    }

    public void WinCombat()
    {
        StartCoroutine("FinishUpCombat");
        player.inCombat = false;
        combatEnd.Raise();
    }

    public void addEnemiesBeat()
    {
        enemiesBeat++;
    }

    IEnumerator FinishUpCombat()
    {
        //yield return new WaitForSeconds(3);
        yield return null;
        player.sword.SetActive(false);
        player.transform.position = currentDungeonPosition;
        player.transform.rotation = currentDungeonRotation;
        //enemies[encounterNumber].SetActive(false);
        
        encounterNumber++;
    }
}
