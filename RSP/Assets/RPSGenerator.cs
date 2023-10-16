using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RPSGenerator : MonoBehaviour
{
    public GameObject otherR;
    public GameObject otherS;
    public GameObject otherP;

    public GameObject myR;
    public GameObject myS;
    public GameObject myP;

    public GameObject gameovertext;
    public Text recordText;
    public Text ScoreText;
    public Text MentText;
    public Text TimerText;

    private bool isGameover;
    private int score = 0;
    int otherCount = 0;
    int mentCount = 0;
    float limitTime = 4;

    void Start()
    {
        ScoreText.text = "점수 : " + score;
        isGameover = false;
        TimerText.text = limitTime.ToString();

        Hide();
        Invoke("Change", 0.5f);
        Invoke("ChangeMent", 1f);
    }

    void Update()
    {
        limitTime -= Time.deltaTime;
        ScoreText.text = "점수 : " + score;
        

        if (limitTime > 0)
        {
            TimerText.text = string.Format("{0:0}", limitTime);
        }
        else
        {
            EndGame();
        }
        if (isGameover)
        {
            TimerText.text = "";
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("RSP");
            }
        }
    }

    void Change()
    {
        otherCount = Random.Range(0, 3);

        if (otherCount == 0)
        {
            otherR.SetActive(true);
            otherP.SetActive(false);
            otherS.SetActive(false);
        }
        else if (otherCount == 1)
        {
            otherR.SetActive(false);
            otherP.SetActive(true);
            otherS.SetActive(false);
        }
        else if (otherCount == 2)
        {
            otherR.SetActive(false);
            otherP.SetActive(false);
            otherS.SetActive(true);
        }
    }

    void ChangeMent()
    {
        mentCount = Random.Range(0, 3);

        if (mentCount == 0)
        {
            MentText.text = "이겨라";
        }
        else if (mentCount == 1)
        {
            MentText.text = "비겨라";
        }
        else if (mentCount == 2)
        {
            MentText.text = "져라";
        }
    }

    void Hide()
    {
        otherR.SetActive(false);
        otherS.SetActive(false);
        otherP.SetActive(false);

        myR.SetActive(false);
        myS.SetActive(false);
        myP.SetActive(false);

        MentText.text = "";
    }
    public void RedButtonDown()
    {
        if (otherCount == 0) // 상대가 주먹
        {
            if (mentCount == 2)
            {
                limitTime = 4;
                score++;
                myS.SetActive(true);
                Invoke("Hide", 0.5f);
                Invoke("Change", 0.5f);
                Invoke("ChangeMent", 1f);
            }
            else
            {
                EndGame();
            }
        }
        else if (otherCount == 1) // 보
        {
            if (mentCount == 0)
            {
                limitTime = 4;
                score++;
                myS.SetActive(true);
                Invoke("Hide", 0.5f);
                Invoke("Change", 0.5f);
                Invoke("ChangeMent", 1f);
            }
            else
            {
                EndGame();
            }
        }
        else if (otherCount == 2) // 가위
        {
            if (mentCount == 1)
            {
                limitTime = 4;
                score++;
                myS.SetActive(true);
                Invoke("Hide", 0.5f);
                Invoke("Change", 0.5f);
                Invoke("ChangeMent", 1f);
            }
            else
            {
                EndGame();
            }
        }
    }
    public void GreenButtonDown()
    {
        if (otherCount == 0) // 상대가 주먹
        {
            if (mentCount == 1)
            {
                limitTime = 4;
                score++;
                myR.SetActive(true);
                Invoke("Hide", 0.5f);
                Invoke("Change", 0.5f);
                Invoke("ChangeMent", 1f);
            }
            else
            {
                limitTime = 4;
                EndGame();
            }
        }
        else if (otherCount == 1) // 보
        {
            if (mentCount == 2)
            {
                limitTime = 4;
                score++;
                myR.SetActive(true);
                Invoke("Hide", 0.5f);
                Invoke("Change", 0.5f);
                Invoke("ChangeMent", 1f);
            }
            else
            {
                EndGame();
            }
        }
        else if (otherCount == 2) // 가위
        {
            if (mentCount == 0)
            {
                limitTime = 4;
                score++;
                myR.SetActive(true);
                Invoke("Hide", 0.5f);
                Invoke("Change", 0.5f);
                Invoke("ChangeMent", 1f);
            }
            else
            {
                EndGame();
            }
        }
    }
    public void BlueButtonDown()
    {
        if (otherCount == 0) // 상대가 주먹
        {
            if (mentCount == 0)
            {
                limitTime = 4;
                score++;
                myP.SetActive(true);
                Invoke("Hide", 0.5f);
                Invoke("Change", 0.5f);
                Invoke("ChangeMent", 1f);
            }
            else
            {
                EndGame();
            }
        }
        else if (otherCount == 1) // 보
        {
            if (mentCount == 1)
            {
                limitTime = 4;
                score++;
                myP.SetActive(true);
                Invoke("Hide", 0.5f);
                Invoke("Change", 0.5f);
                Invoke("ChangeMent", 1f);
            }
            else
            {
                EndGame();
            }
        }
        else if (otherCount == 2) // 가위
        {
            if (mentCount == 2)
            {
                limitTime = 4;
                score++;
                myP.SetActive(true);
                Invoke("Hide", 0.5f);
                Invoke("Change", 0.5f);
                Invoke("ChangeMent", 1f);
            }
            else
            {
                EndGame();
            }
        }
    }

    public void EndGame()
    {
        Hide();

        isGameover = true;
        gameovertext.SetActive(true);

        int bestScore = PlayerPrefs.GetInt("bestScore");

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }

        recordText.text = "최고점수 : " + bestScore;
    }
}
