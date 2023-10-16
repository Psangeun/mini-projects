using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 30f;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(!gameManager.GetBool())
        {
            rotationSpeed = 30 + gameManager.GetTime();
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
        
    }
}
