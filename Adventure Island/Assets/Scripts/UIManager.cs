using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text axes, gCount, rCount, bCount;
    GameManager GM;
    public GameObject UI;
    PlayerStats PS;
    // Start is called before the first frame update
    void Start()
    {
        GM = GetComponent<GameManager>();
        PS = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            UI.SetActive(!UI.activeSelf);
            //this.gameObject.SetActive(!this.gameObject.activeSelf);
        axes.text = PS.axes.ToString();
        gCount.text = PS.gCount.ToString();
        rCount.text = PS.rCount.ToString();
        bCount.text = PS.bCount.ToString();
    }
    public void ChangeMonster(string Stype)
    {
        GameManager.MonsterTYPE type;
        switch (Stype) {
            case "Green":
                type = GameManager.MonsterTYPE.Green;
                break;
            case "Blue":
                type = GameManager.MonsterTYPE.Blue;
                break;
            case "Red":
                type = GameManager.MonsterTYPE.Red;
                break;
            default:
                type = GameManager.MonsterTYPE.NONE;
                break;

        }
        GM.ChangeMonster(type);
    }
}
