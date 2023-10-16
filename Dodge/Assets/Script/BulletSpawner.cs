using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    GameManager gameManager;

    void Start()
    {
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        target = FindObjectOfType<PlayerController>().transform;

        gameManager = FindObjectOfType<GameManager>();

    }

    void Update()
    {
        if (!gameManager.GetBool())
        {
            timeAfterSpawn += Time.deltaTime;

            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;

                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

                bullet.transform.LookAt(target);

                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
        }
    }
}
