using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapBase : MonoBehaviour
{
    public KeyCode JobButton;
    public GameObject TXT;
    public GameObject MapB;

      void Update()
      {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
          if (Physics.Raycast(ray, out hit, 2f))
          {
            if (hit.collider.GetComponent<Map>())
            {
              TXT.SetActive(true);
              if (Input.GetKeyDown(JobButton))
              {
                MapB.SetActive(true);
                TXT.SetActive(false);
            }
          }
        }
        else
        {
          TXT.SetActive(false);
        }

      }
}
