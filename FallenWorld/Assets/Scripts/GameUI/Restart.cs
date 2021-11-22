using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    public void loadScene()
  {
    Application.LoadLevel(Application.loadedLevel);
    Time.timeScale = 1f;
  }
}
