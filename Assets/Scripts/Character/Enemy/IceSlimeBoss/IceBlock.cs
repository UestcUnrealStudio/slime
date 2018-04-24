using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour {
    public int attack = 1;

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall" || collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
