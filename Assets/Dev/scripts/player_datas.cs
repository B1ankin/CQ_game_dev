using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class player_datas : MonoBehaviour
{
    [LabelText("金钱")]
    public int money;
    [LabelText("背包数据")]
    public List<ItemConf> itemConfs;
    [LabelText("事件列表")]
    public List<string> eventslog;
    //public List<EventStr> eventslog;
    [LabelText("已完成状态")]
    public List<int> eventCondList;

    public void loadStatByJson()
    {
       
    }
}

public class EventStr
{
    public int eventid;
    public string displaystr;
    public bool completeBool;
}
