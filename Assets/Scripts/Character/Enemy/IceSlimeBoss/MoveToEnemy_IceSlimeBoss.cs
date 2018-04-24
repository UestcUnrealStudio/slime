using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class MoveToEnemy_IceSlimeBoss : IState
{
    private float attackRange;
    private float speed;
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override State Update()
    {
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();
        GameObject myBody = iceSlimeBoss.GetGameObject();
        attackRange = iceSlimeBoss.getAttr().getAttackRange();
        speed = iceSlimeBoss.getAttr().getSpeed();

        float distance = Vector3.Distance(myBody.transform.position, iceSlimeBoss.currentTarget.transform.position);
        if (distance < attackRange)
        {
            myBody.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            return State.SUCESSED;
        }
        Vector3 dir = (iceSlimeBoss.currentTarget.transform.position - myBody.transform.position).normalized;
        myBody.GetComponent<Rigidbody2D>().velocity = dir * GetAI().getCharacter().getAttr().getSpeed() * Time.deltaTime;
        return State.RUNNING;
    }
}
