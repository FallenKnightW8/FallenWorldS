using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : MonoBehaviour
{
  public int Count;
  public KeyCode HealButton;
  public int HealHp;
  public Health Hp;

    void Update()
    {
      if (Input.GetKeyDown(HealButton))
      {
        Heal();
      }
    }
    public void Heal()
    { if (Count >= 1)
      {
        Count -= 1;
        Hp.currentHealth += HealHp;
      }
    }

}
