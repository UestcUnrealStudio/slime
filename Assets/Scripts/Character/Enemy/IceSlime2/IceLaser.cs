using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class IceLaser : MonoBehaviour  {
    private IceSlime2 owner;
    public void SetOwner(IceSlime2 owner)
    {
        this.owner = owner;
    }
    public IceSlime2 GetOwner()
    {
        return owner;
    }

    private int attack = 2;
    public void SetAttack(int attack)
    {
        this.attack = attack;
    }
    public int GetAttack()
    {
        return attack;
    }

    public float lifeTime = 2f;//激光持续时间

    private Vector3 targetPos;
   
    private float dis;//怪物到敌人的距离
  
    void Start() {
        targetPos = owner.currentTarget.transform.position;
        currentLifeTime = 0;
    }

    private float currentLifeTime = 0;
    private bool isStop = false;
    // Update is called once per frame
    void Update() {
        if (owner.GetGameObject() == null)
        {
            Destroy(gameObject);
            return;
        }
      
        if (!isStop)
        {
            dis = Vector3.Distance(transform.position, owner.GetGameObject().transform.position);
            transform.localScale = new Vector3(transform.localScale.x, dis * 2, transform.localScale.z);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        string layer = LayerMask.LayerToName(collider.gameObject.layer);
        if (layer == "Player" || layer == "Wall")
        {
            isStop = true;
        }
    }
}
