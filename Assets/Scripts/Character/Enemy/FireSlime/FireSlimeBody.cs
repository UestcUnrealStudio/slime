using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class FireSlimeBody : MonoBehaviour {
    public Transform FirePostion;

    private FireSlime myCharacter = null;

    public ICharacter GetCharacter()
    {
        return myCharacter;
    }
    public void SetCharacter(FireSlime fireSlime )
    {
        myCharacter = fireSlime;
    }

    //碰撞判定
   void OnTriggerEnter2D(Collider2D collider)
    {
        IBullet bullet = collider.GetComponent<IBullet>();
        if (bullet!=null)
        {
            Debug.Log("被攻击");
            myCharacter.UnderAttack(bullet.GetWeapon().GetOwner());
            if (myCharacter.getAttr().getHealth() <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
