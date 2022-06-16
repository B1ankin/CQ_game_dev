using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "NPC配置", menuName = "角色配置/新增角色")]
public class NPCConf : ScriptableObject
{
    [HorizontalGroup("NPC", 75, LabelWidth =50), HideLabel, PreviewField(75)]
    public Sprite Head;
    [VerticalGroup("NPC/NPCField"),LabelText("名字")]
    public string Name;
}
