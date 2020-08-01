﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janispawn : MonoBehaviour
{

    public GameObject Janis; // prefab
    public GameObject Janismelee;
    public Transform point;
    public Transform beys;

    private int sprCount = 0;
    private int spmCount = 0;


    private void Start()
    {
        InvokeRepeating("Spawnvawe", 2, 40);
    }


    void Spawnvawe()
    {
        InvokeRepeating("SpawnMelee", 0, 1.5f);
    }


    void SpawnRanged()
    {
        GameObject jani = Instantiate(Janis, transform.position, Quaternion.identity);
        jani.transform.GetChild(0).GetComponent<Janisarry>().nextPoint = point;
        jani.transform.GetChild(0).GetComponent<Janisarry>().targetBase = beys;
        jani.transform.SetParent(GameObject.Find("Minions").transform);
        if (++sprCount%3 ==0)
        {
            CancelInvoke("SpawnRanged");
            
        }
    }

    void SpawnMelee()
    {
        GameObject jani = Instantiate(Janismelee, transform.position, Quaternion.identity);
        jani.transform.GetChild(0).GetComponent<Janisarry>().nextPoint = point;
        jani.transform.GetChild(0).GetComponent<Janisarry>().targetBase = beys;
        jani.transform.SetParent(GameObject.Find("Minions").transform);
        if (++spmCount % 3 == 0)
        {
            CancelInvoke("SpawnMelee");
            InvokeRepeating("SpawnRanged", 3, 1.5f);
        }
    }
}