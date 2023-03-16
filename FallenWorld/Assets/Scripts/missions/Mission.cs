using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Mission : MonoBehaviour
{
    private int countOFmissionReady;
    private int TypeOfMission;
    private int RangOfM = 1;

    public int CountOfComplitM = 0;
    public int NeededVaule = 2;
    [SerializeField]private TMP_Text CountCom;
    [SerializeField] private TMP_Text CountNeed;
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
