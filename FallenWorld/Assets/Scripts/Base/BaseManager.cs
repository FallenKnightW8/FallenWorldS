using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    [SerializeField] private GameObject Arsenal;
    [SerializeField] private GameObject Crew;
    private void Update()
    {
        if(PlayerPrefs.GetInt("ListHasBuyed_4") == 4)
        {
            Arsenal.SetActive(true);
        }
        if(PlayerPrefs.GetInt("ListHasBuyed_6")==6)
        {
            Crew.SetActive(true);
        }
    }
}
