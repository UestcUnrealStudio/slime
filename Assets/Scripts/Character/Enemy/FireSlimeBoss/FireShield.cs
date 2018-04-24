using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShield : MonoBehaviour {
    public float health = 10;
    public void SetHealth(float health)
    {
        this.health = health;
    }
    public float GetHealth()
    {
        return health;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        IBullet bullet = collider.GetComponent<IBullet>();
        if (bullet != null)
        {
            health -= 1;
        }
    }
}
