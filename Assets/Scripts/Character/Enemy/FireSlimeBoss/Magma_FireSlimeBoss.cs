using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma_FireSlimeBoss : MonoBehaviour {
    public float lifeTime;
    public GameObject MoltenLava;

    public int attack;

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
            currentLifeTime = 0;
            GameObject iMoltenLava = Instantiate(MoltenLava, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
