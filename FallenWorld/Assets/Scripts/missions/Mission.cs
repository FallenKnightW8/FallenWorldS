using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Mission : MonoBehaviour
{
    private int countOFmissionReady; //counter of value how mani missions have bin complite
    private int TypeOfMission;      //Random of type of target for the player//0 - kill everyware,1 - steal to any summ,2 - open the final voult,3 - destroy to any summ 
    private int RangOfM = 1;        //every 5 complit mission = nwe rang? the final rang is 5? when final boss

    public int CountOfComplitM = 0; 
    public int NeededVaule = 2;     //the vaule what need the player to win

    [SerializeField]private TMP_Text CountCom;
    [SerializeField]private TMP_Text CountNeed;
    [SerializeField]private GameObject IMageKE;

    private void Start()
    {
        if (PlayerPrefs.HasKey("CountOfreadM")) countOFmissionReady = PlayerPrefs.GetInt("CountOfreadM");
        TypeOfMission = Random.Range(0, 0);
        if (countOFmissionReady == 5)
        {
            countOFmissionReady = 0;
            RangOfM += 1;
        }
        RandomType();

    }

    private void Update()
    {
        MissionC();
    }

    public void RandomType()
    {
        switch(TypeOfMission)
        {
            case 1://Kill Evreware
                IMageKE.SetActive(true);
                break;
        }
    }

    private void MissionC()
    {
        CountCom.text = CountOfComplitM.ToString();
        CountNeed.text = NeededVaule.ToString();
        if (CountOfComplitM == NeededVaule)
        {
            CTheMission();
        }
    }

    private void CTheMission()
    {
        countOFmissionReady++;
        PlayerPrefs.SetInt("CountOfreadM", countOFmissionReady);
        SceneManager.LoadScene("RoomB");
    }

}
