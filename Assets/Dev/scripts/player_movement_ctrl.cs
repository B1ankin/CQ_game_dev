using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement_ctrl : MonoBehaviour
{
    public Camera cam;

    public GameObject dialogUI;

    playerMotor motor;

    public LayerMask movementMask;

    private bool inDialog;



    //variables
    bool isAction;
    // Start is called before the first frame update
    void Start()
    {
        //cam = Camera.main;
        motor = GetComponent<playerMotor>();
        isAction = false;
        inDialog = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAction)
        {
            keyDetect();
        }
        

    }

    public void exDialog()
    {
        inDialog = false;
    }
    void keyDetect()
    {
        if (!inDialog)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, movementMask))
                {
                    //Debug.Log("we hit" + hit.collider.name+ " "+ hit.point);
                    // Move player
                    motor.MoveToPoint(hit.point);

                    // stop focusing on object
                }

            }
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    //check if we hit an interactable object
                    GameObject hitObj = hit.collider.gameObject;

                    Debug.Log("we hit" + hit.collider.name + " " + hit.point);
                    // if hit is an NPC, open d
                    if (hitObj.tag == "NPC")
                    {

                        int ind = hitObj.GetComponent<NPC_data>().currentLog;
                        if (hitObj.GetComponent<NPC_data>().dialogConfs.Length > 0)
                        {
                            DialogConf dc = hitObj.GetComponent<NPC_data>().dialogConfs[ind];
                            int enterPos = hitObj.GetComponent<NPC_data>().enterPos;
                            dialogUI.SetActive(true);
                            dialogUI.GetComponent<UI_Dialog>().dialogEnter(dc, enterPos, hitObj);
                            //dialogUI.GetComponent<>
                            inDialog = true;
                        }
                        
                    }
                    // Move player
                    //motor.MoveToPoint(hit.point);

                    // stop focusing on object
                }

            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    Debug.Log("001");
                }
                else if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    Debug.Log("002");
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (cam.fieldOfView <= 100)
                    cam.fieldOfView += 2;
                if (cam.orthographicSize <= 20)
                    cam.orthographicSize += 0.5F;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (cam.fieldOfView > 2)
                    cam.fieldOfView -= 2;
                if (cam.orthographicSize >= 1)
                    cam.orthographicSize -= 0.5F;
            }
        }
          
    }
}
