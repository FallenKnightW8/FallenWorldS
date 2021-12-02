using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Take : MonoBehaviour
{
  public KeyCode takeButton;
  public GameObject TXT;
  public Item Point;
  public int Points;
  public Text Sc;
  public int Tpoint;
  public run Chek;


    void Update()
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
              Point.point();
              Tpoint = Points + Tpoint;
              Destroy(hit.collider.GetComponent<Item>().gameObject);
              TXT.SetActive(false);
              SCore();
              Points = 0;
              Chek.point = Tpoint;
              PlayerPrefs.SetInt("Points", Tpoint);
          }
        }
      }
      else
      {
        TXT.SetActive(false);
      }
    }
    public void SCore()
    {
      Sc.text = Tpoint.ToString();
    }
}
