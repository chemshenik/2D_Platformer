using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 450, destroyTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, destroyTime);
    }
    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Stone")
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
    }
}
