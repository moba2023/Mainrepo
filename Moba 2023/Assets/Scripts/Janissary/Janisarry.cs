﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Janisarry : MonoBehaviour
{

    NavMeshAgent agent;
    Animator animator;


    Statsinfo stats;
    NearEnemies nearEnemies;

    public Transform nextPoint;
    public Transform targetBase;

    public string state;
    public bool chaseBreak;



    private void Start()
    {
        animator = GetComponent<Animator>();
        stats = transform.parent.GetComponent<Statsinfo>();
        nearEnemies = transform.parent.Find("Chasecircle").GetComponent<NearEnemies>();
        agent = transform.parent.GetComponent<NavMeshAgent>();
        agent.destination = nextPoint.position;
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
                    agent.destination = nextPoint.position;
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
        agent.speed = 0;
        agent.radius = 0;
        transform.parent.Find("Health Canvas").gameObject.SetActive(false);
        Destroy(transform.parent.gameObject, 4);
    }

    private void Chase()
    {
        if (Vector3.Distance(stats.target.position, transform.position) < stats.attackRange)
        {
            agent.ResetPath();
            animator.SetBool("chase", true);
            transform.parent.LookAt(stats.target);
            chaseBreak = true;

        }
        else if (Vector3.Distance(stats.target.position, transform.position) > stats.attackRange + 10)
        {
            if (!chaseBreak)
            {
                stats.target = null;
            }
        }
        else
        {
            if (!chaseBreak)
            {
                agent.destination = stats.target.position;
                animator.SetBool("chase", false);
            }
        }
    }
}