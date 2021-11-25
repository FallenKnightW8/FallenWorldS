using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTab : MonoBehaviour
{
  public GameObject MissionUI;
  public GameObject Weapon;

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Tab))
      {
        MissionCanv();
      }
    }

    public void MissionCanv()
    {
      MissionUI.SetActive(true);
      Time.timeScale = 0f;
      Weapon.SetActive(false);
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }

    public void ResumeGame()
    {
      Cursor.lockState = CursorLockMode.Locked;
      Weapon.SetActive(true);
      Cursor.visible = false;
      Time.timeScale = 1f;
      MissionUI.SetActive(false);
    }

}
