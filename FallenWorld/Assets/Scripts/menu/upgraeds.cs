using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgraeds : MonoBehaviour
{
    [Header("NeededToWork")]

    private bool HaveM;
    public  GameObject Rpanel;
    [SerializeField] private GameObject ButtonOfBuy;
    public Text NameofP;
    public Text DescriptionP;
    public Text PriceText;
    private string nameP = "one";
    private string desc = "two";
    private int Price = 0;
    private Take HavePoints;

    [Header("Save")]

    public GameObject[] SkillsButons;
    public int[] ListHasBuyed = new int[50];
    private int CountOfBuyed;
    private int Selected;

    [Header("Animation")]

    [SerializeField]private Animator anim;

    private void Awake()
    {
        HavePoints = GameObject.Find("PlayerObj").GetComponent<Take>();
        CountOfBuyed = PlayerPrefs.GetInt("ListHasBuyed_count");
        for (int i = 0; i < CountOfBuyed; i++)
            ListHasBuyed[i] = PlayerPrefs.GetInt("ListHasBuyed_" + i);
        for (int i = 0; i != ListHasBuyed.Length; i++)
        {
            SkillsButons[ListHasBuyed[i]].SetActive(true);
        }
    }


    public void OpenDes(bool HaveM)
    {
        anim.SetBool("OpenedShop", true);
        NameofP.text = nameP;
        DescriptionP.text = desc;
        PriceText.text = Price.ToString();
        if (Price > HavePoints.Point)
        {
            PriceText.GetComponent<Text>().color = new Color(255, 0, 0);
            ButtonOfBuy.SetActive(false);
        }
        else
        {
            PriceText.GetComponent<Text>().color = new Color(0, 255, 0);
            ButtonOfBuy.SetActive(true);
        }
    }

    private void SaveBuyed()
    {
        PlayerPrefs.SetInt("ListHasBuyed_count", ListHasBuyed.Length);

        for (int i = 0; i < ListHasBuyed.Length; i++)
            PlayerPrefs.SetInt("ListHasBuyed_" + i, ListHasBuyed[i]);
    }
    //button to buy
    public void ButtonTobuy()
    {
        HavePoints.Point -= Price;
        HavePoints.SaveMoney();
        ListHasBuyed[Selected] = Selected;
        SkillsButons[ListHasBuyed[Selected]].SetActive(true);

        SaveBuyed();
    }
    // Skills to buy
    public void FirstAid()
    {
        nameP = "FirstAid";
        desc = "You take one First aid, to reastore you health. Press Q to use it.";
        Price = 100;
        Selected = 1;
        OpenDes(true);//+buff damage,+buff speed,+more health
    }

    public void AnubitionOnmission()
    {
        nameP = "AnubitionOnmission";
        desc = "Now In Mission Spawn Ammunition";
        Selected = 5;
        Price = 100;
        OpenDes(false);
    }

    public void Rober()
    {
        nameP = "Master of robery";
        desc = "you get more money";
        Selected = 7;
        Price = 200;
        OpenDes(false);
    }

    public void ChangeWeaponOnBase()
    {
        nameP = "ArmoryOnBase";
        desc = "you can change secondory weapon on base";
        Selected = 4;
        Price = 100;
        OpenDes(false);
    }

    public void Crew()
    {
        nameP = "Crew";
        desc = "You start with member of you band";
        Selected = 6;
        Price = 100;
        OpenDes(true);//more damag,more defens,
    }

    public void SwanSong()
    {
        nameP = "Swan Song";
        desc = "When you health = 0, you not die. You have 4 seconds to kill 3 enemis and restor health, else you die.";
        Selected = 0;
        Price = 200;
        OpenDes(true);//kill 1 enemy but heath 25% and less time, restore no 50% heatl them 100% and less time, 
    }

}
