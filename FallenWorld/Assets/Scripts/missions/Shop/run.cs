using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
public int point;
public int need;
public GameObject RunSCR;


    void Update()
    {
    cheker();
    }

public void cheker()
{
 if(point>=need)
 {
   RunSCR.SetActive(true);
 }

}

}
