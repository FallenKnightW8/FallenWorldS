using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
  public GameObject[] bull;
  public GameObject[] coop;
  public GameObject Shops;
  public Take Mpoints;
  public int Tpoint;
  public int Cops;
  public int Buyd;
  void Update()
  {
    bull[Buyd].SetActive(true);
    coop[Cops].SetActive(true);
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

  public void bull1()
{
  if (Tpoint>= 0)
  {
    Tpoint -= 0;
    PlayerPrefs.SetInt("BuyedWeapon", 1);
    PlayerPrefs.SetInt("Points", Tpoint);
    Buyd = 1;
  }
}
  public void Coop1()
  {
    PlayerPrefs.SetInt("CountsAid", 1);
    PlayerPrefs.SetInt("AidHP", 25);
    Cops = 1;
  }
}
