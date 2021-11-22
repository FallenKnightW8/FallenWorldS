using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapB : MonoBehaviour
{
  public GameObject Mapb;
  public void cancell()
  {
    Mapb.SetActive(false);
  }
  public void FMission()
  {
    SceneManager.LoadScene("FmisiionShop");
  }

}
