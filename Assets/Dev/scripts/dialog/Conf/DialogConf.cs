using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "�Ի�����", menuName = "�Ի�����/�����Ի�����")]
public class DialogConf : ScriptableObject
{
    [LabelText("�Ի�����")]
    [ListDrawerSettings(ShowIndexLabels = true, AddCopiesLastElement =true)]
    public List<DialogModel> DialogModels;
}
