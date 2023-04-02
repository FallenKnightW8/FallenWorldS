using UnityEngine;
using UnityEngine.UI;

public class skills : MonoBehaviour
{
    //medic
    public int Count;
    public KeyCode HealButton;
    public int HealHp;
    public Health Hp;
    public Text CountAids;
    //callHelp
    public GameObject Guy0;
    public int countR;
    public Text CountsCH;
    public KeyCode CallHelpButton;

    void Start()

    {
        countR = PlayerPrefs.GetInt("CountR");
        DataHeal();
    }

    void Update()
    {
        Show();
        if (Input.GetKeyDown(HealButton))
        {
            Heal();
        }

    ShowCounts();
    }
    private void DataHeal()
    {
        if (PlayerPrefs.GetInt("ListHasBuyed_1") == 1)
        {
            Count = 1;
            HealHp = 25;
        }
    }
    public void Heal()
    { 
        if (Count >= 1)
        {
            Count -= 1;
            Hp.currentHealth += HealHp;
        }
    }
    public void Show()
    {
        CountAids.text = Count.ToString();
    }

    private void Call()
    {
    if (countR>=1)
        {
            countR -=1;
            Instantiate(Guy0, transform.position,transform.rotation);
        }
    }
    public void  ShowCounts()
    {
        CountsCH.text = Count.ToString();
    }
}
