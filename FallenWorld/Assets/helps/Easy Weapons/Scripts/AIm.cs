using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIm : MonoBehaviour
{
    public int zoom = 20;
    public int normal = 60;
    public float smooth = 5;
    private bool isZoomed = false;
    void Update()
    {
    if(Time.timeScale != 0)
        {
            if(Input.GetMouseButtonDown(1))
            {
                isZoomed = true;
            }
            else if(Input.GetMouseButtonUp(1))
            {
                isZoomed = false;
            }

            if(isZoomed)
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView,zoom,Time.deltaTime*smooth);;
            }
            else
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView,normal,Time.deltaTime*smooth);
            }
        }
    }
}
