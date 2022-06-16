using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "事件配置", menuName = "事件配置/新增事件")]
public class EventConf : ScriptableObject
{
    [VerticalGroup("Event/EventField"), LabelText("事件名")]
    public string Name;
    [ListDrawerSettings(ShowIndexLabels = true, AddCopiesLastElement = true)]
    public List<TaskModel> taskModels;
}