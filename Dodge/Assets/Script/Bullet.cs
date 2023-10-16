using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f;
    private Rigidbody bulletRigidbody;
    GameManager gameManager;
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();

        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
        gameManager = FindObjectOfType<GameManager>();

    }

    private void Update()
    {
        speed = 4 + gameManager.GetTime()%10;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
