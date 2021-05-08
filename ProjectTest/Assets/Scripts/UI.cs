using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;
    private UnityAction onClickRestart;
    public UnityAction OnClickRestart { get => onClickRestart; set => onClickRestart = value; }
    
    private void Awake()
    {
        Time.timeScale = 0;
       
    }

    private void Start()
    {
        startPanel.SetActive(true);
    }

    private void OnEnable()
    {
        GameObject.FindObjectOfType<SphereState>().OnGameOver += GameOver;
    }
   
    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void OnClickStartButton()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1;
      

    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

    public void OnClickRestartButton()
    {
        OnClickRestart();
        gameOverPanel.SetActive(false);
    }

}
