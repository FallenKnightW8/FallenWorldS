using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dor : MonoBehaviour
{
  public bool Opened = false;
  public Animator anim;
    // Update is called once per frame

    void Update()
    {
      if (Opened == true)
      {
         anim.Play("open");
      }
      else if (Opened == false)
      {
        anim.Play("close");
      }
    }
    public void CHS()
    {
      if (Opened == true)
      {
        Opened = false;
      }
      else
      {
        Opened = true;
      }
    }
}
