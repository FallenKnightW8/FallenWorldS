using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
  public bool isFullScreen = true;
  public bool counterFPS = false;
  Resolution[] rsl;
  List<string> resolutions;
  public Dropdown dropdown;
  public AudioMixer am;

   public void Awake()
       {
         countF();
           resolutions = new List<string>();
           rsl = Screen.resolutions;
           foreach (var i in rsl)
           {
               resolutions.Add(i.width +"x" + i.height);
           }
           dropdown.ClearOptions();
           dropdown.AddOptions(resolutions);
           if (PlayerPrefs.HasKey("VolumeMax"))
           {
             am.SetFloat("masterVolume",PlayerPrefs.GetFloat("VolumeMax"));
           }
           am.SetFloat("masterVolume",-20);
       }

       public void Resolution(int r)
           {
               Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
           }

      public void FullScreenToggle()
        {
          isFullScreen = !isFullScreen;
          Screen.fullScreen = isFullScreen;
//          PlayerPrefs.SetBool("FullScreenMax",isFullScreen);
        }
      public void Quality(int q)
        {
          QualitySettings.SetQualityLevel(q);
        }
      public void AudioVolume(float sliderValue)
        {
        am.SetFloat("masterVolume", sliderValue);
        PlayerPrefs.SetFloat("VolumeMax",sliderValue);
        }
        public void countF()
        {
          counterFPS = !counterFPS;
          if (counterFPS == true)Application.targetFrameRate = 30;
          else Application.targetFrameRate = 120;
        }



}
