using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim_Cont;
    string state = "";//idle, move, chasing, attack, follow
    public float range;
    public Transform enemy;
    public GameObject trace;

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
                    enemy = hit.transform;
                    state = "chasing";
                }
                else
                {
                    Move(hit);
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
            Chase();
        }
    }


    void Move(RaycastHit hit)
    {
        if (Vector3.Distance(agent.transform.position, hit.point) > 2.8)
        {
            state = "move";
            agent.destination = hit.point;
            AnimHandler("move");
        }
        Instantiate(trace, new Vector3(hit.point.x, 0.1f, hit.point.z), Quaternion.Euler(-90, 0, 0));
    }


    void Chase()
    {

        if (Vector3.Distance(enemy.position, agent.transform.position) < range)
        {
            agent.ResetPath();
            transform.LookAt(new Vector3(enemy.position.x, transform.position.y, enemy.position.z));
            AnimHandler("attack");     
        }
        else
        {
            agent.destination = enemy.position;
            AnimHandler("move");
        }
    }

    void AnimHandler(string animState)
    {
        if (!anim_Cont.GetBool(animState))
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
}