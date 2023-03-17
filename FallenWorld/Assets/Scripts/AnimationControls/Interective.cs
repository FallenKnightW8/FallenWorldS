using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interective : MonoBehaviour
{
    [SerializeField]private float Distance = 5f;
    public FirstPersonCharacter MousLoker;

    void Awake()
    {
        MousLoker = GameObject.Find("PlayerObj").GetComponent<FirstPersonCharacter>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Distance))
            {   
                Debug.DrawLine(transform.position,transform.forward);
                if (hit.collider.GetComponent<Dor>())
                {
                    hit.collider.gameObject.SendMessageUpwards("CHS", SendMessageOptions.DontRequireReceiver);
                }
                else if (hit.collider.GetComponent<Map>())
                {
                    hit.collider.gameObject.SendMessageUpwards("QuestM",SendMessageOptions.DontRequireReceiver);
                    MousLoker.lockCursor = false;
                }
            }
        }
    }
}
