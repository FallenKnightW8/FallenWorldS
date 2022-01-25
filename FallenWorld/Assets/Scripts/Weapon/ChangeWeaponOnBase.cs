using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponOnBase : MonoBehaviour
{
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

    public void SHT()
    {
      PlayerPrefs.SetInt("PrimaryW", 1);
    }

    void Update()
    {
//      VieWeapon();
    }
    public void VieWeapon()
    {
      ListWeapon[0].SetActive(true);
//PlayerPrefs.GetInt("PPUnlock") + PlayerPrefs.GetInt("SHTUnlock");
      if (PlayerPrefs.HasKey("PPUnlock"))ListWeapon[1].SetActive(true);
      if (PlayerPrefs.HasKey("SHTUnlock"))ListWeapon[2].SetActive(true);
    }
}
