using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallHekp : MonoBehaviour
{
  public GameObject Guy0;
  public float Distance;
  public int countR;
  public Text Counts;

    void Start()
    {
    countR = PlayerPrefs.GetInt("CountR");
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.G))
      {
         Call();
      }
      ShowCounts();
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
     Counts.text = countR.ToString();
    }
}
