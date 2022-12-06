using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgraeds : MonoBehaviour
{
  private bool HaveM;
  public  GameObject Rpanel;
  public Text NameofP;
  public Text DescriptionP;
  private string nameP = "one";
  private string desc = "two";


  public void test()
  {
    Debug.Log("1");
    nameP = "work";
    desc = "yea";
    OpenDes(false);
  }



  public void OpenDes(bool HaveM)
  {
    Rpanel.SetActive(true);
    NameofP.text = nameP;
    DescriptionP.text = desc;


  }
}
