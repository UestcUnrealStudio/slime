using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet_IceSlimeBoss : MonoBehaviour {

    public float lifeTime;

    public int attack;

    public bool isBig;

    public GameObject smallBullet;
    public int number;

    public float speed;

    private float currentLifeTime = 0;
    // Update is called once per frame
    void Update()
    {

        if (currentLifeTime < lifeTime)
        {
            currentLifeTime += Time.deltaTime;
        }
        else
        {  
            if (isBig)
            {
                CreateSmallBullet();
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player" || collider.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collider.GetComponent<IBullet>() != null && isBig)
        {
            CreateSmallBullet();
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }

    void CreateSmallBullet()
    {
        for (int i = 0; i < number; i++)
        {
            GameObject gameObject = Instantiate(smallBullet, transform.position, Quaternion.identity);
            float randomAngle = Random.Range(-60, 60);
            float radians = (Mathf.PI / 180) * randomAngle;
            Vector2 v= GetComponent<Rigidbody2D>().velocity;
            Vector2 randomDir = new Vector2(v.x * Mathf.Cos(radians) + v.y * Mathf.Sin(radians), -v.x * Mathf.Sin(radians) + v.y * Mathf.Cos(radians)).normalized;
            gameObject.GetComponent<Rigidbody2D>().velocity = randomDir * speed * Time.deltaTime;
        }
    }
}
