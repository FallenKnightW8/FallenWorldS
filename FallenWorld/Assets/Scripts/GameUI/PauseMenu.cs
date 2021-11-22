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


    void Start()
    {
      PauseUI = transform.GetChild(0).gameObject;
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
      //GameUI.SetActive(false);
      Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
      Cursor.lockState = CursorLockMode.Locked;
      PauseUI.SetActive(false);
      //GameUI.SetActive(true);
      Weapon.SetActive(true);
      Time.timeScale = 1f;
    }

    public void CancellMision()
    {
      SceneManager.LoadScene("PlayerBase");
      Time.timeScale = 1f;
    }

    public void ExitPressed()
        {
          Application.Quit();
          Debug.Log("Exit pressed!");
        }

}
