using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class IceSlime1Body : MonoBehaviour {

    private IceSlime1 owner = null;

    public IceSlime1 GetCharacter()
    {
        return owner;
    }
    public void SetCharacter(IceSlime1 owner)
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
