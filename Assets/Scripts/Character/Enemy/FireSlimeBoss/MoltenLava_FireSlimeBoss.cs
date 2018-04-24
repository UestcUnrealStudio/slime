using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoltenLava_FireSlimeBoss : MonoBehaviour {
    public float lifeTime;
    public int attack;

	// Use this for initialization
	void Start () {
		
	}

    private float currentLifeTime = 0;
	// Update is called once per frame
	void Update () {
        if (currentLifeTime<lifeTime)
        {
            currentLifeTime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
