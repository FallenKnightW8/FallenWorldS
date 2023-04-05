using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoop : MonoBehaviour
{
    [SerializeField] private GameObject[] Spawns;
    [SerializeField] private GameObject[] PrefabsToSpawns;

    private void Start()
    {
        for (int i = 1; i!=5;i++)
        {
            if (PlayerPrefs.GetInt("SaveMember" + i) != 0)
                Instantiate(PrefabsToSpawns[PlayerPrefs.GetInt("SaveMember" + i)], Spawns[i-1].transform.position, Quaternion.identity);
            else break;
        }
    }
}
