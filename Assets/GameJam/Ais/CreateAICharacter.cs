using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CreateAICharacter : MonoBehaviour
{

    int i = 0;

    public Handler handler;

    public List<AICharacter> aiList;

    public GameObject characterStyle;
    public GameObject aiCharacter;


    public AICharacter ai;

    public AICharacterInfo charInfoScript;

    // Start is called before the first frame update
    public void DisplayCharacter(string name) {

        Destroy(aiCharacter);


        foreach (AICharacter aii in aiList) {
            if (aii.aiName == name) {
                ai = aii;
                characterStyle = ai.characterStyle;
                aiCharacter = Instantiate(characterStyle);

                charInfoScript = aiCharacter.GetComponent<AICharacterInfo>();

                charInfoScript.aiCharacterInfo = ai;

                aiCharacter.transform.position = GetComponent<EventHandler>().placement.transform.position;

                GetComponent<OpenAi>().voice = ai.voice;
                GetComponent<OpenAi>().vendorName = ai.name;
            }
        }




        /*character.transform.SetParent(handler.allTiles[i][j].transform);
        character.transform.position = handler.allTiles[i][j].transform.position;
        character.transform.localScale = handler.allTiles[i][j].transform.localScale / 2;
        */

        //handler.allCharacters.Add(character);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
