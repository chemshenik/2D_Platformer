using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform point;
    public GameObject bullet;
    Rigidbody2D rigidbody;
    Animator animator;
    GameManager GM;
    GameObject mainBullet;
    bool xFlip = false;
    public bool ride = false;
    public bool canShoot = true;
    public bool alive = true;
    public Vector3 bPosition;

    // Start is called before the first frame update
    void Start()
    {
        bPosition = point.localPosition;
        GM = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameObject.AddComponent<CapsuleCollider2D>();
        mainBullet = bullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (Input.GetAxis("Horizontal") > 0 && xFlip)
            {
                Flip();
            }
            else if (Input.GetAxis("Horizontal") < 0 && !xFlip)
            {
                Flip();
            }
            if (Input.GetAxis("Horizontal") != 0)
                animator.SetBool("Move", true);
            else
                animator.SetBool("Move", false);
            rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody.velocity.y);
            //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
            if (Input.GetKeyDown(KeyCode.W))
                rigidbody.AddForce(new Vector2(0f, 520f));
            if (Input.GetKeyDown(KeyCode.E))
                Shoot();
        }
    }
    void FixedUpdate()
    {

    }
    void Flip() {
        xFlip = !xFlip;
        transform.Rotate(0, 180f, 0);
    }
    void Shoot() {
        if(canShoot)
        Instantiate(bullet, point.transform.position, point.transform.rotation);
        animator.SetTrigger("Shoot");
    }
    public void Death() {
        if (!alive)
            return;
        alive = false;
        GM.CameraFollow = false;
        animator.SetTrigger("Death");
        GetComponent<CapsuleCollider2D>().enabled = false;
        rigidbody.AddForce(Vector2.up * 380);
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Stone") {
            if (ride) {
                animator.SetTrigger("DeathMonster");
                bullet = mainBullet;
                Destroy(Instantiate(GM.Poof, col.transform.position, GM.Poof.transform.rotation), 0.2f);
                ride = false;
                canShoot = true;
                point.localPosition = bPosition;
                Destroy(col.gameObject);
            }
            else
                Death();
        }
        if (col.tag == "Item")
        {
            switch (col.gameObject.GetComponent<Pickable>()._Item.type) {
                case Item.ITEM_TYPE.MONSTER:
                    GM.ChangeMonster(col.gameObject.GetComponent<Pickable>()._Item.monstertype);
                    break;
            }
            Destroy(col.gameObject);
        }
    }
}
