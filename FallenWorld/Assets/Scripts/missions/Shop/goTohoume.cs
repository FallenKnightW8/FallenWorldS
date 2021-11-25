using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goTohoume : MonoBehaviour
{
  private void OnTriggerEnter(Collider Other)
  {
    SceneManager.LoadScene("PlayerBase");
  }

}
