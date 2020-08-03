using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NearEnemies : MonoBehaviour
{

    public List<Transform> enemies = new List<Transform>();

    Statsinfo stats;


    private void Start()
    {
        stats = transform.parent.GetComponent<Statsinfo>();
    }

    private void Update()
    {
    }

    public void UpdateEnemies()
    {
        for (int i = 0; i < enemies.Count(); i++)
        {
            //enemies[i]
            if (enemies[i] == null || !enemies[i].parent.GetComponent<Statsinfo>().isAlive)
            {
                enemies.RemoveAt(i);
            }
        }
    }

    public Transform GetNearest()
    {
        Transform nearest = null;
        float dist = stats.attackRange;
        for (int i = 0; i < enemies.Count(); i++)
        {
            if (enemies[i] == null || !enemies[i].parent.GetComponent<Statsinfo>().isAlive)
            {
                enemies.RemoveAt(i);
            }
            else if (Vector3.Distance(enemies[i].transform.position, transform.position) < dist+1)
            {
                nearest = enemies[i].transform;
                dist = Vector3.Distance(enemies[i].transform.position, transform.position);
            }
        }
        return nearest;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Any Team") && stats.GetEnemies().Contains(other.transform.parent.tag))
        {
            enemies.Add(other.transform);
            UpdateEnemies();
            if (enemies.Count() == 1)
            {
                transform.parent.Find("Creep").GetComponent<Janisarry>().state = "chasing";
                transform.parent.GetComponent<Statsinfo>().target = other.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Any Team") && stats.GetEnemies().Contains(other.transform.parent.tag))
        {
            enemies.Remove(other.transform);
        }
    }
}
