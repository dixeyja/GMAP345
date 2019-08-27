using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SanityUI : MonoBehaviour
{
    public PlayerStatus ps;
    [SerializeField]
    private Image bar;
    [SerializeField]
    private Image max_bar;

    [SerializeField]
    private GameObject criticalSan;

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = ps.getSan() / ps.getBaseSan();
        max_bar.fillAmount = ps.getMaxSan() / ps.getBaseSan();
        
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
