using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class NormalAttack_IceSlimeBoss : IState
{
    private GameObject IceBullet;
    private float IceBulletSpeed = 500;
    public override void Enter()
    {
        base.Enter();
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();

        IceBullet = iceSlimeBoss.GetIceBullet();
    }

    public override void Exit()
    {
        base.Exit();
        GetAI().getCharacter().GetGameObject().GetComponent<SkillUnit>().ReSetCurrentSkillTime(4);
    }

    public override State Update()
    {
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();
        GameObject myBody = iceSlimeBoss.GetGameObject();
        Vector3 dir = (iceSlimeBoss.currentTarget.transform.position - myBody.transform.position).normalized;
        GameObject iIceBullet = Object.Instantiate(IceBullet, myBody.transform.position, Quaternion.identity);
        iIceBullet.transform.localScale = new Vector3(2, 2, 0);
        iIceBullet.GetComponent<Rigidbody2D>().velocity = dir * IceBulletSpeed * Time.deltaTime;
        return State.SUCESSED;
    }
}
