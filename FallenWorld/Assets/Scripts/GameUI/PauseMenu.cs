using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  public GameObject PauseUI;
  //public GameObject  GameUI;
  public bool isPaused = false;
  public GameObject Weapon;
  private int Points;

    void Start()
    {
      PauseUI = transform.GetChild(0).gameObject;
      Points = PlayerPrefs.GetInt("Points");
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        PauseGame();
      }


    }
    public void PauseGame()
    {
      Cursor.lockState = CursorLockMode.None;
      PauseUI.SetActive(true);
      Weapon.SetActive(false);
      Cursor.visible = true;
      Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
      Cursor.lockState = CursorLockMode.Locked;
      Time.timeScale = 1f;
      PauseUI.SetActive(false);
      Cursor.visible = false;
      Weapon.SetActive(true);
    }

    public void CancellMision()
    {
      PlayerPrefs.SetInt("Points", Points);
      SceneManager.LoadScene("PlayerBase");
      Time.timeScale = 1f;
    }

    public void ExitPressed()
        {
          PlayerPrefs.SetInt("Points", Points);
          Application.Quit();
          Debug.Log("Exit pressed!");
        }

}
