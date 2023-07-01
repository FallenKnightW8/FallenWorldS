using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class Mission : MonoBehaviour
{
    [Header("RanckOf Mission")]
    private int countOFmissionReady; //counter of value how mani missions have bin complite
    private int TypeOfMission;      //Random of type of target for the player//0 - kill everyware,1 - steal to any summ,2 - open the final voult,3 - destroy to any summ 
    public int RangOfM = 1;        //every 5 complit mission = nwe rang? the final rang is 5? when final boss
    public bool BossOfRangKilled = false;

    private FirstPersonCharacter Locks;
    [Header("Checker")]
    public int CountOfComplitM = 0; 
    public int NeededVaule = 2;     //the vaule what need the player to win
    private Take SavePlPoints;
    [Header("Statistic")]
    [SerializeField] private GameObject Stats;
    [SerializeField] private TMP_Text Timer;
    [SerializeField] private TMP_Text TimerStats;
    private bool onMisssion = true;
    [Header("What Needed to whin")]
    [SerializeField]private TMP_Text CountCom;
    [SerializeField]private TMP_Text CountNeed;
    [SerializeField]private GameObject IMageKE;
    private int RewardFPass = 25;
    
    [SerializeField]private float time = 0f;

    private void Start()
    {
        StartCoroutine(BakeMission());
        if (PlayerPrefs.GetInt("countOFmissionReady") != 0)
            countOFmissionReady = PlayerPrefs.GetInt("countOFmissionReady");
        SavePlPoints = GameObject.Find("PlayerObj").GetComponent<Take>();
        Locks = GameObject.Find("PlayerObj").GetComponent<FirstPersonCharacter>();
        RewardFPass *=  RangOfM;

        if (PlayerPrefs.HasKey("CountOfreadM")) countOFmissionReady = PlayerPrefs.GetInt("CountOfreadM");
        TypeOfMission = Random.Range(0, 0);
        if (countOFmissionReady == 5)
        {
            countOFmissionReady = 0;
            RangOfM += 1;
        }
        RandomType();

    }

    private IEnumerator BakeMission()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<NavMeshSurface>().BuildNavMesh();
        StopAllCoroutines();
    }

    private void Update()
    {
        TimerOnMisssion();
        StartCoroutine(MissionC());
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

    IEnumerator MissionC()
    {
        CountCom.text = CountOfComplitM.ToString();
        CountNeed.text = NeededVaule.ToString();
        Timer.text = time.ToString();
        yield return new WaitForSeconds(10f);
        if (CountOfComplitM == NeededVaule)
        {
            Statistic();
//            CTheMission();
        }
    }

    private void Statistic()
    {
        Stats.SetActive(true);
        Locks.lockCursor = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        onMisssion = false;
        if(TimerStats != null)
        TimerStats.text = time.ToString();
    }

    public void CTheMission()
    {
        countOFmissionReady++;
        SavePlPoints.Point += RewardFPass;
        PlayerPrefs.SetInt("CountOfreadM", countOFmissionReady);
        SavePlPoints.SaveMoney();
        PlayerPrefs.SetInt("countOFmissionReady", countOFmissionReady);
        SceneManager.LoadScene("RoomB");
    }
    private void TimerOnMisssion()
    {
        if(onMisssion) time += Time.deltaTime;
    }
    public void NweRang()
    {
    if(countOFmissionReady == 5 & BossOfRangKilled)//and boss killed
        {
        countOFmissionReady = 0;
        RangOfM ++;
        }
    }


}
