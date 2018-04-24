using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFire : MonoBehaviour {
    private FireSlime2 Owner;
    public void SetOwner(FireSlime2 Owner)
    {
        this.Owner = Owner;
    }
    public FireSlime2 GetOwner()
    {
        return Owner;
    }

    public float lifeTime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
