using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class player_datas : MonoBehaviour
{
    [LabelText("��Ǯ")]
    public int money;
    [LabelText("��������")]
    public List<ItemConf> itemConfs;
    [LabelText("�¼��б�")]
    public List<string> eventslog;
    //public List<EventStr> eventslog;
    [LabelText("�����״̬")]
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
