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
    // public int MoneyFDead;

    private int IdOfweapon;
    [SerializeField] public WeaponSystem WEap;
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
                }
            }
            else if (hit.collider.GetComponent<SpawnRandomWeapon>())
            {
                TXT.SetActive(true);
                if (Input.GetKeyDown(takeButton))
                {
                    hit.collider.gameObject.SendMessageUpwards("destroy", SendMessageOptions.DontRequireReceiver);
                    IdOfweapon = hit.collider.GetComponent<SpawnRandomWeapon>().IdOfWeapon;
                    WEap.PrimaryW = IdOfweapon + 1;
                }
            }
            else if (hit.collider.CompareTag("AmmoBag"))
            {
                TXT.SetActive(true);
                if (Input.GetKeyDown(takeButton))
                    hit.collider.gameObject.SendMessageUpwards("GiveAmmo", SendMessageOptions.DontRequireReceiver);
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

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("Points", Point);
    }

    public void SCore()
    {
        Sc.text = Point.ToString();
    }
}
