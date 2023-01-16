using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseWeapon : MonoBehaviour
{
  public int typeW; //0 is secondary 1 primary
  public int WeaponId;


  public void ChageWeapon()
  {switch (typeW)
    {
      case 0:
      PlayerPrefs.SetInt("PrimaryW",WeaponId);
      WDestroy();
      break;
      case 1:
      PlayerPrefs.SetInt("SecondW",WeaponId);
      WDestroy();
      break;
    }
  }
  public void WDestroy()
  {
    Destroy(gameObject);
  }
}
