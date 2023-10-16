using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameovertext;

    public static bool isGameover;

    void Start()
    {
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameover)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameovertext.SetActive(true);
    }
}
