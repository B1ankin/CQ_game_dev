using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class NPC_data : MonoBehaviour
{
    [LabelText("对话数据")]
    public DialogConf[] dialogConfs;
    public int currentLog;
    public int enterPos;

    [LabelText("商品数据")]
    public List<ItemConf> itemConfs;
    [LabelText("金钱")]
    public int money;

}
