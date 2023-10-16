using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    System.DateTime now;
    int nowYear;
    int nowMonth;
    int nowDay;
    int nowHour;
    int nowMinute;

    public AudioClip voice1;
    public AudioClip voice2;
    private Animator animator;
    private AudioSource univoice;

    private int motionIdol = Animator.StringToHash("Base Layer.Idol");

    // Start is called before the first frame update
    void Start()
    {
        now = System.DateTime.Now;
        nowYear = now.Year;
        nowMonth = now.Month;
        nowDay = now.Day;
        nowHour = now.Hour;
        nowMinute = now.Minute;

        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Touch", false);
        animator.SetBool("TouchHead", false);

        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == motionIdol)
        {
            animator.SetBool("Motion_Idle", true);
        }    
        else
        {
            animator.SetBool("Motion_Idle", false);
        }
            
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject hitObj = hit.collider.gameObject;

                if(hitObj.tag == "Head")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice1;
                    univoice.Play();
                    MsgDisp.msg = "안녕!\n오늘도 힘차게 시작해보자!";
                    MsgDisp.flagDisplay = true;

                }
                else if (hitObj.tag == "Body")
                {
                    animator.SetBool("Touch", true);
                    animator.SetBool("Face_Happy", false);
                    animator.SetBool("Face_Angry", true);
                    univoice.clip = voice2;
                    univoice.Play();
                    MsgDisp.msg = "꺅!";
                    MsgDisp.flagDisplay = true;
                }
                else if (hitObj.tag == "Arm")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice1;
                    univoice.Play();
                    string s = "오전 ";
                    int hour = nowHour;
                    if(nowHour >= 12)
                    {
                        s = "오후 ";
                        hour = nowHour - 12;
                    }
                    MsgDisp.msg = "오늘은 " + nowYear + "년 " + nowMonth + "월 " + nowDay + "일이고\n지금 시간은 " + s + hour + "시 " + nowMinute + "분이야!";
                    MsgDisp.flagDisplay = true;
                }
            }
        }
    }
}
