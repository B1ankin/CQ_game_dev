using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_cam : MonoBehaviour
{
    public dialog_manager dm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public LayerMask _layerMask;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 4, _layerMask))
        {
            Debug.Log(hit.collider.gameObject.name);
           // hit.collider.gameObject.GetComponent<>
           if (Input.GetKey(KeyCode.E))
            {
                hit.collider.gameObject.GetComponent<npc_stats>().startTalk();
                dm.GetComponent<dialog_manager>().npc_enter(hit.collider.gameObject);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.E))
            {
                dm.exitUI();
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 4);
    }
}
