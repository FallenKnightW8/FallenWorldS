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
  void Update()
  {
    if (Input.GetKeyDown(JobKey))
    {
      Close();
    }
  }
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
  IEnumerator Close()
  {
    Pc.SetActive(false);
    yield return new WaitForSeconds(1);
    TRUE.isTRue = 0;
  }
}
