using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash_FlipandAdv : MonoBehaviour
{
    public class Question
    {
        public string question;
        public string correctanswer;
        public Question( string q, string c )
        {
           question = q;
           correctanswer = c;         
        }
    }
    public Transform rect_transform; //hold flashcard object scale
    public Text card_text;

    public Question[] ques = new Question[3];
    
    public float flipTime = 0.5f;
    private int faceside = 0; //0=front, 1=back
    private int isShrinking = -1; //-1 means getting smaller, 1 means getting bigger
    private bool isFlipping = false;
    private int cardNum = 0;
    private float distancePerTime;
    private float timeCount = 0;

    void Start()
    {
        ques[0] = new Question("one","1");
        ques[1] = new Question("two","2");
        ques[2] = new Question("three","3");

        distancePerTime = rect_transform.localScale.x / flipTime;
        cardNum = 0;
        card_text.text = ques[cardNum].question;
    }   
void Update()
{
    if (isFlipping)
    {
        Vector3 v = rect_transform.localScale;
        v.x += isShrinking * distancePerTime * Time.deltaTime;
        rect_transform.localScale = v;

        timeCount += Time.deltaTime;
        if ((timeCount >= flipTime) && (isShrinking < 0))
        {
            isShrinking = 1; // make it grow back to the original size of flashcard
            timeCount = 0;
            if (faceside == 0)
            {
                faceside = 1;
                card_text.text = ques[cardNum].correctanswer;
            }
            else
            {
                faceside = 0;
                card_text.text = ques[cardNum].question;
            }
        }
        else if ((timeCount >= flipTime) && (isShrinking == 1))
        {
            isFlipping = false;
        }
        else
        {
            // Rotate the card
            float angle = Mathf.Lerp(0, 180, timeCount / flipTime);
            rect_transform.rotation = Quaternion.Lerp(
                Quaternion.Euler(0, 0, 0),
                Quaternion.Euler(0, 180, 0),
                angle / 180
            );
        }
    }
}

    // Update is called once per frame
    // void Update()
    // {
    //     if (isFlipping)
    //     {
    //         Vector3 v = rect_transform.localScale;
    //         v.x += isShrinking * distancePerTime * Time.deltaTime;
    //         rect_transform.localScale = v;

    //         timeCount += Time.deltaTime;
    //         if ((timeCount >= flipTime) && (isShrinking < 0))
    //         {
    //             isShrinking = 1; // make it grow back to the original size of flashcard
    //             timeCount = 0;
    //             if (faceside == 0)
    //             {
    //                 faceside = 1;
    //                 card_text.text = ques[cardNum].correctanswer;
    //             }
    //             else
    //             {
    //                 faceside = 0;
    //                 card_text.text = ques[cardNum].question;
    //             }
    //         }
    //         else if ( (timeCount >= flipTime) && (isShrinking == 1))
    //         {
    //             isFlipping = false;
    //         }
    //     }
    // }

    public void NextCard()
    {
        faceside = 0;
        cardNum++;
        if (cardNum >= ques.Length)
        {
            cardNum = 0;
        }
        card_text.text = ques[cardNum].question;
    }

    public void FlipCard()
    {
        timeCount = 0;
        isFlipping = true;
        isShrinking = -1;
    }
}
