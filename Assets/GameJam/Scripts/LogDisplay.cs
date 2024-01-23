using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogDisplay : MonoBehaviour
{
    float time;
    private bool canContinue = true;
    public float timer;
    private float multiplier;
    public TextMeshProUGUI space;

    public EventHandler handler;


    public string state;

    public bool gotObject;

    public string text;

    void Start(){
       // parsed = text.Split(' ', ',', '.');
       multiplier = 10.5f;
       timer = 1;
    }
/*
    void newText(string t){
        if (text == " "){
            text = t;
        } else {
            text2 = t;
        }
    }
    */

    public IEnumerator timer1(){
        yield return new WaitForSeconds(timer);
        canContinue = true;
    }


    public void PlayLog(){
        space.text = OpenAI.text;
        if (canContinue) {
            canContinue = false;
            StartCoroutine(timer1());
            time += 0.8f;

            space.transform.position = new Vector3(119f, time * multiplier - 55.5f, 0);
        }
        

        if (handler.state != "walk in") {
            space.transform.position = new Vector3(119f, 0, 0);
            time = 0;
        }

    }
}
