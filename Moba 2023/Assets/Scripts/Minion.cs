using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Minion : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform nextPoint;
    NavMeshAgent agent;
    public Transform points;
    public bool chasing;

    public bool chaseBreak = false;

    Enemyinrange enemyinrange;
    Statsinfo stats;
    
    int i = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        nextPoint = points.GetChild(i);
        enemyinrange = transform.GetChild(2).gameObject.GetComponent<Enemyinrange>();
        stats = GetComponent<Statsinfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.target != null && !stats.target.GetComponent<Statsinfo>().isAlive)
        {
            if (enemyinrange.enemyCount <= 0)
            {
                chasing = false;
            }
            else
            {
                stats.target = enemyinrange.GetNearest();
            }
        }

        if (stats.isAlive)
        {
            if (chasing)
            {
                Chase();
            }
            else
            {
                transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("chase", false);
                agent.destination = nextPoint.position;
            }
        }



        if (stats.curHealth <= 0 && stats.isAlive)
        {
            Death();
        }
    }

    public void Chase()
    {
        if (Vector3.Distance(stats.target.position, transform.position) < stats.attackRange)
        {
            agent.ResetPath();
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("chase", true);
        }
        else
        {
            if (!chaseBreak)
            {
                agent.destination = stats.target.position;
                transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("chase", false);
            }
        }
    }

    public void Death()
    {
        stats.isAlive = false;
        transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("death");
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        transform.GetChild(1).gameObject.active = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Split(' ')[0] == "Point")
        {
            if (++i == points.childCount)
            {
                i = 0;
            }
            nextPoint = points.GetChild(i);
        }
    }
}
