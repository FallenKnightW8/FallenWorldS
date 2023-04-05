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
    [SerializeField] private Image[] ColectionOfMembers;
    [Header("Buton Part")]
    [SerializeField] private GameObject TheButtonsOfchoise;

    [Header("Logic")]
    private int ToSaveMember;
    private int ToSaveSlot;

    public void buttonOfChois(int Value)
    {
        TheButtonsOfchoise.SetActive(true);
        ToSaveMember = Value;
    }

    public void ButtonOfSlotMember(int Value)
    {
        ToSaveSlot = Value;
        SaveTheChoise();
        TheButtonsOfchoise.SetActive(false);
    }

    private void SaveTheChoise()
    {
        PlayerPrefs.SetInt("SaveMember"+ToSaveSlot, ToSaveMember);
    }

}
