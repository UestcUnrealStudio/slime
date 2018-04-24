using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoltenLava_FireSlime1 : MonoBehaviour {
    public int attack;

    public float lifeTime; 
	// Use this for initialization
	void Start () {
        currentLifeTime = 0;
	}
    
    private float currentLifeTime = 0;
	// Update is called once per frame
	void Update () {
        if (currentLifeTime < lifeTime)
        {
            currentLifeTime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
