using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kachanimevents : MonoBehaviour
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
        transform.parent.gameObject.GetComponent<PlayerControl>().atkanimbegin = true;
    }

    void MidAttack()
    {
        transform.parent.gameObject.GetComponent<Statsinfo>().target.gameObject.GetComponent<Statsinfo>().curHealth -= 150;
    }

    void EndAttack()
    {
        transform.parent.gameObject.GetComponent<PlayerControl>().atkanimbegin = false;
    }
}
