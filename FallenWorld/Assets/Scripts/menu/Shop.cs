using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
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
    Weapons[Weapon].SetActive(true);
    Upgrades[Upgrade].SetActive(true);
    Helps[Help].SetActive(true);
    if (PlayerPrefs.HasKey("Points"))
    {
      Tpoint = PlayerPrefs.GetInt("Points");
    }
  }

  public void cancell()
  {
    Shops.SetActive(false);
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

  public void Weapon1()
{
  if (Tpoint>= 0)
  {
    Tpoint -= 0;
    PlayerPrefs.SetInt("BuyedWeapon", 1);
    PlayerPrefs.SetInt("Points", Tpoint);
    Weapon = 1;
  }
}
  public void Weapon2()
  {
    if (Tpoint>= 50000)
    {
      Tpoint -= 50000;
      PlayerPrefs.SetInt("Points", Tpoint);
      Weapon = 2;
    }
  }
  public void Weapon3()
  {
    if (Tpoint>=200000)
    {
      Tpoint-=200000;
      PlayerPrefs.SetInt("Points",Tpoint);
      Weapon = 3;
      PlayerPrefs.SetInt("BuyedWeapon", 2);
    }
  }
  public void Upgrade1()
  {
    PlayerPrefs.SetInt("CountsAid", 1);
    PlayerPrefs.SetInt("AidHP", 25);
    Upgrade = 1;
  }
  public void Upgrade2()
  {
    if (Tpoint>=45000)
    {
      Tpoint -= 45000;
      PlayerPrefs.SetInt("CountsAid", 1);
      PlayerPrefs.SetInt("AidHP", 35);
      Upgrade = 2;
    }
  }
  public void CallHelp1()
  {
    PlayerPrefs.SetInt("CountR", 1);
    PlayerPrefs.SetInt("LevelGuy", 0);
//    Help = 1;
  }
}
