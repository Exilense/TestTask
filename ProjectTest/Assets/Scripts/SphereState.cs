using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SphereState : MonoBehaviour
{
    private bool sphereOnPlatform = true;
    private UnityAction onGameOver;
    private Vector3 startPosition;
    public UnityAction OnGameOver { get => onGameOver; set => onGameOver = value; }

    private void OnEnable()
    {
        startPosition = transform.position;
        GameObject.FindObjectOfType<UI>().OnClickRestart += Restart;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        
        if (!Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity)&&sphereOnPlatform == true)
        {
            sphereOnPlatform = false;
            Invoke(nameof(GameOver), 1f);
           
        }
       
    }
 
    private void GameOver()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        OnGameOver();
    }

    private void Restart()
    {
        transform.position = startPosition;
        sphereOnPlatform = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
    
}
