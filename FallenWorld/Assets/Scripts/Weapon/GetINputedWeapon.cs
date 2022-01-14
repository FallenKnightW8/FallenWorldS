using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetINputedWeapon : MonoBehaviour
{
  public int PrimaryW;
  public int SecondW;

  public WeaponSystem Weapons;

  public GameObject pp;
  public GameObject PST;
  public GameObject SHT;
  public GameObject SNP;

    void Start()
    {
      PrimaryW = PlayerPrefs.GetInt("PrimaryW");
      SecondW = PlayerPrefs.GetInt("SecondW");
//primary weapon check
      if (PrimaryW == 0)
      {
        Weapons.weapons[1] = pp;
      }
      else if(PrimaryW == 1)
      {
        Weapons.weapons[1] = SHT;
      }
      else if(PrimaryW == 2)
      {
        Weapons.weapons[1] = SNP;
      }

//secod weapon
      if (SecondW == 0)
      {
        Weapons.weapons[0] = PST;
      }

    }
}
