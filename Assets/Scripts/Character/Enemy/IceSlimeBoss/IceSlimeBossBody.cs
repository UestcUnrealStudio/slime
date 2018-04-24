using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSlimeBossBody : MonoBehaviour {
    private IceSlimeBoss iceSlimeBoss = null;


	
    public void SetCharacter(IceSlimeBoss iceSlimeBoss)
    {
        this.iceSlimeBoss = iceSlimeBoss;   
    }
    public IceSlimeBoss GetCharacter()
    {
        return iceSlimeBoss;
    }

    //碰撞判定
    void OnTriggerEnter2D(Collider2D collider)
    {
        IBullet bullet = collider.GetComponent<IBullet>();
        if (bullet != null)
        {
            iceSlimeBoss.UnderAttack(bullet.GetWeapon().GetOwner());
            if (iceSlimeBoss.getAttr().getHealth() <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
