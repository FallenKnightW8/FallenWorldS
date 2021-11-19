using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Settings : MonoBehaviour
{
  public bool isFullScreen = true;
  Resolution[] rsl;
  List<string> resolutions;
   public Dropdown dropdown;

   public void Awake()
       {
           resolutions = new List<string>();
           rsl = Screen.resolutions;
           foreach (var i in rsl)
           {
               resolutions.Add(i.width +"x" + i.height);
           }
           dropdown.ClearOptions();
           dropdown.AddOptions(resolutions);
       }

       public void Resolution(int r)
           {
               Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
           }



  public void FullScreenToggle()
      {
          isFullScreen = !isFullScreen;
          Screen.fullScreen = isFullScreen;
      }
      public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }



}
