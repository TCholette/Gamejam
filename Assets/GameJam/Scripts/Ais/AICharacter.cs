using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

[CreateAssetMenu(fileName = "New AI Character", menuName = "AI Character")]

public class AICharacter : ScriptableObject {
    public string aiName;
    public string profession;

    public string personality;

    public string voice;

    public string tag;
    public string itemtag;

    public GameObject characterStyle;

    public Scrap scrap;



}

