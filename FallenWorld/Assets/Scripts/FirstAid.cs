using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAid : MonoBehaviour
{
  public int Count;
  public KeyCode HealButton;
  public int HealHp;
  public Health Hp;
  public Text CountC;

void Start()
{
  HealHp = PlayerPrefs.GetInt("AidHP");
  Count = PlayerPrefs.GetInt("CountsAid");
}
    void Update()
    {
      Show();
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
    public void Show()
    {
      CountC.text = Count.ToString();
    }
}
