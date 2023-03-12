using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Take : MonoBehaviour
{
  public KeyCode takeButton;
  public GameObject TXT;
  public int Point;
  // public TMP_Text test;
  public Text Sc;
  public int Tpoint;
  // public int MoneyFDead;
    void Start()
    {
      TXT = GameObject.FindWithTag("Take");
    }

    void Update()
    {
      SCore();
      Tak();
    }
    public void Tak()
    {
      if (PlayerPrefs.HasKey("Points"))
      {
        Tpoint = PlayerPrefs.GetInt("Points");
      }
      Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
      RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
          if (hit.collider.GetComponent<Item>())
          {
            TXT.SetActive(true);
            if (Input.GetKeyDown(takeButton))
            {
              Point += hit.collider.GetComponent<Item>().Point;
              Destroy(hit.collider.GetComponent<Item>().gameObject);
              TXT.SetActive(false);
              SCore();
              PlayerPrefs.SetInt("Points", Point);
          }
        }
        else if(hit.collider.GetComponent<CaseRandomWeapon>())
        {
          TXT.SetActive(true);
          if (Input.GetKeyDown(takeButton))
            {
              hit.collider.gameObject.SendMessageUpwards("ChangeIsopen", true, SendMessageOptions.DontRequireReceiver);
            }
        }
        else if(hit.collider.GetComponent<CaseWeapon>())
        {
          TXT.SetActive(true);
          if (Input.GetKeyDown(takeButton))
          {
            hit.collider.gameObject.SendMessageUpwards("ChageWeapon", SendMessageOptions.DontRequireReceiver);
          }
        }
    }
    else
    {
      TXT.SetActive(false);
    }
  }
  public void PlayerGM(int Mon)
  {
    Point += Mon;

  }

    public void SCore()
    {
      Sc.text = Point.ToString();
    }
}