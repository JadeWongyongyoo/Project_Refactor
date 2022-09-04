using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCam : MonoBehaviour
{
    public GameObject cam1, cam2;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
}
