using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
  public GameObject Shops;
  public Take Mpoints;
  public int Tpoint;
  void Update()
  {
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
  if (Tpoint>= 1000)
    Tpoint -= 1000;
    PlayerPrefs.SetInt("Points", Tpoint);
}

}