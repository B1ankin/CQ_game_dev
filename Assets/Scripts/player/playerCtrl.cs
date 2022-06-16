using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour
{
    public Camera cam;

    public GameObject dialogUI;

    public LayerMask movementMask;

    public GameObject interactionPanel;

    //private bool inDialog;

    public float m_speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        baseMove();
    }

    private void baseMove()
    {
        if (Input.GetKey(KeyCode.W)){//up
            transform.Translate(Vector2.up * Time.deltaTime * m_speed);
        } else if (Input.GetKey(KeyCode.S)){//down
            transform.Translate(Vector2.down * Time.deltaTime * m_speed);
        }

        if (Input.GetKey(KeyCode.A))//left
        {
            transform.Translate(Vector2.left * Time.deltaTime * m_speed);
        }
        else if (Input.GetKey(KeyCode.D))//right
        {
            transform.Translate(Vector2.right * Time.deltaTime * m_speed);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("we hit");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero, Mathf.Infinity);
            if (hit.collider != null)
            {
                //check if we hit an interactable object
                GameObject hitObj = hit.collider.gameObject;

                Debug.Log("we hit" + hit.collider.name + " " + hit.point);/**/
                // if hit is an NPC, open d
                if (hitObj.tag == "NPC") // TODO:  附加范围条件
                {
                    interactionPanel.SetActive(true);
                    interactionPanel.transform.position = hit.point;


                    int ind = hitObj.GetComponent<NPC_data>().currentLog;

                    /*                    if (hitObj.GetComponent<NPC_data>().dialogConfs.Length > 0)
                                        {
                                            DialogConf dc = hitObj.GetComponent<NPC_data>().dialogConfs[ind];
                                            int enterPos = hitObj.GetComponent<NPC_data>().enterPos;
                                            dialogUI.SetActive(true);
                                            dialogUI.GetComponent<UI_Dialog>().dialogEnter(dc, enterPos, hitObj);
                                            //dialogUI.GetComponent<>
                                            inDialog = true;
                                        }*/

                }
            }



        }
        else if (Input.GetMouseButtonDown(0))
        {
            interactionPanel.SetActive(false);
            Debug.Log("we hit");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero, Mathf.Infinity);
            if (hit.collider != null)
            {
                //check if we hit an interactable object
                GameObject hitObj = hit.collider.gameObject;

                Debug.Log("we hit" + hit.collider.name + " " + hit.point);/**/
                // if hit is an NPC, open d
                if (hitObj.tag == "NPC") // TODO:  附加范围条件
                {

                    int ind = hitObj.GetComponent<NPC_data>().currentLog;

                    if (hitObj.GetComponent<NPC_data>().dialogConfs.Length > 0)
                    {
                        DialogConf dc = hitObj.GetComponent<NPC_data>().dialogConfs[ind];
                        int enterPos = hitObj.GetComponent<NPC_data>().enterPos;
                        dialogUI.SetActive(true);
                        dialogUI.GetComponent<UI_Dialog>().dialogEnter(dc, enterPos, hitObj);
                        //dialogUI.GetComponent<>
                        //inDialog = true;
                    }
                }
            }
        }
    }
}