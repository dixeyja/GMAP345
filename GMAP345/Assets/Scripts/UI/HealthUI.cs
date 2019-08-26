using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthUI : MonoBehaviour
{
    public PlayerStatus pStats;
    [SerializeField]
    private Image bar;

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = pStats.getHp() / pStats.getMaxHp();
    }
}
