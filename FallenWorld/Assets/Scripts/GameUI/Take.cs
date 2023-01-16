using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Take : MonoBehaviour
{
  public KeyCode takeButton;
  public GameObject TXT;
  public int Point;
  public Text Sc;
  public int Tpoint;
  public run Chek;
  public int Card = 0;
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
              Chek.point = Point;
              PlayerPrefs.SetInt("Points", Point);
          }
        }
      else if (hit.collider.GetComponent<Card>())
      {
        TXT.SetActive(true);
          if (Input.GetKeyDown(takeButton))
          {
            Card += 1;
            TXT.SetActive(false);
              Destroy(hit.collider.GetComponent<Card>().gameObject);
          }
        }
        else if (hit.collider.GetComponent<Unlock>())
        {
          if (Input.GetKeyDown(takeButton))
            {
              Card -= 1;
              TXT.SetActive(false);
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
      else
      {
        TXT.SetActive(false);
      }
    }
  }
    public void SCore()
    {
      Sc.text = Point.ToString();
    }
}
