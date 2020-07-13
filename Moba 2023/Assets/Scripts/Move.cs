using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animcont;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animcont = transform.GetChild(0).GetComponent<Animator>();
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
                animcont.SetBool("moving", true);
            }
        }

        // Check the distance between destination and agent 
        if (Vector3.Distance(agent.destination, agent.transform.position) < 0.5f)
        {
            animcont.SetBool("moving", false);
        }
    }
}
