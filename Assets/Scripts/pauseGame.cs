using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pauseGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = Time.timeScale == 0.0f ? 1.0f : 0.0f; 
            timerText.enabled = (Time.timeScale == 0.0f);
        } 
    }
}
