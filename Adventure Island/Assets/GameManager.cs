using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image XBar;
    public float CX = 100;
    public RuntimeAnimatorController Player;
    GameObject player;
    public GameObject Poof;
    public float SmoothX, SmoothY;
    Vector2 velocity;
    public bool CameraFollow = true;
    public Item Blue, Red;
    // Start is called before the first frame update
    public enum MonsterTYPE {
        NONE,
        Blue,
        Red,
        Green
    }
    void Start()
    {
        Blue = Resources.Load<Item>("Items/Monsters/BlueMonster");
        Red = Resources.Load<Item>("Items/Monsters/RedMonster");
        player = GameObject.FindGameObjectWithTag("Player");
        
        //main = player.GetComponent<Animator>().runtimeAnimatorController;
        //second = SecondPlayer.GetComponent<Animator>().runtimeAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            monsterTYPE = MonsterTYPE.Blue;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            monsterTYPE = MonsterTYPE.Red;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            monsterTYPE = MonsterTYPE.Green;
        }*/

        if (CX == 0 && player.GetComponent<Player>().alive)
            player.GetComponent<Player>().Death();
        else
        {
            CX -= Time.deltaTime;
            CX = Mathf.Clamp(CX, 0, 100);
        }
        //XBar.fillAmount = CX / 100;
        if(CameraFollow)
        CameraFollowing();

    }
    void CameraFollowing()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, SmoothX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, SmoothY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
    public void ChangeMonster(MonsterTYPE typeMonster) {
        switch (typeMonster) {
            case MonsterTYPE.Blue:
                player.GetComponent<Animator>().SetTrigger("BlueMonster");
                player.GetComponent<Player>().canShoot = true;
                ChangeBullet(Blue);
                break;
            case MonsterTYPE.Red:
                player.GetComponent<Animator>().SetTrigger("RedMonster");
                player.GetComponent<Player>().canShoot = true;
                ChangeBullet(Red);
                break;
            case MonsterTYPE.Green:
                player.GetComponent<Animator>().SetTrigger("GreenMonster");
                player.GetComponent<Player>().canShoot = false;
                break;
            case MonsterTYPE.NONE:
                player.GetComponent<Animator>().runtimeAnimatorController = Player;
                break;
        }
        player.GetComponent<Player>().ride = true;
    }
    public void ChangeBullet(Item item)
    {
        Debug.Log(item.type.ToString());
        player.GetComponent<Player>().point.localPosition = item.bulletPosition;
        player.GetComponent<Player>().bullet = item.bullet;
    }
}
