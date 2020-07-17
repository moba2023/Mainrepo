using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class Mutant : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 spawnPoint;
    public Transform player;
    NavMeshAgent agent;
    Animator anim_Cont;
    public string state = "pasif"; //
    public bool attackanimstate = true;
    void Start()
    {
        spawnPoint = transform.position;
        agent = GetComponent<NavMeshAgent>();
        anim_Cont = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, spawnPoint) < 20 && state == "pasif")
        {
            state = "chase";
        }

        if (Vector3.Distance(transform.position, spawnPoint) > 40)
        {
            state = "turninghome";
            agent.destination = spawnPoint;
            AnimHandler("move");
        }

        if (state == "chase")
        {
            if (Vector3.Distance(player.position, transform.position) < 7.5f)
            {
                agent.ResetPath();
                transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
                AnimHandler("attack");
            }
            else
            {
                if (attackanimstate)
                {
                    agent.destination = player.position;
                    AnimHandler("move");
                }
            }
        }

        if (state == "turninghome" && Vector3.Distance(spawnPoint, transform.position) < 1)
        {
            attackanimstate = true;
            state = "pasif";
            AnimHandler("idle");
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
