/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill_button : MonoBehaviour
{
    private Skill cur_skill;

    private bool ondisplay = false;

    private int skillId;

    public GameObject target1;

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseOver() // �������ʱ����ʾ��������
    {
        if (ondisplay)
        {
            Debug.Log(cur_skill.ToString());
            ondisplay = true;
        }

    }

    private void OnMouseExit() // ����뿪ʱ�򣬹رռ���������ʾ
    {
        if (!ondisplay)
        {
            ondisplay = false;
        }
    }


    public void Click()
    {
        // start cast skill process
        Debug.Log("-- start castSkill" + skillId);


        //select target
        target1.SetActive(true);
        Debug.Log("Waiting for target" + skillId); 

    }


    public void setCurSkill(Skill cur)
    {
        cur_skill = cur;
        gameObject.GetComponent<RawImage>().texture = cur.skillIcon;
    }

}
*/