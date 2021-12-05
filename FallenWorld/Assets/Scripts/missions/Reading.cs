using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reading : MonoBehaviour
{
  public GameObject shop;
  public int Mission;
  public int Spoint;
    // Start is called before the first frame update
    void Start()
    {
      Mission = PlayerPrefs.GetInt("Mission");
    }
    void Update()
    {
      MissionPrefabs();
    }
    public void MissionPrefabs()
    {
      if (Mission == 0)
      {
        shop.SetActive(true);
      }

    }
    public void StartM()
    {
      if (Mission == 0)
      {
        SceneManager.LoadScene("FmisiionShop");
      }
    }
    public void SPoint1()
    {
      Spoint = 0;
      PlayerPrefs.SetInt("Spoint", Spoint);
    }
    public void Spoint2()
    {
      Spoint = 1;
      PlayerPrefs.SetInt("Spoint", Spoint);
    }



}
