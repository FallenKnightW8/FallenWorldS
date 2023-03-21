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

    [SerializeField] private GameObject Stats;
    [SerializeField] private TMP_Text Timer;
    private bool onMisssion = true;

    [SerializeField]private TMP_Text CountCom;
    [SerializeField]private TMP_Text CountNeed;
    [SerializeField]private GameObject IMageKE;

    [SerializeField]private float time = 0f;

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
        TimerOnMisssion();
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
        Timer.text = time.ToString();
        if (CountOfComplitM == NeededVaule & time >=10)
        {
            Statistic();
        }
    }

    private void Statistic()
    {

    }

    private void CTheMission()
    {
        countOFmissionReady++;
        PlayerPrefs.SetInt("CountOfreadM", countOFmissionReady);
        SceneManager.LoadScene("RoomB");
    }
    private void TimerOnMisssion()
    {if(onMisssion) time += Time.deltaTime;
    }


}
