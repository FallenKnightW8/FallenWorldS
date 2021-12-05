using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBase : MonoBehaviour
{
  public GameObject Tutorial;
    void Update()
    {
      if (PlayerPrefs.HasKey("Points"))
      {
        Tutorial.SetActive(false);
      }
    }
}
