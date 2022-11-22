using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skills : MonoBehaviour
{
  //medic
  public int Count;
  public KeyCode HealButton;
  public int HealHp;
  public Health Hp;
  public Text CountAids;
  //callHelp
  public GameObject Guy0;
  public float Distance;
  public int countR;
  public Text CountsCH;
  public KeyCode CallHelpButton;

  void Start()

  {
  countR = PlayerPrefs.GetInt("CountR");
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
     if (Input.GetKeyDown(CallHelpButton))
    {
       Call();
    }
    ShowCounts();
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
    CountAids.text = Count.ToString();
  }

  private void Call()
  {
    if (countR>=1)
      {
        countR -=1;
        Instantiate(Guy0, transform.position,transform.rotation);
      }
  }
  public void  ShowCounts()
  {
   CountsCH.text = countR.ToString();
  }
}
