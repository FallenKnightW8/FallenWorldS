using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmissionStart : MonoBehaviour
{
  public int Spoint;
    void Start()
    {
      Spoint = PlayerPrefs.GetInt("SPoint");
//      if (Spoint = 0)
    }

}
