using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Item配置", menuName = "道具配置/新增道具")]
public class ItemConf : ScriptableObject
{
    [HorizontalGroup("ITEM", 75, LabelWidth = 50), HideLabel, PreviewField(75)]
    public Sprite Image;
    [VerticalGroup("ITEM/ITEMField"), LabelText("名字")]
    public string Name;
    [VerticalGroup("ITEM/ITEMField"), LabelText("价值")]
    public int worth;
    [VerticalGroup("ITEM/ITEMField"), LabelText("介绍"), Multiline(4)]
    public string ItemContent;
}