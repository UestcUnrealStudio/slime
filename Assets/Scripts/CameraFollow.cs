using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;

    private Vector3 offSet;
	// Use this for initialization
	void Start () {
        offSet = target.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (target == null) return;
        transform.position = target.position - offSet;
    }
}
