using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
  public GameObject Shops;
  public Take Mpoints;

  public void cancell()
  {
    Shops.SetActive(false);
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

  public void bull1()
{
  if (Mpoints.Tpoint>= 1000)
    Mpoints.Tpoint -= 1000;
}

}
