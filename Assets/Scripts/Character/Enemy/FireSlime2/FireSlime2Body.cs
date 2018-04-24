using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlime2Body : MonoBehaviour {

    private FireSlime2 owner;
    public void SetOwner(FireSlime2 owner)
    {
        this.owner = owner;
    }
    public FireSlime2 GetOwner()
    {
        return owner;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        IBullet bullet = collider.GetComponent<IBullet>();
        if (bullet != null)
        {
            if (owner == null)
            {
                Debug.Log("无控制着");
            }
            owner.UnderAttack(bullet.GetWeapon().GetOwner());
            if (owner.getAttr().getHealth() <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
