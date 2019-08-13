using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_screen_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas map_canvas;
    public Camera map_cam;
    public CharController player;
    void Start()
    {

        Vector3 player_pos = new Vector3(0,0,0);
        player_pos.x = player.transform.position.x;
        player_pos.y = player.transform.position.y + 50;
        player_pos.z = player.transform.position.z;
        map_cam.transform.position = player_pos;
        Debug.Log(map_cam.transform.position); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.inputString);
        if (Input.GetButtonDown("MAP OPEN")) {
            player.SetCanWalk(true);
            map_canvas.gameObject.SetActive(false);
        }
    }


    private void FixedUpdate()
    {
        player.SetCanWalk(false);
        float translate = Input.GetAxis("z_axis");
        float strafe = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(strafe, translate, 0);
        map_cam.transform.Translate(moveDirection.normalized * player.ps.getSpeed() * Time.fixedDeltaTime);
        Debug.Log("Location" + map_cam.transform.position);
    }
}
