using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
  public KeyCode jobButton;
  public GameObject PC;
  public GameObject UPG;

  public GameObject[] Weapons;
  public GameObject[] Upgrades;
  public GameObject[] Helps;
  public GameObject Shops;

  public Take Mpoints;
  public int Tpoint;
  public int Upgrade;
  public int Weapon;
  public int Help;
  void Update()
  {
    if (Input.GetKeyDown(jobButton))
    {
      Close();
    }
    UpdateSH();
    if (PlayerPrefs.HasKey("Points"))
    {
      Tpoint = PlayerPrefs.GetInt("Points");
    }
    Weapon = PlayerPrefs.GetInt("Weapon");
    Upgrade = PlayerPrefs.GetInt("Upgrade");
    Help = PlayerPrefs.GetInt("Help");
  }
  public void Close()
  {
//    PC.SetActive(true);
    UPG.SetActive(false);
  }
  public void UpdateSH()
  {
    while (Weapon !=0)
    {
      Weapon -= 1;
      Weapons[Weapon].SetActive(true);
    }
    while (Upgrade != 0)
    {
      Upgrade -= 1;
      Upgrades[Upgrade].SetActive(true);
    }
    while (Help != 0)
    {
      Help -= 1;
      Helps[Help].SetActive(true);
    }
  }

  public void cancell()
  {
    Shops.SetActive(false);
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

//ungrace damage to all Weapon
  public void Weapon1()
{
  if (Tpoint>= 10000)
  {
    Tpoint -= 10000;
    PlayerPrefs.SetInt("BulletsUp", 1);
    PlayerPrefs.SetInt("Points", Tpoint);
    PlayerPrefs.SetInt("Weapon", 2);
  }
}
  public void Weapon2()
  {
    if (Tpoint>= 50000)
    {
      Tpoint -= 50000;
      PlayerPrefs.SetInt("Points", Tpoint);
      PlayerPrefs.SetInt("Weapon", 3);
    }
  }
  public void Weapon3()
  {
    if (Tpoint>=200000)
    {
      Tpoint-=200000;
      PlayerPrefs.SetInt("Points",Tpoint);
      PlayerPrefs.SetInt("Weapon", 4);
    }
  }
  public void Upgrade1()
  {
    if (Tpoint >= 10000 )
    {
      Tpoint -= 10000;
    PlayerPrefs.SetInt("CountsAid", 1);
    PlayerPrefs.SetInt("AidHP", 25);
    PlayerPrefs.SetInt("Upgrade", 2);
    }
  }
  public void Upgrade2()
  {
    if (Tpoint>=45000)
    {
      Tpoint -= 45000;
      PlayerPrefs.SetInt("CountsAid", 1);
      PlayerPrefs.SetInt("AidHP", 35);
      PlayerPrefs.SetInt("Upgrade", 3);
    }
  }
  public void CallHelp1()
  {
    if(Tpoint >= 10000)
    {
      Tpoint -= 10000;
    PlayerPrefs.SetInt("CountR", 1);
    PlayerPrefs.SetInt("LevelGuy", 0);
    PlayerPrefs.SetInt("Help", 2);
    }
  }
}
