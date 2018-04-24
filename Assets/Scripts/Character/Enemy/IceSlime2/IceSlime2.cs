using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class IceSlime2 : ICharacter {
    private GameObject iceLaser;//冰霜光束
    public void SetIceLaser(GameObject iceLaser)
    {
        this.iceLaser = iceLaser;
    }
    public GameObject GetIceLaser()
    {
        return iceLaser;
    }

    public Collider2D[] targets;//所有可以攻击的目标
    public Collider2D currentTarget;//当前追逐或者攻击的目标

    public IceSlime2(GameObject myBody, CharacterAI AI, ICharacterAttr attr,GameObject iceLaser) : base(myBody, AI, attr)
    {
        SetIceLaser(iceLaser);
        myBody.GetComponent<IceSlime2Body>().SetCharacter(this);
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
