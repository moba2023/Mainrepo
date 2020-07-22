using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janissaryanimevent : MonoBehaviour
{
    Statsinfo stats;

    private void Start()
    {
        stats = transform.parent.GetComponent<Statsinfo>();
    }
    public void MidAttack()
    {
        stats.target.parent.GetComponent<Statsinfo>().DamageTaken(50, transform.parent);
    }
}
