using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camController : MonoBehaviour
{

    private Vector2 mouseLook;
    private Vector2 smoothV;

    [SerializeField]
    private float sensitivity = 5.0f;
    [SerializeField]
    private float smoothing = 2.0f;

    private GameObject playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = transform.parent.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        playerCharacter.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, playerCharacter.transform.up);
    }
}
