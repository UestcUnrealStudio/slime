using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusedLaserBall_FireSlimeBoss : MonoBehaviour {
    public int health;

    public float duringTime;

    public GameObject fusedLaser;

    public float fusedLaserSpeed;

    private float currentDuringTime=0;
	// Use this for initialization
	void Start () {
        currentDuringTime = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (currentDuringTime < duringTime)
        {
            currentDuringTime += Time.deltaTime;
        }
        else
        {
            CreateFusedLaser();
            currentDuringTime = 0;
        }
    }

    void CreateFusedLaser()
    {
        GameObject iFusedLaer = Instantiate(fusedLaser, transform.position, Quaternion.identity);
        float randomAngle = Random.Range(-180,180);
        iFusedLaer.transform.localRotation *= Quaternion.Euler(0, 0, randomAngle);
        iFusedLaer.GetComponent<Rigidbody2D>().velocity = iFusedLaer.transform.up * fusedLaserSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<IBullet>() != null)
        {
            IBullet bullet = collider.GetComponent<IBullet>();
            health -= 1;
            if (health<=0)
            {
                Destroy(gameObject);
            }
            Destroy(collider.gameObject);
        }
    }
}
