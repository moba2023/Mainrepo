using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animevents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        transform.parent.gameObject.GetComponent<Statsinfo>().target.gameObject.GetComponent<Statsinfo>().curHealth -= 10;
    }
}
