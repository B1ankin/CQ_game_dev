using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "�¼�����", menuName = "�¼�����/�����¼�")]
public class EventConf : ScriptableObject
{
    [VerticalGroup("Event/EventField"), LabelText("�¼���")]
    public string Name;
    [ListDrawerSettings(ShowIndexLabels = true, AddCopiesLastElement = true)]
    public List<TaskModel> taskModels;
}