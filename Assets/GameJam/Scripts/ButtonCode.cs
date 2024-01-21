using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCode : MonoBehaviour
{
    public EventHandler handler;
    public string task;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoButtonTask() {
        if (task == "accept") {
            handler.AcceptOffer();
        } else if (task == "deny") {
            handler.DenyOffer();
        } else if (task == "open") {
            handler.openDoor = true;
        }

    }
}
