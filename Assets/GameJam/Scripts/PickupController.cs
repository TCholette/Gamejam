using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{

    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    public GameObject heldObj;
    private Rigidbody heldObjRB;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 1000f;
    [SerializeField] private float pickupForce = 150.0f;


    public ContraptionHandler contraptHandler;

    public GameObject environment;


    public GameObject pickupZone;

    public GameObject contraption;


    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        pickupZone.transform.position = cam.transform.position + cam.transform.forward * 1.5f;

        if (Input.GetMouseButtonDown(0)) {
            if (heldObj == null) {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange)) {
                    if (hit.transform.position != environment.transform.position    ) {
                        if (hit.transform.gameObject.GetComponent<ButtonOrPickable>().type == "pickable") {
                            PickupObject(hit.transform.gameObject);
                        } else if (hit.transform.gameObject.GetComponent<ButtonOrPickable>().type == "button") {
                            hit.transform.gameObject.GetComponent<ButtonCode>().DoButtonTask();
                        }
                    }
      


                }
            } else {

                DropObject();
                if (heldObj.transform.position.x <= contraption.transform.position.x + 2 && heldObj.transform.position.x >= contraption.transform.position.x - 2) {
                    contraptHandler.AddTime(heldObj.GetComponent<ScrapInfo>().scrapInfo.value);


                    Destroy(heldObj);
                    heldObj = null;
                } else {
                    heldObj = null;
                }

            }
        }
        if (heldObj != null) {
            MoveObject();
        }
    }


    void PickupObject(GameObject pickObj) {
        if (pickObj.GetComponent<Rigidbody>()) {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void MoveObject() {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f) {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }


    void DropObject() {

        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;

        
    }

}
