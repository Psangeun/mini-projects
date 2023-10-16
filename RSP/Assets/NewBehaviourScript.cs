using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    float span = 0.5f;
    float delta = 0;

    public Image img;
    public Sprite r;
    public Sprite s;
    public Sprite p;

    int count = 0;

    void Start()
    {
        Invoke("SceneChange", 3f);
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            ImageChange();
            this.delta = 0;
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene("RSP");
    }

    void ImageChange()
    {
        if(count == 0)
        {
            img.sprite = r;
            count++;
        }
        else if(count == 1)
        {
            img.sprite = s;
            count++;
        }
        else if (count == 2)
        {
            img.sprite = p;
            count = 0;
        }
    }
}
