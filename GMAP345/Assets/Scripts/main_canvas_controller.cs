using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_canvas_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public map_screen_controller map_canvas;
    public Canvas status_canvas;
    private bool map_screen_open;
    private bool status_screen_open;
    void Start()
    {
        map_canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("MAP OPEN")) {
            if (!map_screen_open)
            {
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
    }
}
