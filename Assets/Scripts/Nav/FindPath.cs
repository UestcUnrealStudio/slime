using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPath : MonoBehaviour {


    public List<Node> path = new List<Node>();

    public Grid grid;

    public Transform targetPos;//目标位置
    
	// Use this for initialization
	void Start() { 

	}
	
	// Update is called once per frame
	void Update () {

        FindingPath();
	}

    void FindingPath()
    {
        Node startNode = new Node(transform.position, true);

    }
}
