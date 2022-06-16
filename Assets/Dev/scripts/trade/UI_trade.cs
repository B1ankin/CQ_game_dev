using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_trade : MonoBehaviour
{
    public static UI_trade Instance;
    public GameObject player;
    private GameObject npc;
    private Text player_name_text;
    private Text trader_name_text;
    private Text trader_money_text;
    private Text player_money_text;
    private Transform player_item_option;
    private Transform trader_item_option;
    private GameObject prefab_OptionItem;
    private DialogConf currConf;
    private int currIndex;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        //set 
        player_name_text = transform.Find("playerName").GetComponent<Text>();
        trader_name_text = transform.Find("traderName").GetComponent<Text>();
        trader_item_option = transform.Find("traderTable");
        player_item_option = transform.Find("playerTable");
        prefab_OptionItem = Resources.Load<GameObject>("item_option");
    }

    // load both player and trader's items
    public void loadItems( GameObject trader)
    {
        npc = trader;
        player_name_text = transform.Find("playerName").GetComponent<Text>();
        trader_name_text = transform.Find("traderName").GetComponent<Text>();
        trader_item_option = transform.Find("traderTable");
        player_item_option = transform.Find("playerTable");
        trader_money_text = transform.Find("traderMoney/moneyText").GetComponent<Text>(); ;
        player_money_text = transform.Find("playerMoney/moneyText").GetComponent<Text>(); ;
        prefab_OptionItem = Resources.Load<GameObject>("item_option");
        Debug.Log(prefab_OptionItem);
        //player
        player_datas pld = player.GetComponent<player_datas>();
        int player_money = pld.money;
        player_money_text.text = pld.money.ToString();
        List<ItemConf> player_items = pld.itemConfs;
        // 玩家选项
        // 1.删除已有选项
        Transform[] items = player_item_option.GetComponentsInChildren<Transform>();
        for (int i = 1; i < items.Length; i++)
        {
            Destroy(items[i].gameObject);
        }
        // 2.生成玩家的选项
        for (int i = 0; i < player_items.Count; i++)
        {
            Debug.Log(player_items[i]);

            UI_trade_option item = GameObject.Instantiate<GameObject>(prefab_OptionItem, player_item_option).GetComponent<UI_trade_option>();
            item.Init(player_items[i],true);
        }


        //trader
        NPC_data npcd = trader.GetComponent<NPC_data>();
        int npc_money = npcd.money;
        trader_money_text.text = npc_money.ToString();
        List<ItemConf> npc_items = npcd.itemConfs;
        // 1.删除已有选项
        items = trader_item_option.GetComponentsInChildren<Transform>();
        for (int i = 1; i < items.Length; i++)
        {
            Destroy(items[i].gameObject);
        }
        // 2.生成NPC的选项
        for (int i = 0; i < npc_items.Count; i++)
        {
            UI_trade_option item = GameObject.Instantiate<GameObject>(prefab_OptionItem, trader_item_option).GetComponent<UI_trade_option>();
            item.Init(npc_items[i], false);
        }


        //active the UI
        this.gameObject.SetActive(true);
    }

    //trade option
    public void buyItem(ItemConf item)
    {
        //if money
        if (player.GetComponent<player_datas>().money >= item.worth)
        {
            player.GetComponent<player_datas>().money -= item.worth;
            npc.GetComponent<NPC_data>().money += item.worth;
            //remove
            List<ItemConf> a = npc.GetComponent<NPC_data>().itemConfs;
            a.Remove(item);
            //add
            List<ItemConf> b = player.GetComponent<player_datas>().itemConfs;
            b.Add(item);

            //reload
            loadItems(npc);
        }
        
    }

    public void sellItem(ItemConf item)
    {
        //if money
        if (npc.GetComponent<NPC_data>().money >= item.worth)
        {
            npc.GetComponent<NPC_data>().money -= item.worth;
            player.GetComponent<player_datas>().money += item.worth;
            //destroy
            List<ItemConf> a = npc.GetComponent<NPC_data>().itemConfs;
            List<ItemConf> b = player.GetComponent<player_datas>().itemConfs;

            b.Remove(item);
            //add
            a.Add(item);

            //reload
            loadItems(npc);
        }
            

    }
}
