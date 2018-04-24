using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGround_IceSlime1 : MonoBehaviour {
    public float lifeTime;
    public int attack;

	// Use this for initialization
	void Start () {
        currentLifeTime = 0;
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
