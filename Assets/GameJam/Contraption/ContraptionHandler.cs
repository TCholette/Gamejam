using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContraptionHandler : MonoBehaviour
{


    public int timeLimit;
    public int numberAttempts;

    public int seconds;

    public bool canAdd;

    public TextMeshProUGUI timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        seconds = timeLimit;
        canAdd = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining.text = seconds / 60 + "," + seconds % 60;
        if (canAdd) {
            canAdd = false;
            StartCoroutine(Timer1());
        }


        if (timeLimit <= 0) {

        }
    }



    private IEnumerator Timer1() {

        yield return new WaitForSeconds(1);
        seconds -= 1;
        canAdd = true;
    }

    public void AddTime( int valueToAdd) {
        seconds += valueToAdd;

    }
}
