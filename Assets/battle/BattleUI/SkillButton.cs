using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour
{
    #region properties
    public Skill skill;
    private List<int> target_position;

    public List<GameObject> target_UI;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnMouseEnter()
    {
        Debug.Log("skill info ");
    }

    private void OnMouseExit()
    {
        Debug.Log("skill info out");
    }

    #region methods
    public void UpdateButton(Skill new_skill)
    {
        this.skill = new_skill; // update item button matching data
        target_position = new_skill.targetPos;

        // update target UI
                                // GetComponentInParent<RawImage>().texture = item.texture;  // update item icon
    }

    // get raw data from caster and recalc the effect num and apply on the target

    public void onclick()
    {
        // shoing target(s)
        Debug.Log(1);
        //Debug.Log(target_position.ToString());
        
        foreach ( GameObject i in target_UI)
        {
            i.SetActive(true);
        }

        // skill.castEffect(target);
    }


    #endregion
}
