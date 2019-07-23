using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitArea : MonoBehaviour
{
    [SerializeField]
    private int lightValue;

    public int GetLightValue()
    {
        return lightValue;
    }
}
