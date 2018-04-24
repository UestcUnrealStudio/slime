using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class IceSlimeBoss : ICharacter {

    private GameObject ice;//冰锥
    public GameObject GetIce()
    {
        return ice;
    }
    public void SetIce(GameObject ice)
    {
        this.ice = ice;
    }

    private GameObject iceBlock;//冰块
    public GameObject GetIceBlock()
    {
        return iceBlock;
    }
    public void SetIceBlock(GameObject iceBlock)
    {
        this.iceBlock = iceBlock;
    }

    private GameObject shield;//护盾
    public GameObject GetShield()
    {
        return shield;
    }
    public void SetShield(GameObject shield)
    {
        this.shield = shield;
    }

    private GameObject iceBullet;//冰霜弹
    public void SetIceBullet(GameObject iceBullet)
    {
        this.iceBullet = iceBullet;
    }
    public GameObject GetIceBullet()
    {
        return iceBullet;
    }

    public GameObject IceBulletSkill2;
    public GameObject IceBulletSkill3;
    public GameObject IceBulletSkill4;

    public Collider2D[] targets;
    public Collider2D currentTarget;//所要攻击的目标

    public IceSlimeBoss(GameObject myBody, CharacterAI AI, ICharacterAttr attr) : base(myBody, AI, attr)
    {
        myBody.GetComponent<IceSlimeBossBody>().SetCharacter(this);
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
