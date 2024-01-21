using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CreateScrap : MonoBehaviour
{


    public GameObject scrapStyle;
    public GameObject scrap;

    public ScrapInfo scrapInfoScript;

    // Start is called before the first frame update
    public void DisplayScrap(Scrap scrapInfo) {


        //Destroy(scrap);

        scrapStyle = scrapInfo.scrapStyle;
        scrap = Instantiate(scrapStyle);
        scrapInfoScript = scrap.GetComponent<ScrapInfo>();

        scrapInfoScript.scrapInfo = scrapInfo;

        scrap.transform.position = GetComponent<EventHandler>().scrapSpawn.transform.position;
       

        //GetComponent<OpenAi>().vendorName = scrapInfo.name;

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
