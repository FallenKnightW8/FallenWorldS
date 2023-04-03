using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    public FirstPersonCharacter MousLoker;
    //public GameObject  GameUI;
    public bool isPaused = false;
    public GameObject Weapon;
    private int Points;

    void Start()
    {
        PauseUI = transform.GetChild(0).gameObject;
        Points = PlayerPrefs.GetInt("Points");
        MousLoker = GameObject.Find("PlayerObj").GetComponent<FirstPersonCharacter>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            MousLoker.lockCursor = false;
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
        MousLoker.lockCursor = true;
        Time.timeScale = 1f;
        Weapon.SetActive(true);
        PauseUI.SetActive(false);
        Cursor.visible = false;
    }

    public void CancellMision()
    {
        PlayerPrefs.SetInt("Points", Points);
        SceneManager.LoadScene("RoomB");
        Time.timeScale = 1f;
    }

    public void ExitPressed()
        {
            PlayerPrefs.SetInt("Points", Points);
            Application.Quit();
            Debug.Log("Exit pressed!");
        }

}
