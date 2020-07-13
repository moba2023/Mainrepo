using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class cameraFallow : MonoBehaviour
{
    public GameObject player;
    public int x;
    

  

    
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+x,player.transform.position.x*-2);
    }
}
