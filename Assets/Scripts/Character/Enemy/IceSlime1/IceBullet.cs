using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour {

    
    public GameObject iceGround;//冰面
    private IceSlime1 owner;
    public void SetOwner(IceSlime1 owner)
    {
        this.owner = owner;
    }
    public IceSlime1 GetOwner()
    {
        return owner;
    }

    public int attack = 1;
    public void SetAttack(int attack)
    {
        this.attack = attack;
    }
    public int GetAttack()
    {
        return attack;
    }

    private float maxDistance;//最远距离即是攻击距离

    private Vector3 ownerPos;
    void Start () {
        currentDistance = 0;
        if (owner == null)
        {
            Debug.Log("没有拥有者");
        }
        maxDistance = owner.getAttr().getAttackRange();
        ownerPos = owner.GetGameObject().transform.position;
    }
    private float currentDistance = 0;

	void Update () {
        if (currentDistance < maxDistance)
        {
            currentDistance = Vector3.Distance(ownerPos, transform.position);
        }
        else
        {
            GameObject iIceGround = Instantiate(iceGround, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        string colliderLayer = LayerMask.LayerToName(collider.gameObject.layer);
        if(colliderLayer=="Player"||colliderLayer== "Obstacle"||colliderLayer =="Wall")
        {
            Debug.Log(collider.gameObject.name);
            GameObject iIceGround = Instantiate(iceGround, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
