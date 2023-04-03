using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMission : MonoBehaviour
{
    public float TimeToStart = 3f;
    private float time;
    private float timeRound;
    [SerializeField] private GameObject textGO;
    [SerializeField] private TMP_Text TextTime;
    private bool started = false;


    private IEnumerator StartingM()
    {
        started = true;
        yield return new WaitForSeconds(TimeToStart);
        SceneManager.LoadScene("Mission");
    }
    private void OnTriggerEnter(Collider other)
    {
        started = true;
        time = 3;
        textGO.SetActive(true);
        StartCoroutine(StartingM());
    }
    private void Update()
    {
        if(started == true)
        {
            time -= Time.deltaTime;
            timeRound = time;
            TextTime.text ="Time to start = " + timeRound.ToString();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        started = false;
        textGO.SetActive(false);
        StopAllCoroutines();
    }
}
