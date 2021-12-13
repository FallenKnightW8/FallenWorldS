using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIm : MonoBehaviour
{
  public Transform Camera1;
  public bool aim = true;

  void start()
  {
  Camera1.GetComponent<Camera>();
  Debug.Log("1");
  }
    void Update()
    {
      if (Input.GetMouseButtonDown(1) & aim==true)
      {

        CAM();
      }
    }

    private void CAM()
    {
      if (aim = true)
      {
      Camera1.GetComponent<Camera>().fieldOfView = 10;
      Camera1.GetComponent<Camera>().depth = 2;
      Debug.Log("lol");
      }
    }
}
