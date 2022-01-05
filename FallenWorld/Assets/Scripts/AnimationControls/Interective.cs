using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interective : MonoBehaviour
{
  public float Distance = 5f;

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Distance))
        {
          Debug.DrawLine(transform.position,transform.forward);
          if (hit.collider.GetComponent<Dor>())
          {
            hit.collider.gameObject.SendMessageUpwards("CHS", SendMessageOptions.DontRequireReceiver);
          }
      }
    }
  }
}
