using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu()]
public class OdinMagicItem : ScriptableObject
{

    [PreviewField(60), HideLabel]
    [HorizontalGroup("Split", 60)]
    public Sprite icon;

    [VerticalGroup("Split/Right", 60), LabelWidth(120)]
    public string itemName;

    [VerticalGroup("Split/Right", 60), LabelWidth(120)]
    public string description;

    [VerticalGroup("Split/Right", 60), LabelWidth(120)]
    [Range(0,10)]
    public int durability;

    [VerticalGroup("Split/Right", 60), LabelWidth(120)]
    [HorizontalGroup("Split/Right/Cost", 60)]
    public int cost;

    [HorizontalGroup("Split/Right/Cost", 60)]
    [Button("10")]
    private void CostTo10()
    {
        cost = 10;
    }

    [Button("25")]
    [HorizontalGroup("Split/Right/Cost", 60)]
    private void CostTo25()
    {
        cost = 25;
    }

    [Button("50")]
    [HorizontalGroup("Split/Right/Cost", 60)]
    private void CostTo50()
    {
        cost = 50;
    }
}
