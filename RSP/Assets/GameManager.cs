using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameovertext;
    public Text scoreText;
    public Text recordText;

    public static int score;
    private bool isGameover;

    void Start()
    {
        isGameover = false;
    }
    void Update()
    {
        if (isGameover)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameovertext.SetActive(true);

        int bestScore = PlayerPrefs.GetInt("bestScore");

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("bestScore", bestScore);
        }

        recordText.text = "최고점수: " + (int)bestScore;
    }
}

