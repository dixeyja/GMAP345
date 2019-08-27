using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{

    public int nextSceneIndex;


    public void OnMouseUp()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
