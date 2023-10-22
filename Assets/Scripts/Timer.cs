using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float startTime;
    [SerializeField] private PlayerHealth playerHealth;

    

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if(playerHealth.GetHealth() != 0){
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("00");
            timerText.text = minutes + ":" + seconds;
        }
    }
}