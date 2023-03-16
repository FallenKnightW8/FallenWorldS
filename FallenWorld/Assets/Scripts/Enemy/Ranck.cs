using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Ranck : MonoBehaviour
{
    [SerializeField]private int Rank = 1;   //lvl of enemy treath
    public Health RankH;                    //Url to chage Hp
    public EnemyAiTutorial Damag;           //Url to Chage Dm
    public Health MFD;                      //URl o Chage MFD

    public GameObject[] EnemyModels;        //or prefabs?

    public Mission countOFEnemis;
    void Start()
    {
        countOFEnemis = GameObject.Find("MissionManager").GetComponent<Mission>();
        countOFEnemis.NeededVaule +=1;
        Debug.Log("work");
        //Rank = Random.Range(1,5);
        //      maxHealth = GetComponent<Health>().maxHealth;
        switch (Rank)
        {
            case 1:
                RankH.startingHealth +=50;
                RankH.maxHealth += 50;
                Damag.Damage = 5;
                MFD.MoneyForDead = 5;
                break;
//spawn enemy

            case 2:
                RankH.maxHealth += 100;
                RankH.startingHealth +=100;
                Damag.Damage = 10;
                MFD.MoneyForDead = 10;
                break;

            case 3:
                RankH.maxHealth += 150;
                RankH.startingHealth +=150;
                Damag.Damage = 15;
                MFD.MoneyForDead = 30;
                break;

            case 4:
                RankH.maxHealth += 200;
                RankH.startingHealth += 200;
                Damag.Damage = 20;
                MFD.MoneyForDead = 60;
                break;

            case 5:
                RankH.maxHealth += 300;
                RankH.startingHealth += 300;
                Damag.Damage = 30;
                MFD.MoneyForDead = 120;
                break;

            default:
            break;
        }
    }
}
