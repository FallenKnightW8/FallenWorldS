using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
  public KeyCode takeButton;

    void Update()
    {
      if (Input.GetKeyDown(takeButton))
      {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
          if (hit.collider.GetComponent<Item>())
          {
            Destroy(hit.collider.GetComponent<Item>().gameObject);
          }
        }
      }

    }
}
