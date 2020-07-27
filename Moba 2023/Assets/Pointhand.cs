using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointhand : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Any Team" && other.transform.root.name.Split(' ')[0] == "Janissary")
        {
            other.GetComponent<Janisarry>().nextPoint = other.GetComponent<Janisarry>().targetBase;
            other.GetComponent<Janisarry>().state = "chasing";
        }
    }
}
