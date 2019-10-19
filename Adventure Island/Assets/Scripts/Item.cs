using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Add item")]
public class Item : ScriptableObject
{
    public string name;
    public Sprite sprite;
    public ITEM_TYPE type;
    public GameManager.MonsterTYPE monstertype;
    public GameObject bullet;
    public Vector3 bulletPosition;
    public enum ITEM_TYPE {
        WEAPON,
        FOOD,
        MONSTER
    }
}
