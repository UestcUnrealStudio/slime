using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class IceSlime1 : ICharacter {
    private GameObject iceBullet;//冰霜弹
    public void SetIceBullet(GameObject iceBullet)
    {
        this.iceBullet = iceBullet;
    }
    public GameObject GetIceBullet()
    {
        return iceBullet;
    }

    public Collider2D[] targets;//所有可以攻击的目标
    public Collider2D currentTarget;//当前追逐或者攻击的目标

    public IceSlime1(GameObject myBody, CharacterAI AI, ICharacterAttr attr,GameObject iceBullet) : base(myBody, AI, attr)
    {
        myBody.GetComponent<IceSlime1Body>().SetCharacter(this);
        SetIceBullet(iceBullet);
    }
    
    public override float GetAtkValue()
    {
        return base.GetAtkValue();
    }

    public override void UnderAttack(Player player)
    {
        base.UnderAttack(player);
    }

    public override void Update()
    {
        base.Update();
    }
}
