using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class NPC_data : MonoBehaviour
{
    [LabelText("�Ի�����")]
    public DialogConf[] dialogConfs;
    public int currentLog;
    public int enterPos;

    [LabelText("��Ʒ����")]
    public List<ItemConf> itemConfs;
    [LabelText("��Ǯ")]
    public int money;

}
