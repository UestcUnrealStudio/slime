using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSlimeBossBody : MonoBehaviour {
    private FireSlimeBoss Owner;
    public void SetCharacter(FireSlimeBoss fireSlimeBoss)
    {
        Owner = fireSlimeBoss;
    }
    public FireSlimeBoss GetCharacter()
    {
        return Owner;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        IBullet bullet = collider.GetComponent<IBullet>();
        if (bullet != null)
        {
            Debug.Log("受到攻击");
            Owner.UnderAttack(bullet.GetWeapon().GetOwner());
            Debug.Log(Owner.getAttr().getHealth());
            if (Owner.getAttr().getHealth() <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    //受到的攻击随机成正态分布
    float AttachAtk()
    {
        float i1 = Random.Range(-1, 1);
        float i2 = Random.Range(-1, 1);
        float i3 = Random.Range(-1, 1);
        return (i1 + i2 + i3);
    }
}
