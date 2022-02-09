using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Player;
    public GameObject Item1;
    public int Rand;
    public Transform Spawnpl;
    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;
    void Start()
    {
        Instantiate(Player, Spawnpl.position,Spawnpl.rotation);
        Rand = Random.Range(0,2);
        if (Rand == 0)
        {
        Instantiate(Item1, Spawn1.position,Spawn1.rotation);
        }
        else if (Rand == 1)
        {
        Instantiate(Item1, Spawn2.position,Spawn2.rotation);
        }
        else
        {
        Instantiate(Item1, Spawn3.position,Spawn3.rotation);
        }

    }

}
