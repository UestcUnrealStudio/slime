using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class IceSlimeBody : MonoBehaviour {

    private IceSlime owner = null;

    public IceSlime GetCharacter()
    {
        return owner;
    }
    public void SetCharacter(IceSlime owner)
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
