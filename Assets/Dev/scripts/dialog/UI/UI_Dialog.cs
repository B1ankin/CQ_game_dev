using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class UI_Dialog : MonoBehaviour
{
    public static UI_Dialog Instance;
    public GameObject player;
    public GameObject UI_trade1;
    public GameObject logs;
    private Image head;
    private Text nameText;
    private Text mainText;
    private RectTransform content;
    private Transform Options;
    private GameObject prefab_OptionItem;
    private DialogConf currConf;
    private int currIndex;

    private GameObject npc;

    public GameObject[] activeList;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        head = transform.Find("Main/Head").GetComponent<Image>();
        nameText = transform.Find("Main/Name").GetComponent<Text>();
        //mainText = transform.Find("Main/MainText").GetComponent<Text>();
        mainText = transform.Find("Main/Scroll View/Viewport/Content/MainText").GetComponent<Text>();
        content = transform.Find("Main/Scroll View/Viewport/Content").GetComponent<RectTransform>();
        Options = transform.Find("Options");
        prefab_OptionItem = Resources.Load<GameObject>("Options_Item");
        //TestDialog();
    }

    public void dialogEnter(DialogConf conf, int index, GameObject hitnpc)
    {
        head = transform.Find("Main/Head").GetComponent<Image>();
        nameText = transform.Find("Main/Name").GetComponent<Text>();
        //mainText = transform.Find("Main/MainText").GetComponent<Text>();
        mainText = transform.Find("Main/Scroll View/Viewport/Content/MainText").GetComponent<Text>();
        content = transform.Find("Main/Scroll View/Viewport/Content").GetComponent<RectTransform>();
        Options = transform.Find("Options");
        prefab_OptionItem = Resources.Load<GameObject>("Options_Item");
        npc = hitnpc;
        StartDialog(conf, index);
    }

    /// <summary>
    /// 开始对话
    /// </summary>
    private void TestDialog()
    {
        // 找到需要的对话配置文件
        currConf = GameManager.Instance.GetDialogConf(0);
        // 需要从第0条数据开始
        currIndex = 0;
        StartDialog(currConf, 0);
        //
    }

    public void StartDialog(DialogConf conf, int index)
    {
        DialogModel model = conf.DialogModels[index];
        currConf = conf;

        //修改头像和名字
        head.sprite = model.NPCConf.Head;
        nameText.text = model.NPCConf.Name;

        //NPC开始说话
        StartCoroutine(DoMainTextEF(model.NPCContent));

        //NPC事件
        for ( int i = 0; i < model.DialogEventModels.Count; i++)
        {
            ParseDialogEvent(model.DialogEventModels[i].DialogEvent, model.DialogEventModels[i].Args);
        }

        // 玩家选项
        // 1.删除已有选项
        Transform[] items = Options.GetComponentsInChildren<Transform>();
        for ( int i =1; i < items.Length; i++)
        {
            Destroy(items[i].gameObject);
        }
        // 2.生成玩家的选项
        for ( int i = 0; i < model.DialogPlayerSelects.Count;i++)
        {
            UI_Options_Item item = GameObject.Instantiate<GameObject>(prefab_OptionItem, Options).GetComponent<UI_Options_Item>();
            item.Init(model.DialogPlayerSelects[i]);
        }
        for ( int i = 0; i < model.DialogPlayerCondSelects.Count;i++)
        {

            // check player cond -- can be global
            if (player.GetComponent<player_datas>().eventCondList.Contains(model.DialogPlayerCondSelects[i].CondCode))
            {
                UI_Options_Item item = GameObject.Instantiate<GameObject>(prefab_OptionItem, Options).GetComponent<UI_Options_Item>();
                item.Init(model.DialogPlayerCondSelects[i]);
            }
            
        }
        


    }

    public void ParseDialogEvent(DialogEventEnum dialogEvent, string agrs)
    {
        switch (dialogEvent)
        {
            case DialogEventEnum.NextDialog:
                NextDialogEvent();
                break;
            case DialogEventEnum.ExitDialog:
                ExitDialogEvent();
                break;
            case DialogEventEnum.JumpDialog:
                JumpDialogEvent(int.Parse(agrs));
                break;
            case DialogEventEnum.ScreenEffect:
                //GameManager.Instance.ScreenEF(float.Parse(agrs));
                break;
            case DialogEventEnum.startTrade:
                SartTrade(npc);
                break;
            case DialogEventEnum.activeEvent:
                activeEvent(int.Parse(agrs));
                break;
            case DialogEventEnum.addCond:
                addCond(int.Parse(agrs));
                break;
            default:
                break;
        }


    }

    /// <summary>
    /// start trading
    /// </summary>
    private void SartTrade(GameObject npcc)
    {
        UI_trade1.GetComponent<UI_trade>().loadItems(npcc);
        // deactive current dialog ui
        gameObject.SetActive(false);
    }

    private void addCond(int condcode)
    {
        player.GetComponent<player_datas>().eventCondList.Add(condcode);
        Debug.Log("add" + player.GetComponent<player_datas>().eventCondList.Contains(10002));
    }

    private void activeEvent(int evnetId) // match event string and infor from event storage
    {
        if (evnetId == 1)
        {
            player.GetComponent<player_datas>().eventslog.Add("右边救人");
            Debug.Log("Activeevaent:" + evnetId);
            player.GetComponent<player_datas>().eventslog.Add("左边救人");
        }
        
    }
    /// <summary>
    /// next dialog
    /// </summary>
    private void NextDialogEvent()
    {
        currIndex += 1;
        StartDialog(currConf, currIndex);
    }

    /// <summary>
    /// exit dialog
    /// </summary>
    private void ExitDialogEvent()
    {

        Debug.Log("推出对话");
        player.GetComponent<player_movement_ctrl>().exDialog();
        currIndex = 0;
        this.gameObject.SetActive(false);
        for (int i = 0; i < activeList.Length; i++)
        {      
            activeList[i].SetActive(false);
        }
    }

    /// <summary>
    /// jump dialog
    /// </summary>
    private void JumpDialogEvent(int index)
    {
        currIndex = index;
        StartDialog(currConf, currIndex);
    }


    IEnumerator DoMainTextEF(string txt)
    {

        // 字符数量决定了 conteng的高 每23个字符增加25的高
        float addHeight = txt.Length / 23 + 1;
        content.sizeDelta = new Vector2(content.sizeDelta.x, addHeight*25);

        string currStr ="";
        for (int i = 0; i < txt.Length; i++)
        {
            currStr += txt[i];
            yield return new WaitForSeconds(0.08f);
            mainText.text = currStr;
            // 每满23个字，下移一个距离 25
            if (i>23*3&&i % 23 == 0)
            {
                content.anchoredPosition = new Vector2(content.anchoredPosition.x, content.anchoredPosition.y+25);
            }
        }
    }
   
}
