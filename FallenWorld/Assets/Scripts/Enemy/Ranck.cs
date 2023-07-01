using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Ranck : MonoBehaviour
{
    [SerializeField] private bool IsBoss = false;
    [SerializeField]private int Rank = 1;   //lvl of enemy treath
    public Health RankH;                    //Url to chage Hp
    public EnemyAiTutorial Damag;           //Url to Chage Dm
    public Health MFD;                      //URl o Chage MFD

    public GameObject[] EnemyModels;        //or prefabs?
    private Mission GetTheRangOfMission;
    private int MultiplerOutRang;
    public Mission countOFEnemis;           //The First Type of mission
    void Start()
    {
        countOFEnemis = GameObject.Find("MissionManager").GetComponent<Mission>();
        countOFEnemis.NeededVaule +=1;
        GetTheRangOfMission = GameObject.Find("MissionManager").GetComponent<Mission>();
        MultiplerOutRang = GetTheRangOfMission.RangOfM;
        if (!IsBoss)
            Rank = Random.Range(1,5);
        //      maxHealth = GetComponent<Health>().maxHealth;
        switch (Rank)
        {
            case 1: //pistol,PP
                RankH.startingHealth +=50;
                RankH.maxHealth += 50;
                MFD.MoneyForDead *= 2 * MultiplerOutRang;
                break;
//spawn enemy

            case 2://shield,Rifle,shotgan
                RankH.maxHealth += 100;
                RankH.startingHealth +=100;
                MFD.MoneyForDead *= 2 * MultiplerOutRang;
                break;

            case 3://long rifle,medic,shotgan
                RankH.maxHealth += 150;
                RankH.startingHealth +=150;
                MFD.MoneyForDead *= 3 * MultiplerOutRang;
                break;

            case 4:
                RankH.maxHealth += 200;
                RankH.startingHealth += 200;
                MFD.MoneyForDead *= 3 * MultiplerOutRang;
                break;

            case 5://bosses,jager,fireman
                RankH.maxHealth += 300;
                RankH.startingHealth += 300;
                MFD.MoneyForDead *= 5 * MultiplerOutRang;
                break;

            default:
            break;
        }
    }
}
