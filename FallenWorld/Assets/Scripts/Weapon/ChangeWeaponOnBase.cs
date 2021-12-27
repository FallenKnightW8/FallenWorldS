using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponOnBase : MonoBehaviour
{
  public int Cweap;
  public KeyCode EscButton;
  public GameObject Arsenal;
  public GameObject[] ListWeapon;
//second
    public void PST()
    {
      PlayerPrefs.SetInt("SecondW", 0);
    }

//primary
    public void PP()
    {
      PlayerPrefs.SetInt("PrimaryW", 0);
    }

    public  void SHT()
    {
      PlayerPrefs.SetInt("PrimaryW", 1);
    }

    void Update()
    {
      VieWeapon();
      if (Input.GetKeyDown(EscButton))
      {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Arsenal.SetActive(false);
      }
    }
    public void VieWeapon()
    {
      Cweap = PlayerPrefs.GetInt("BuyedWeapon");
      while (Cweap != -1)
      {
        ListWeapon[Cweap].SetActive(true);
        Cweap -= 1;
      }
    }
}
