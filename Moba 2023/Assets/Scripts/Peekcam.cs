using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peekcam : MonoBehaviour
{
    public Transform pl; // Player
    public int offset; // Distance between cam and player
    public float smooth; // Cam zoom smoothness

    private float fov = 60; // Field of view
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(pl.position.x, pl.position.y + offset, pl.position.z - offset / 2 - 2.5f);

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && fov > 30) fov -= 5;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && fov < 70) fov += 5;  
        
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, fov, Time.deltaTime * smooth);
    }
}
