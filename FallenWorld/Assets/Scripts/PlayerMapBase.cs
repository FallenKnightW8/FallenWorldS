using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapBase : MonoBehaviour
{
    public KeyCode JobButton;

    private float timeBetween = 1;
    public int isTRue;

    public GameObject TXT;

    public GameObject MapB;
    public GameObject Shops;
    public GameObject Wshop;
    public GameObject PC;
    public GameObject Arsenal;
    public ChangeWeaponOnBase job;

      void Start()
      {
        timeBetween = 1 % 100000;
      }
      void Update()
      {
        Check();
      }
      public void Check()
      {
        if (Input.GetKeyDown(JobButton) && isTRue == 1)Close();//Invoke(nameof(Close2), timeBetween);
        if (isTRue == 0)Invoke(nameof(ray), timeBetween);

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
          job.VieWeapon();
          isTRue = 1;
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
          Arsenal.SetActive(true);
          TXT.SetActive(false);
        }
      }
      public void Close2()
      {
        isTRue = 0;
      }
      public void Close()
      {
        isTRue = 0;
        MapB.SetActive(false);
        PC.SetActive(false);
        Arsenal.SetActive(false);
        Shops.SetActive(false);
        Wshop.SetActive(false);
        Cursor.visible = false;
      }
}
