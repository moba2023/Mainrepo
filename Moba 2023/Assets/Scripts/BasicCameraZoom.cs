using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCameraZoom : MonoBehaviour
{
    public float max;
    public float min;
    
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if(GetComponent<Camera>().fieldOfView > min)
            {
                GetComponent<Camera>().fieldOfView--;
            }
           
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (GetComponent<Camera>().fieldOfView < max)
            {
                GetComponent<Camera>().fieldOfView++;
            }
        }

    }
}