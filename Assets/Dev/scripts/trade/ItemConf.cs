using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Item����", menuName = "��������/��������")]
public class ItemConf : ScriptableObject
{
    [HorizontalGroup("ITEM", 75, LabelWidth = 50), HideLabel, PreviewField(75)]
    public Sprite Image;
    [VerticalGroup("ITEM/ITEMField"), LabelText("����")]
    public string Name;
    [VerticalGroup("ITEM/ITEMField"), LabelText("��ֵ")]
    public int worth;
    [VerticalGroup("ITEM/ITEMField"), LabelText("����"), Multiline(4)]
    public string ItemContent;
}