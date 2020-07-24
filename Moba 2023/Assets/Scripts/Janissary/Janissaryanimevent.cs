using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janissaryanimevent : MonoBehaviour
{
    Statsinfo stats;

    public GameObject ballPrefab;
    public Transform hand;
    GameObject ball;
    
    private void Start()
    {
        stats = transform.parent.GetComponent<Statsinfo>();
    }

    private void Update()
    {
        GetComponent<CapsuleCollider>().center = transform.Find("mixamorig:Hips").localPosition;
    }

    public void BeginAttack()
    {
        ball = Instantiate(ballPrefab, hand.transform.position, Quaternion.identity);
        ball.transform.SetParent(hand);
        ball.GetComponent<Handball>().attacker = transform;
    }

    public void MidAttack()
    {
        if (ball != null)
        {
            ball.transform.SetParent(null);
            ball.GetComponent<Handball>().target = stats.target;
            ball.GetComponent<Handball>().charce = true;
        }
    }


    public void EndAttack()
    {
        GetComponent<Janisarry>().chaseBreak = false;
    }
}
