using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_trade_option : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    private Text item_text;
    private Text price_text;
    private bool isSelect;

    private Color blackColor = new Color(0, 0, 0, 0.6f);
    private Color whiteColor = new Color(1, 1, 1, 0.6f);

    private ItemConf itemSelect;

    private bool isPlayer;
    public bool IsSelect
    {
        get => isSelect;
        set
        {
            isSelect = value;
            if (isSelect)
            {
                image.color = blackColor;
                item_text.color = Color.white;
                price_text.color = Color.white;
            }
            else
            {
                image.color = whiteColor;
                item_text.color = Color.black;
                price_text.color = Color.black;

            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsSelect = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsSelect = false;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // trade action
        if (isPlayer)
        {
            Debug.Log("sell");
            UI_trade.Instance.sellItem(itemSelect);
        }
        else
        {
            Debug.Log("buy");
            UI_trade.Instance.buyItem(itemSelect);

        }

    }


    public void Init(ItemConf model, bool isplayer)
    {
        image = GetComponent<Image>();
        item_text = transform.Find("item_text").GetComponent<Text>();
        price_text = transform.Find("price_text").GetComponent<Text>();
        itemSelect = model;

        isPlayer = isplayer;

        item_text.text = model.Name;
        price_text.text = model.worth.ToString();

        IsSelect = false;

    }


}
