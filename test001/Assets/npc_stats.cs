using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc_stats : MonoBehaviour
{
    public GameObject Text;

    public string NPC_name;
    public bool talkable = false;
    public bool tradeable =false;
    public bool hasEvent = false;

    /*public List<playerEvent> e_list;*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startTalk()
    {
        if (talkable)
        {
            Text.GetComponent<Text>().text = "和" + NPC_name + "开始对话";
        } else
        {
            Text.GetComponent<Text>().text = NPC_name + "不想和你说话";

        }
    }
}

