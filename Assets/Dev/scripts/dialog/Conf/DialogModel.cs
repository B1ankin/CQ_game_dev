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

    [Required(ErrorMessage = "NPC必须说点什么")]
    [VerticalGroup("NPC/NPCField"), HideLabel, Multiline(4)]
    public string NPCContent;

    [LabelText("NPC事件")]
    public List<DialogEventModel> DialogEventModels;

    [LabelText("NPC选项")]
    public List<DialogPlayerSelect> DialogPlayerSelects;

    [LabelText("NPC条件选项")]
    public List<DialogPlayerSelect> DialogPlayerCondSelects;

    /// <summary>
    /// NPC配置文件修改时候调用的方法
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
    [LabelText("下一条对话")]
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
    [HideLabel, HorizontalGroup("事件", MaxWidth = 100) ]
    public DialogEventEnum DialogEvent;

    [HideLabel, HorizontalGroup("事件")]
    public string Args;

}

/// <summary>
/// 玩家选择
/// </summary>
[Serializable]
public class DialogPlayerSelect
{
    [LabelText("选项文字"), MultiLineProperty(2), LabelWidth(50)]
    public string Content;
    [LabelText("事件")]
    public List<DialogEventModel> DialogEventModels;
    [LabelText("条件")]
    public int CondCode = -1; // 10000

}