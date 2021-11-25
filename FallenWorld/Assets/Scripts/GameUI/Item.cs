using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  public int Point;
  public Take Tk;
  public void point()
  {
    Tk.Points += Point;
  }
}
