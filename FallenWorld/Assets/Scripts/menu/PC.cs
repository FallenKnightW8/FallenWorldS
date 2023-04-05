using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC : MonoBehaviour
{
  public PlayerMapBase TRUE;
  public KeyCode JobKey;
  public GameObject SH;
  public GameObject Pc;
  public GameObject Upg;
  private float timeBetween = 1;

  public void Shop()
  {
    SH.SetActive(true);
    Pc.SetActive(false);
  }
  public void Upgrade()
  {
    Upg.SetActive(true);
    Pc.SetActive(false);
  }

}
