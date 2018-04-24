using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4IceBullet : MonoBehaviour {
    public int attack;
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, GetComponent<Rigidbody2D>().velocity.normalized, 1, LayerMask.GetMask("Wall"));
        if (raycastHit.collider != null)
        {
            Debug.Log("撞墙反弹");
            Vector2 speed = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = Vector2.Reflect(speed, raycastHit.normal);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag=="Player")
        {
            Destroy(gameObject);
        }
        if (collider.GetComponent<IBullet>() != null)
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
