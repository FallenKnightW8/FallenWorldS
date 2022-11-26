using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Ranck : MonoBehaviour
{
  public int Rank = 1;
  public Health RankH;
  public EnemyAiTutorial Damag;


    // Start is called before the first frame update
    void Start()
    {
//      maxHealth = GetComponent<Health>().maxHealth;
      switch (Rank)
        {
          case 1:
          RankH.startingHealth +=50;
          RankH.maxHealth += 50;
          Damag.Damage = 5;
            break;

          case 2:
          RankH.maxHealth += 100;
          RankH.startingHealth +=100;
          Damag.Damage = 10;
            break;

          case 3:
          RankH.maxHealth += 150;
          RankH.startingHealth +=150;
          Damag.Damage = 15;
            break;

          default:
            break;
        }
    }
}
