using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;

public class WireConnect : MonoBehaviour
{
    [SerializeField] Button[] Sources = new Button[4];
    [SerializeField] Button[] Dests = new Button[4];
    [SerializeField] GameObject[] wires = new GameObject[4]; 
    private Button s;
    bool matched = false;
    bool[] matches;

    void Start()
    {
        Sources[0].onClick.AddListener(delegate {SourceClicked(Sources[0]);});
        Sources[1].onClick.AddListener(delegate {SourceClicked(Sources[1]);});
        Sources[2].onClick.AddListener(delegate {SourceClicked(Sources[2]);});
        Sources[3].onClick.AddListener(delegate {SourceClicked(Sources[3]);});

        Dests[0].onClick.AddListener(delegate {DestClicked(Dests[0], 0);});
        Dests[1].onClick.AddListener(delegate {DestClicked(Dests[1], 1);});
        Dests[2].onClick.AddListener(delegate {DestClicked(Dests[2], 2);});
        Dests[3].onClick.AddListener(delegate {DestClicked(Dests[3], 3);});

        wires[0] = Dests[0].transform.GetChild(1).gameObject;
        wires[1] = Dests[1].transform.GetChild(1).gameObject;
        wires[2] = Dests[2].transform.GetChild(1).gameObject;
        wires[3] = Dests[3].transform.GetChild(1).gameObject;

        matches = new bool[4] {false, false, false, false};

        for (int i = 0; i < 4; i++){
            wires[i].SetActive(false);
        }
    }

    void Update(){
        if (matches[1]) Dests[1].colors = Sources[1].colors;
        if (matches[2]) Dests[2].colors = Sources[2].colors;
        if (matches[3]) Dests[3].colors = Sources[3].colors;
    }
    
    void SourceClicked(Button b){
        matched = true;
        s = b;
    }

    void DestClicked(Button b, int i){
        if (!matched) return;
        if (b.CompareTag(s.tag)){
            Debug.Log("Match");            
            s.enabled = false;
            b.enabled = false;
            wires[i].SetActive(true);
            matches[i] = true;
            
            CheckIfGameOver();
        } else {
            Debug.Log("No match");
        }
        matched = false;
    }

    void CheckIfGameOver(){
        for (int i = 0; i < 4; i++){
            if (!matches[i]) return;
        }
        Debug.Log("UR DONE");   
    }
}
