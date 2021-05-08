using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;
    private bool pause = false;

    private void OnEnable()
    {
        GameObject.FindObjectOfType<SphereState>().OnGameOver += GameOver;
        GameObject.FindObjectOfType<UI>().OnClickRestart += Restart;
    }

    private void OnMouseDrag()
    {
        if (!pause)
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;
            transform.Rotate((rotY), 0, (-rotX), Space.World);
        }

    }
    private void GameOver()
    {
        pause = true;
    }
    private void Restart()
    {
        transform.rotation = Quaternion.identity;
        pause = false;
    }

}
