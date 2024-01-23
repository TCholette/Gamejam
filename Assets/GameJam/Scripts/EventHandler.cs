using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventHandler : MonoBehaviour {

    public float acc;

    public GameObject logs;

    public float distance;

    public GameObject placement;
    public GameObject scrapSpawn;

    public bool canBringCharacter = false;
    public bool canStartBarter = false;
    public bool aiAgrees = false;
    public bool canEndBarter = false;

    public string name2;

    public List<GameObject> characters;

    public GameObject desk;


    public string state2;


    public bool accept;
    public bool deny;


    public LogDisplay logs2;

    public string state = "tinker";

    public Animator characterAnim;

    public GameObject curtains;

    public bool tradeWorked = true;


    public AICharacter character;

    public List<string> names = new List<string> { "Alison", "Syd", "Theo", "Tristan" };
    public List<string> namesSave = new List<string> { "Alison", "Syd", "Theo", "Tristan" };

    public bool canContinue;

    public bool openDoor;



    // Start is called before the first frame update
    void Start() {
        state = "tinker";
        state2 = "aa";
        tradeWorked = true;
        canContinue = true;
        openDoor = false;
    }

    // Update is called once per frame
    void Update() {
        switch (state) {
            case "tinker":
                if (canContinue && openDoor) {
                    openDoor = false;
                    canContinue = false;

                    int a = Random.Range(0, names.Count);
                    GetComponent<CreateAICharacter>().DisplayCharacter(names[a]);
                    name2 = names[a];
                    names.Remove(names[a]);
                    if (names.Count <= 0) {
                         names =  new List<string> { "Alison", "Syd", "Theo", "Tristan" };
}
                    character = GetComponent<CreateAICharacter>().ai;
                    StartCoroutine(OpenSesame(distance));
                    StartCoroutine(StateTimer(1f, "walk in"));
                    
                }



                break;
            case "walk in":
                if (canContinue) {
                    canContinue = false;
                    tradeWorked = false;
                    //characterAnim.SetTrigger("speak");
                }
      
                    if (deny) {
                        deny = false;
                        tradeWorked = false;
                        StartCoroutine(StateTimer(0.5f, "barter"));
                        OpenAI.hasStarted = false;
                    } else if (accept) {
                        accept = false;
                        tradeWorked = true;
                        StartCoroutine(StateTimer(0.5f, "barter"));
                        OpenAI.hasStarted = false;
                    }
                


                break;
            case "barter":
                state2 = "";
                if (canContinue) {
                    canContinue = false;
                    if (tradeWorked) {
                        GetComponent<CreateScrap>().DisplayScrap(character.scrap);
                       
                        StartCoroutine(StateTimer(0.5f, "walk out"));

                    } else {
                        StartCoroutine(StateTimer(0.1f, "walk out"));
                    }


                }

                break;
            case "walk out":
               if (canContinue) {
                    canContinue = false;
                    if (tradeWorked) {
                        StartCoroutine(CloseGently(distance));
                        StartCoroutine(StateTimer(0.5f, "tinker"));
                    } else {
                        StartCoroutine(CloseHard(distance));
                        StartCoroutine(StateTimer(0.1f, "tinker"));
                    }


                }

                break;
            default:
                break;

        }



    }

    public void OpenDoor() {

        openDoor = true;


    }

    private IEnumerator StateTimer(float time, string nextState) {

        yield return new WaitForSeconds(time);
        state = nextState;
        canContinue = true;

    }


    private IEnumerator OpenSesame(float distance) {

        float times = 25;
        acc = 0.05f;
        for (int i = 0; i < times; i++) {
            acc -= 0.002f;
            yield return new WaitForSeconds(acc);
     
            curtains.transform.position += new Vector3(0, distance / times, 0);
        }


    }

    private IEnumerator CloseHard(float distance) {

        float times = 5;
        for (int i = 0; i < times; i++) {
            yield return new WaitForSeconds(0.01f);
            curtains.transform.position -= new Vector3(0, distance / times, 0);
        }


    }

    private IEnumerator CloseGently(float distance) {
        float times = 25;
        for (int i = 0; i < times; i++) {
            yield return new WaitForSeconds(0.02f);
            curtains.transform.position -= new Vector3(0, distance / times, 0);
        }


    }

    public void DenyOffer() {
        deny = true;
    }

    public void AcceptOffer() {
        accept = true;
    }
}
