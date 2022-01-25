using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
  public Transform Fspawn;
  public Transform Sspawn;
  public GameObject Player;
  public int SpawnsP;

    void Start()
    {
      SpawnsP = PlayerPrefs.GetInt("Spoint");
      SpawnPL();

    }
    public void SpawnPL()
    {
      if (SpawnsP == 0)
      {
        Player.transform.position = Fspawn.transform.position;
      }
      else if (SpawnsP == 2)
      {
        Instantiate(Player, Sspawn.position, Sspawn.rotation);
      }
    }
}
