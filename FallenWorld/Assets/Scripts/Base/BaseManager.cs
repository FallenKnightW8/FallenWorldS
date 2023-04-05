using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    [SerializeField] private GameObject Arsenal;
    private void Update()
    {
        if(PlayerPrefs.GetInt("ListHasBuyed_4") == 4)
        {
            Arsenal.SetActive(true);
        }
    }
}
