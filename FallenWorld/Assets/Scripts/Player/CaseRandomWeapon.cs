using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseRandomWeapon : MonoBehaviour
{
  public bool IsOpen = false;
  public int lvl = 0;
  public GameObject[] Weapon;


  public void ChangeIsopen (bool amount)
  {
    IsOpen = amount;
  }

    void Update()
    {
      if (IsOpen == true)Open();
    }

    public void Open()
    {
      int IdWeapon = Random.Range(0, 1);
      Instantiate(Weapon[IdWeapon],transform.position,transform.rotation);
      Destroy(gameObject);
    }
}
