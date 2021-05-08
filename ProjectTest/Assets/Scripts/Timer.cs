using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    private float currentTime = 0f;
    private bool pause = true;
    private TimeSpan time;

    private void OnEnable()
    {
        GameObject.FindObjectOfType<SphereState>().OnGameOver += GameOver;
        GameObject.FindObjectOfType<UI>().OnClickRestart += Restart;
    }
    
    private void Update()
    {
        if (!pause)
        {
            currentTime += Time.deltaTime;
            time = TimeSpan.FromSeconds(currentTime);
            timerText.text = time.ToString("mm':'ss':'ff");
        }
    }
   
    private void GameOver()
    {
        pause = true;
    }

    private void Restart()
    {
        currentTime = 0f;
        pause = false;
    }

    public void StartTimer()
    {
        pause = false;
    }
}
