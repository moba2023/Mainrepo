using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handball : MonoBehaviour
{

    public bool charce;
    public Transform target;

    private void Update()
    {
        if (charce)
        {
            if (target == null || !target.transform.parent.GetComponent<Statsinfo>().isAlive)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, 5, target.position.z), Time.deltaTime * 50);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == target)
        {
            other.transform.parent.GetComponent<Statsinfo>().DamageTaken(75, transform);
            Destroy(gameObject);
        }
    }
}
