using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallHekp : MonoBehaviour
{
  public GameObject prefab;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.G)) {
        Instantiate(prefab, transform.position,transform.rotation);
      }
    }
}
