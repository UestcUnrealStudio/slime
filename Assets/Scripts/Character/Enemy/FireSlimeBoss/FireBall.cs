using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {


    public GameObject smallFireBall;
    public int number;
    public bool isSmall;
    public float MaxlifeTime;
    public float MinlifeTIme;
    public float lifeTime;
    public int attack;

    public float smallFireBallSpeed;
    private float currentLifeTime = 0;

    void Start()
    {
        lifeTime = Random.Range(MinlifeTIme, MaxlifeTime);
        attack = isSmall ? 1 : 2;
    }

    void Update()
    {
        if (!isSmall)
        {
            if (currentLifeTime < lifeTime)
            {
                currentLifeTime += Time.deltaTime;
            }
            else
            {
                float angle = 360 / number;
                for (int i = 0; i < number; i++)
                {
                    GameObject iSmallFireBall = GameObject.Instantiate(smallFireBall, transform.position, Quaternion.identity);
                    float addAngle = Random.Range(-30, 30);
                    iSmallFireBall.transform.localRotation *= Quaternion.Euler(0, 0, i * angle + addAngle);
                }
                Destroy(gameObject);
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * smallFireBallSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collider )
    {

        if (collider.tag == "Wall" || collider.tag == "Player")
        {
            Destroy(gameObject);
        }
          
    }
}
