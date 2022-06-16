using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

[Serializable]
public class DialogModel
{
    [HideLabel]
    [OnValueChanged("NPCConfOnValuechanged")]
    public NPCConf NPCConf;

    [HorizontalGroup("NPC", 75, LabelWidth = 50), ReadOnly, HideLabel, PreviewField(75)]
    public Sprite NPCHead;

    [Required(ErrorMessage = "NPC����˵��ʲô")]
    [VerticalGroup("NPC/NPCField"), HideLabel, Multiline(4)]
    public string NPCContent;

    [LabelText("NPC�¼�")]
    public List<DialogEventModel> DialogEventModels;

    [LabelText("NPCѡ��")]
    public List<DialogPlayerSelect> DialogPlayerSelects;

    [LabelText("NPC����ѡ��")]
    public List<DialogPlayerSelect> DialogPlayerCondSelects;

    /// <summary>
    /// NPC�����ļ��޸�ʱ����õķ���
    /// </summary>
    private void NPCConfOnValuechanged()
    {
        if(NPCConf == null || NPCConf.Head == null) 
        {
            Debug.Log("npc no data");
        }
        else
        {
            NPCHead = NPCConf.Head;
        }
    }
}

public enum DialogEventEnum
{
    [LabelText("��һ���Ի�")]
    NextDialog,
    ExitDialog,
    JumpDialog,
    ScreenEffect,
    startTrade,
    activeEvent,
    addCond



}

[Serializable]
public class DialogEventModel
{
    [HideLabel, HorizontalGroup("�¼�", MaxWidth = 100) ]
    public DialogEventEnum DialogEvent;

    [HideLabel, HorizontalGroup("�¼�")]
    public string Args;

}

/// <summary>
/// ���ѡ��
/// </summary>
[Serializable]
public class DialogPlayerSelect
{
    [LabelText("ѡ������"), MultiLineProperty(2), LabelWidth(50)]
    public string Content;
    [LabelText("�¼�")]
    public List<DialogEventModel> DialogEventModels;
    [LabelText("����")]
    public int CondCode = -1; // 10000

}