using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crewChoise : MonoBehaviour
{
    [Header("Paint Part")]
    [SerializeField] private Image First;
    [SerializeField] private Image Second;
    [SerializeField] private Image Thret;
    [SerializeField] private Image Fourth;
    [SerializeField] private Sprite[] ColectionOfMembers;
    [Header("Buton Part")]
    [SerializeField] private GameObject TheButtonsOfchoise;
    [SerializeField] private GameObject Shield;

    [Header("Logic")]
    private int ToSaveMember;
    private int ToSaveSlot;
    private Sprite ToChange;


    private void Start()
    {
        if (PlayerPrefs.GetInt("ListHasBuyed_6") == 6) Shield.SetActive(true);

    }
    public void buttonOfChois(int Value)
    {
        TheButtonsOfchoise.SetActive(true);
        ToSaveMember = Value;
        ToChange = ColectionOfMembers[Value];
    }

    public void ButtonOfSlotMember(int Value)
    {
        ToSaveSlot = Value;
        SaveTheChoise();
        TheButtonsOfchoise.SetActive(false);
        switch (Value)
        {
            case 1:
                First.sprite = ToChange;
                break;
            case 2:
                Second.sprite = ToChange;
                break;
            case 3:
                Thret.sprite = ToChange;
                break;
            case 4:
                Fourth.sprite = ToChange;
                break;
        }
    }

    private void SaveTheChoise()
    {
        PlayerPrefs.SetInt("SaveMember"+ToSaveSlot, ToSaveMember);
    }

}
