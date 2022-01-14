using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponShop : MonoBehaviour
{
  public PlayerMapBase TRUE;
  public KeyCode jobKey;
  public GameObject Pc;
  public GameObject WeapS;
    // Start is called before the first frame update
    void Update()
    {
      if (Input.GetKeyDown(jobKey))
      {
        Ex();
      }
    }
    public void Ex()
    {
      WeapS.SetActive(false);
      TRUE.isTRue = 0;
      StopCoroutine ("Ex");
    }
}
