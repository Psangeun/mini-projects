using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class MsgDisp : MonoBehaviour
{
    public static string msg;
    public static bool flagDisplay = false;

    public GameObject display;
    public static Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Text").GetComponent<Text>();
        display.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (flagDisplay)
        {
            StartCoroutine(Typing(msg));
        }
    }

    IEnumerator Typing(string msg)
    {
        flagDisplay = false;
        display.SetActive(true);
        text.text = null;

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < msg.Length; i++)
        {
            stringBuilder.Append(msg[i]);
            text.text = stringBuilder.ToString();
            yield return new WaitForSeconds(0.15f);
        }
        msg = null;
        display.SetActive(false);
        
    }
}
