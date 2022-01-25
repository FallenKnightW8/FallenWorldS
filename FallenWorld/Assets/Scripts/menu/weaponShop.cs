using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponShop : MonoBehaviour
{
  public GameObject Weap;
  public GameObject Arm;
  public GameObject Intr;
    void Update()
    {

    }
    public void Weapons()
    {
      Weap.SetActive(true);
      Arm.SetActive(false);
      Intr.SetActive(false);
    }
    public void Armor()
    {
      Arm.SetActive(true);
      Weap.SetActive(false);
      Intr.SetActive(false);
    }
    public void Instruments()
    {
      Intr.SetActive(true);
      Weap.SetActive(false);
      Arm.SetActive(false);
    }

    public void PP()
    {
      PlayerPrefs.SetInt("PPUnlock", 1);
    }
    public void SHT()
    {
      PlayerPrefs.SetInt("SHTUnlock", 1);
    }


//    public void Close()
//    {
//      Weap.SetActive(false);
//      Arm.SetActive(false);
//      Intr.SetActive(false);
//    }
//
}
