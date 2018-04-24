using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class IceSlime : ICharacter
{
    private GameObject ice;//冰锥
    public void SetIce(GameObject ice)
    {
        this.ice = ice;
    }
    public GameObject GetIce()
    {
        return ice;
    }

    public Collider2D[] targets;//所有可以攻击的目标
    public Collider2D currentTarget;//当前追逐或者攻击的目标

    public IceSlime(GameObject myBody, IceSlimeAI AI, IceSlimeAttr attr,GameObject ice) : base(myBody, AI, attr)
    {
        myBody.GetComponent<IceSlimeBody>().SetCharacter(this);
        SetIce(ice);
    }
    public override void Update()
    {
        base.Update();
    }

    public override void UnderAttack(Player player)
    {
        base.UnderAttack(player);
    }

}
