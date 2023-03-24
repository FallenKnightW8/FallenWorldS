using UnityEngine;

public class AmmoBag : MonoBehaviour
{
    [SerializeField]private int TypeOfAm = 0;
    [SerializeField]private Weapon WeaponAmmo;
    [SerializeField] private GameObject[] models;
    private bool Finded = false;
    void Start()
    {
        TypeOfAm = Random.Range(0, 0);
    }

    private void Update()
    {
        if (!Finded)
        switch (TypeOfAm)
        {
            case 0:
                WeaponAmmo = GameObject.FindWithTag("Pistol").GetComponent<Weapon>();
                    models[0].SetActive(true);
                    Finded = true;
                    break;
            case 1:
                WeaponAmmo = GameObject.FindWithTag("PP").GetComponent<Weapon>();
                    Finded = true;
                    models[2].SetActive(true);
                    break;
            case 2:
                WeaponAmmo = GameObject.FindWithTag("SHT").GetComponent<Weapon>();
                    Finded = true;
                    models[2].SetActive(true);
                    break;
            case 3:
                WeaponAmmo = GameObject.FindWithTag("SNP").GetComponent<Weapon>();
                    Finded = true;
                    models[2].SetActive(true);
                    break;
            case 4:
                WeaponAmmo = GameObject.FindWithTag("Shotgan").GetComponent<Weapon>();
                    Finded = true;
                    models[1].SetActive(true);
                    break;
        }
    }

    public void GiveAmmo()
    {
        WeaponAmmo.currentMaxammmo = WeaponAmmo.maxAmmunition;
        Destroy(gameObject);
    }
}
