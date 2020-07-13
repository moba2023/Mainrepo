using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim_Cont;

    public string animState = "idle";
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
                agent.destination = hit.point;
                anim_Cont.SetBool("moving", true);
            }
        }

        // Check the distance between destination and agent 
        if (Vector3.Distance(agent.destination, agent.transform.position) < 0.5f)
        {
            anim_Cont.SetBool("moving", false);
        }
    }

    void AnimHandler()
    {
        if (animState == "idle")
        {
            anim_Cont.SetBool("moving", false);
        }
    }
}
