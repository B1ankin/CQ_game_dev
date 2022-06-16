using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "对话配置", menuName = "对话配置/新增对话数据")]
public class DialogConf : ScriptableObject
{
    [LabelText("对话数据")]
    [ListDrawerSettings(ShowIndexLabels = true, AddCopiesLastElement =true)]
    public List<DialogModel> DialogModels;
}
