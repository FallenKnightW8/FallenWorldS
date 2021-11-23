using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
  public KeyCode takeButton;
  public GameObject TXT;
  public Item Point;
  public int Points;
//  public Text SC;
    void Update()
    {
      Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
      RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
          if (hit.collider.GetComponent<Item>())
          {
            TXT.SetActive(true);
            if (Input.GetKeyDown(takeButton))
            {
              Point.point();
              Destroy(hit.collider.GetComponent<Item>().gameObject);
              TXT.SetActive(false);
//              SC.text = "0" + Points.ToString();

          }
        }
      }
      else
      {
        TXT.SetActive(false);
      }
/*      if (Input.GetKeyDown(takeButton))
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
      }*/

    }
}
