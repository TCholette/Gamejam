using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ActivateUI : MonoBehaviour
{
    public EventHandler handler;
    public string state;

    [SerializeField] public GameObject[] canvases = new GameObject[9];

    public void GrabInput(string text){
        DisplayScreen();
    }

    public void ActivateUIOnClick()
    {

    }

    public void DeactivateUIOnClick()
    {
        for (int i = 0; i < 9; i++){
            canvases[i].SetActive(false);
        }
    }

    void DisplayScreen(){
        name.ToLower();
        switch (state){
            case "wendywrench":
                for (int i = 0; i < 8; i++){
                    if (i != 0)
                        canvases[i].SetActive(false);
                    else 
                        canvases[i].SetActive(true);
                }
                break;
            case "mrweird":
                for (int i = 0; i < 8; i++){
                    if (i != 1)
                        canvases[i].SetActive(false);
                    else 
                        canvases[i].SetActive(true);
                }
                break;
            case "rasmalian":
                for (int i = 0; i < 8; i++){
                    if (i != 2)
                        canvases[i].SetActive(false);
                    else 
                        canvases[i].SetActive(true);
                }
                break;
            case "timmy":
                for (int i = 0; i < 8; i++){
                    if (i != 3)
                        canvases[i].SetActive(false);
                    else 
                        canvases[i].SetActive(true);
                }
                break;
            case "cog":
                for (int i = 0; i < 8; i++){
                    if (i != 4)
                        canvases[i].SetActive(false);
                    else 
                        canvases[i].SetActive(true);
                }
                break;
            case "doohickey":
                for (int i = 0; i < 8; i++){
                    if (i != 5)
                        canvases[i].SetActive(false);
                    else 
                        canvases[i].SetActive(true);
                }
                break;
            case "powercore":
                for (int i = 0; i < 8; i++){
                    if (i != 6)
                        canvases[i].SetActive(false);
                    else 
                        canvases[i].SetActive(true);
                }
                break;
            case "orb":
                for (int i = 0; i < 8; i++){
                    if (i != 7)
                        canvases[i].SetActive(false);
                    else 
                        canvases[i].SetActive(true);
                }
                break;
            default: 
                for (int i = 0; i < 8; i++){
                    if (i != 8)
                        canvases[i].SetActive(false);
                    else 
                        canvases[i].SetActive(true);
                }
                break;

        }
    }
    void UpdatePrice(Canvas canvas, int price){
        Transform transText = canvas.transform.Find("Price");
        transText.GetComponent<TextMeshProUGUI>().text = price+"g";
    }

    void Update() {
        /*
        if (state == null) {
            Debug.Log("state");
        }
        else if (handler == null) {
            Debug.Log("handler");
        }
        else if (handler.state2 == null) {
            Debug.Log("state2");
        } else {
            state = handler.state2;
            DisplayScreen(handler.state2);
        }*/
        DisplayScreen();
    }

    void Start() {
        state = "";
    }
}
