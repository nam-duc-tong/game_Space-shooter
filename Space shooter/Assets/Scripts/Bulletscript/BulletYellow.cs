using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletYellow : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myBody;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        myBody.velocity = new Vector2 (0f, speed);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy")
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
        if (target.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
