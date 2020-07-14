using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim_Cont;
    string state = "";//idle, move, chasing
    public float range;
    public Transform enemy;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim_Cont = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (hit.transform.tag == "Enemy")
                {
                    state = "chasing";//DUSMANI KOVALIYOR YADA SALDIRIRYOR
                    enemy = hit.transform;
                }
                else
                {
                    state = "move";
                    agent.destination = hit.point;
                    AnimHandler("move");
                }
            }
        }

        if (state == "move")
        {
            if (Vector3.Distance(agent.destination, agent.transform.position) < 0.5f)
            {
                state = "idle";
                AnimHandler("idle");
            }
        }
        else if (state == "chasing")
        {
            if (Vector3.Distance(enemy.position, agent.transform.position) < range)
            {
                agent.ResetPath();
                AnimHandler("attack");
            }
            else
            {
                agent.destination = enemy.position;
                AnimHandler("move");
            }
        }


        /*
        if (Input.GetKeyDown("1"))
        {
            AnimHandler("idle");
        }
        else if (Input.GetKeyDown("2"))
        {
            AnimHandler("move");
        }
        else if (Input.GetKeyDown("3"))
        {
            AnimHandler("attack");
        }*/
    }

    void AnimHandler(string animState)
    {
        if (animState == "idle")
        {
            anim_Cont.SetBool("idle", true);
            anim_Cont.SetBool("move", false);
            anim_Cont.SetBool("attack", false);
        }
        else if (animState == "move")
        {
            anim_Cont.SetBool("idle", false);
            anim_Cont.SetBool("move", true);
            anim_Cont.SetBool("attack", false);
        }
        else
        {
            anim_Cont.SetBool("idle", false);
            anim_Cont.SetBool("move", false);
            anim_Cont.SetBool("attack", true);
        }
    }

}