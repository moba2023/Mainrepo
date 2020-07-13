using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerFallow : MonoBehaviour
{
    public Transform pl; // player
    public int offset;
       
    void Update()
    {
        transform.position = new Vector3(pl.position.x, pl.position.y+offset,pl.position.z-offset/2);
    }
}
