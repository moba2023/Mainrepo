using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janirangedanimevent : MonoBehaviour
{
    Statsinfo stats;

    private void Start()
    {
        stats = transform.parent.GetComponent<Statsinfo>();
    }

    private void Update()
    {
        GetComponent<CapsuleCollider>().center = transform.Find("mixamorig:Hips").localPosition;
    }

    public void BeginAttack()
    {
        if (stats.target != null)
        {

        }
    }

    public void MidAttack()
    {
        if (stats.target != null)
        {
            stats.target.parent.GetComponent<Statsinfo>().curHealth -= 40;
        }
    }


    public void EndAttack()
    {
        GetComponent<Janisarry>().chaseBreak = false;
    }
}
