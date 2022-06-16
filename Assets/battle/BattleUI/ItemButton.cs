using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    #region properties
    public Item item;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
    }


    #region methods
    public void UpdateButton(Item new_item)
    {
        this.item = new_item; // update item button matching data
       // GetComponentInParent<RawImage>().texture = item.texture;  // update item icon
    }

    // get raw data from caster and recalc the effect num and apply on the target

    public void onclick(GameObject target, GameObject caster)
    {
        //TODO target and caster support
        //item.CastEffect();
    }


    #endregion
}
