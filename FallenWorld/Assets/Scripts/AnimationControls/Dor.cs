using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dor : MonoBehaviour
{
    public bool Opened = false;
    public Animator anim;
    // Update is called once per frame

    public void CHS()
    {
        anim.SetBool("Opened", true);
    }
}
