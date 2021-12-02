using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuControls : MonoBehaviour
{
  public GameObject ConT;
    void Update()
    {
      if (PlayerPrefs.HasKey("Points"))
      {
        ConT.SetActive(true);
      }
    }
  public void PlayPressed()
      {
          SceneManager.LoadScene("Base");
      }
  public void ExitPressed()
      {
          Application.Quit();
          Debug.Log("Exit pressed!");
      }

  public void Continue()
  {
    SceneManager.LoadScene("PlayerBase");
  }

}
