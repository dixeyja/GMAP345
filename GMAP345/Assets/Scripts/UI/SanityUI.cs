using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SanityUI : MonoBehaviour
{
    public PlayerStatus pStats;
    [SerializeField]
    private Image bar;
    [SerializeField]
    private GameObject criticalSan;

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = pStats.getSan() / pStats.getBaseSan();
        
        if (bar.fillAmount < .3f)
        {
            criticalSan.SetActive(true);
        }
        else
        {
            criticalSan.SetActive(false);
        }
    }
}
