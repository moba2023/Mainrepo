using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statsinfo : MonoBehaviour
{

    [Header("Vigor")]

    public bool isAlive;

    public int maxHealth;
    public int curHealth;


    public Transform target;


    public float attackRange;










    public void DamageTaken(int damage, Transform attacker)
    {
        curHealth -= damage;
    }

    public string[] GetEnemies()
    {
        return enemyTeams;
    }

    string[] enemyTeams = new string[2];
    private void Start()
    {
        if (tag == "Team Blue")
        {
            enemyTeams = new string[]{ "Team Red", "Team Green"};
        }
        else if (tag == "Team Red")
        {
            enemyTeams = new string[] {"Team Blue", "Team Green"};
        }
        else if (tag == "Team Green")
        {
            enemyTeams = new string[] {"Team Red", "Team Blue"};
        }
    }
}
