using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetINputedWeapon : MonoBehaviour
{
  public int PrimaryW;
  public int SecondW;

  public bool InMission = true;

  public WeaponSystem Weapons;

  public GameObject weapon;
  public GameObject pp;
  public GameObject PST;
  public GameObject PWS;
  public GameObject SHT;
  public GameObject SNP;
  public GameObject SHG;

    void Start()
    {
      if (InMission == true)
      {
        // PrimaryW = PlayerPrefs.GetInt("PrimaryW");
        // SecondW = PlayerPrefs.GetInt("SecondW");
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
        else if (PrimaryW == 3)
        {
            Weapons.weapons[1] = SHG;
        }

//secod weapon
        if (SecondW == 0)
        {
          Weapons.weapons[0] = PST;
        }
        else if (SecondW == 1)
        {
          Weapons.weapons[0] = PWS;
        }
      }
      else
      {
        weapon.SetActive(false);
      }
    }
}
