using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialog_manager : MonoBehaviour
{
    public GameObject chat_panel;
    public GameObject talkerName_space;
    public GameObject talkerbody_space;
    private GameObject target_char;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void npc_enter(GameObject target_char_enter)
    {
        this.target_char = target_char_enter;
        this.prepareUI();
    }

    void prepareUI()
    {
        chat_panel.SetActive(true);
        talkerName_space.GetComponent<Text>().text = target_char.GetComponent<npc_stats>().NPC_name;
        talkerbody_space.GetComponent<Text>().text = "12312323123";
        //TODO go db to find matching msg and keep talking
    }

    public void exitUI()
    {
        chat_panel.SetActive(false);
    }
}
