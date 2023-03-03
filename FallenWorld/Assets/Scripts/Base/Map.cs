using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
  public GameObject Question;


  public void QuestM()
  {
    Question.SetActive(true);
  }

  public void ButtonCan()
  {
    Question.SetActive(false);
  }

  public void ButtonYes()
  {
    Question.SetActive(false);
    StartMission();
  }

  private void StartMission()
  {
   SceneManager.LoadScene("Mission");
  }

}
