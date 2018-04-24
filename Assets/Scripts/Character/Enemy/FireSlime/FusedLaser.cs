using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusedLaser : MonoBehaviour {

    private float lastTime = 5;
    public int attack;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lastTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag=="Wall")
        {
            Destroy(gameObject);
        }

    }
}
