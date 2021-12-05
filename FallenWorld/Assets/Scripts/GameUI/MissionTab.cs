using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTab : MonoBehaviour
{
  public GameObject MissionUI;
  public GameObject Weapon;
  private int TabHaspred;

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Tab))
      {
        if (TabHaspred == 0)
        {
          MissionCanv();
        }
        else
        {
          ResumeGame();
        }
      }
    }

    public void MissionCanv()
    {
      TabHaspred = 1;
      MissionUI.SetActive(true);
      Time.timeScale = 0f;
      Weapon.SetActive(false);
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }

    public void ResumeGame()
    {
      TabHaspred = 0;
      Cursor.lockState = CursorLockMode.Locked;
      Weapon.SetActive(true);
      Cursor.visible = false;
      Time.timeScale = 1f;
      MissionUI.SetActive(false);
    }

}
