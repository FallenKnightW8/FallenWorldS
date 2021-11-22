using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENBullets : MonoBehaviour
{

public float Dtime;
private float STime;
    void Start()
    {
      STime = Dtime;
    }
    void Update()
    {
      Dtime -= Time.deltaTime;
      if(Dtime == 0)
      {
        Dtime = STime;
        Destroy(gameObject);

    }
    }
}
