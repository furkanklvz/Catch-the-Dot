using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ball : MonoBehaviour
{
    int rotateY, rotateX;
    int leftScore = 0;
    int rightScore = 0;
    public TextMeshProUGUI score, time;
    bool freeze = true;
    bool firstStart = false;

    void Start()
    {
        time.text= "Press any key to start..";
    }
    void Update()
    {
        if(firstStart == false){
            
            if(Input.anyKeyDown){
                firstStart = true;
                time.text = "";
                StartCoroutine(gamestart());
            }
        }
        if(freeze == false){
            transform.Translate(rotateX * Time.deltaTime, rotateY * Time.deltaTime, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "lineUp")
        {
            rotateY *= -1;
        }
        else if (collision.gameObject.tag == "lineDown")
        {
            rotateY *= -1;
        }
        else if (collision.gameObject.tag == "LeftBar")
        {
            rotateX *= -1;
        }
        else if (collision.gameObject.tag == "RightBar")
        {
            rotateX *= -1;
        }
        else if (collision.gameObject.tag == "lineRight")
        {
            freeze = true;
            leftScore++;
            transform.position = new Vector2(0f, 0f);
            StartCoroutine(gamestart());
        }
        else if (collision.gameObject.tag == "lineLeft")
        {
            freeze = true;
            rightScore++;
            transform.position = new Vector2(0f, 0f);
            StartCoroutine(gamestart());
        }
    }

    IEnumerator gamestart()
    {
        
        score.text = leftScore + " - " + rightScore;
        Debug.Log(score.text);
        transform.position = new Vector2(0f, 0f);
        for(int t = 3;t > 0;t--){
            time.text = t.ToString();
            yield return new WaitForSeconds(1);
        }
        time.text ="";

        int i = Random.Range(1, 5);
        switch (i)
        {
            case 1:
                rotateX = 11;
                rotateY = 11;
                break;
            case 2:
                rotateX = -11;
                rotateY = 11;
                break;
            case 3:
                rotateX = 11;
                rotateY = -11;
                break;
            case 4:
                rotateX = -11;
                rotateY = -11;
                break;
        }
        freeze = false;
    }
}
