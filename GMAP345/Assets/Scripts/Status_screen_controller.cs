using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Status_screen_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthbar;
    public Slider sanBar;
    public TextMeshProUGUI damageTextGUI;
    public TextMeshProUGUI maxSanTextGUI;
    public Canvas self;
    public CharController player;


    void Start()
    { 
        self.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            player.SetCanWalk(true);
            self.gameObject.SetActive(false);

        }
    }


  
}
