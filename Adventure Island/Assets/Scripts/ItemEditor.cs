using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Item item = (Item)target;
        item.name = EditorGUILayout.TextField("Item name", item.name);
        item.sprite = (Sprite)EditorGUILayout.ObjectField("Sprite", item.sprite, typeof(Sprite), true);
        item.type = (Item.ITEM_TYPE)EditorGUILayout.EnumPopup("Item type", item.type);
        if (item.type == Item.ITEM_TYPE.MONSTER)
        {
            item.monstertype = (GameManager.MonsterTYPE)EditorGUILayout.EnumPopup("Monster type", item.monstertype);
            if (item.monstertype != GameManager.MonsterTYPE.Green)
            {
                item.bullet = (GameObject)EditorGUILayout.ObjectField("Bullet Prefab", item.bullet, typeof(GameObject), true);
                item.bulletPosition = EditorGUILayout.Vector3Field("Bullet position", item.bulletPosition);
            }
        }
    }
}
