using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Score.score+=1;
    }
}