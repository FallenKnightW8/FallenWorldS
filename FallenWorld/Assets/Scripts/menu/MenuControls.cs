using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuControls : MonoBehaviour
{
  public GameObject ConT;
  public GameObject Check;
    void Update()
    {
      if (PlayerPrefs.HasKey("Points"))
      {
        ConT.SetActive(true);
      }
    }
  public void PlayPressed()
      {
        Check.SetActive(true);
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
  public void PlayerCLyess()
  {
    SceneManager.LoadScene("Base");
    PlayerPrefs.DeleteAll();
  }
  public void PlayerCLNo()
  {
    Check.SetActive(false);
  }

}
