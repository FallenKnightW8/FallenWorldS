using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapB : MonoBehaviour
{
  public GameObject Mapb;
  public GameObject Shop;
  public GameObject PL;
  public int Mission;
  public void cancell()
  {
    PL = GameObject.FindWithTag("Player");
    PL.GetComponent<PlayerMapBase>().isTRue = 0;
    Mapb.SetActive(false);
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }
  public void FMission()
  {
      Mission = 0;
      PlayerPrefs.SetInt("Mission", Mission);
      SceneManager.LoadScene("reading");
//    SceneManager.LoadScene("FmisiionShop");
  }

}
