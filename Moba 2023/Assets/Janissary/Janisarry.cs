using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Janisarry : MonoBehaviour
{

    NavMeshAgent agent;
    Animator animator;


    Statsinfo stats;
    NearEnemies nearEnemies;


    public string state;



    private void Start()
    {
        animator = GetComponent<Animator>();
        stats = transform.parent.GetComponent<Statsinfo>();
        nearEnemies = transform.parent.Find("Chasecircle").GetComponent<NearEnemies>();
        agent = transform.parent.GetComponent<NavMeshAgent>();
        agent.destination = GameObject.Find("Point " + transform.parent.tag.Split(' ')[1]).transform.position;
        state = "move";

    }

    private void Update()
    {
        if (stats.curHealth <= 0 && stats.isAlive)
        {
            Death();
        }

        if (state == "chasing")
        {
            if (stats.target != null && stats.target.parent.GetComponent<Statsinfo>().isAlive)
            {
                Chase();
            }
            else
            {
                nearEnemies.UpdateEnemies();
                if (nearEnemies.enemies.Count == 0)
                {
                    state = "move";
                    animator.SetBool("chase", false);
                    agent.destination = GameObject.Find("Point " + transform.parent.tag.Split(' ')[1]).transform.position;
                }
                else
                {
                    stats.target = nearEnemies.GetNearest();
                }
            }
        }
    }

    private void Death()
    {
        stats.isAlive = false;
        state = "death";
        animator.SetTrigger("death");
        GetComponent<CapsuleCollider>().enabled = false;
        transform.parent.GetComponent<NavMeshAgent>().enabled = false;
        transform.parent.Find("Health Canvas").gameObject.active = false;
        Destroy(transform.parent.gameObject, 4);
    }

    private void Chase()
    {
        if (Vector3.Distance(stats.target.position, transform.position) < stats.attackRange)
        {
            agent.ResetPath();
            animator.SetBool("chase", true);
            transform.parent.LookAt(stats.target);
        }
        else if (Vector3.Distance(stats.target.position, transform.position) > stats.attackRange + 10)
        {
            stats.target = null;
        }
        else
        {
            agent.destination = stats.target.position;
            animator.SetBool("chase", false);
        }
    }
}
