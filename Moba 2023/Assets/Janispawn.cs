using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janispawn : MonoBehaviour
{

    public GameObject Janis; // prefab
    public Transform point;
    public Transform beys;

    private int spCount = 0;

    private void Start()
    {
        InvokeRepeating("Spawnvawe", 2, 30);
    }


    void Spawnvawe()
    {
        InvokeRepeating("Spawn", 0, 1.5f);
    }

    void Spawn()
    {
        GameObject jani = Instantiate(Janis, transform.position, Quaternion.identity);
        jani.transform.GetChild(0).GetComponent<Janisarry>().nextPoint = point;
        jani.transform.GetChild(0).GetComponent<Janisarry>().targetBase = beys;
        if (++spCount%3 ==0)
        {
            CancelInvoke("Spawn");
        }

    }
}
