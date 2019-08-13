using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_canvas_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public map_screen_controller map_canvas;
    public Status_screen_controller status_canvas;
    private bool map_screen_open;
    private bool status_screen_open;
    void Start()
    {
        map_screen_open = false;
        status_screen_open = false;
        map_canvas.gameObject.SetActive(false);
        status_canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("MAP OPEN")) {
            if (!map_screen_open)
            {
                if (status_screen_open)
                {
                    status_screen_open = false;
                    status_canvas.gameObject.SetActive(false);
                }



                map_screen_open = true;
                map_canvas.player.SetCanWalk(false);

                Vector3 player_pos = new Vector3();

                player_pos.x = map_canvas.player.transform.position.x;
                player_pos.y = map_canvas.player.transform.position.y + 50;
                player_pos.z = map_canvas.player.transform.position.z;
                map_canvas.map_cam.transform.position = player_pos;
                map_canvas.gameObject.SetActive(true);
            }
            else
            {
                map_screen_open = false;
            }           
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            if (!status_screen_open)
            {
                if (map_screen_open)
                {
                    map_screen_open = false;
                    map_canvas.gameObject.SetActive(false);
                }

                status_screen_open = true;
                status_canvas.gameObject.SetActive(true);
                status_canvas.healthbar.value = status_canvas.player.ps.getHp();
                status_canvas.healthbar.maxValue = 100;
                status_canvas.sanBar.value = status_canvas.player.ps.getSan();
                status_canvas.sanBar.maxValue = 100;
                status_canvas.maxSanTextGUI.SetText(status_canvas.player.ps.getMaxSan().ToString());
                status_canvas.damageTextGUI.SetText(status_canvas.player.ps.getDamage().ToString());
                status_canvas.player.SetCanWalk(false);
            }
            else
            {
                status_screen_open = false;
            }
        }
    }

    
}
