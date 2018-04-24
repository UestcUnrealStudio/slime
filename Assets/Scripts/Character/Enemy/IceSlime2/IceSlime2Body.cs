using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSlime2Body : MonoBehaviour {
    private IceSlime2 owner = null;

    public IceSlime2 GetCharacter()
    {
        return owner;
    }
    public void SetCharacter(IceSlime2 owner)
    {
        this.owner = owner;
    }

    //碰撞判定
    void OnTriggerEnter2D(Collider2D collider)
    {
        IBullet bullet = collider.GetComponent<IBullet>();
        if (bullet != null)
        {
            owner.UnderAttack(bullet.GetWeapon().GetOwner());
            if (owner.getAttr().getHealth() <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
