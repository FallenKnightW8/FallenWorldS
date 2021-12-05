using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
  private int Points;
  void Start()
  {
    Points = PlayerPrefs.GetInt("Points");
  }
    public void loadScene()
  {
    PlayerPrefs.SetInt("Points", Points);
    Application.LoadLevel(Application.loadedLevel);
    Time.timeScale = 1f;
  }
}
