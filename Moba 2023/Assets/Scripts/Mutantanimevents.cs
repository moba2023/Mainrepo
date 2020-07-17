using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutantanimevents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BeginAttack()
    {
        transform.parent.gameObject.GetComponent<Mutant>().attackanimstate = false;
    }

    void MidAttack()
    {
        transform.parent.gameObject.GetComponent<Statsinfo>().target.gameObject.GetComponent<Statsinfo>().curHealth -= 200;
    }

    void EndAttack()
    {
        transform.parent.gameObject.GetComponent<Mutant>().attackanimstate = true;
    }



}
