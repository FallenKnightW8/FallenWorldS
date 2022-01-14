using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapBase : MonoBehaviour
{
    public KeyCode JobButton;
    public int isTRue;
    public GameObject TXT;
    public GameObject MapB;
    public GameObject Shops;
    public GameObject PC;
    public GameObject Arsenal;

      void Update()
      {
        if (isTRue == 0)ray();
        else
        {
          StartCoroutine(wait());
        }
      }
      IEnumerator wait()
      {
         yield return new WaitForSeconds(1);
      }


      public void ray()
      {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
          if (Physics.Raycast(ray, out hit, 2f))
          {
            if (hit.collider.GetComponent<Map>())
            {
              Map();
            }
          else if (hit.collider.GetComponent<PCSHOP>())
          {
            pc();
          }
          else if (hit.collider.GetComponent<ChangeWeaponOnBase>())
          {
            arsenary();
          }
        }
        else
        {
          TXT.SetActive(false);
        }

      }

      public void pc()
      {
        TXT.SetActive(true);
        if (Input.GetKeyDown(JobButton))
        {
          isTRue = 1;
          PC.SetActive(true);
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;

        }
      }
      public void Map()
      {
        TXT.SetActive(true);
        if (Input.GetKeyDown(JobButton))
        {
          isTRue = 1;
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
          MapB.SetActive(true);
          TXT.SetActive(false);
        }
      }
      public void arsenary()
      {
        TXT.SetActive(true);
        if (Input.GetKeyDown(JobButton))
        {
          isTRue = 1;
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
          Arsenal.SetActive(true);
          TXT.SetActive(false);
        }
      }
}
