using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class MoveToEnemy_FireSlime1 : IState
{
    private float attackRange;
    private float speed;
    public override void Enter()
    {
        base.Enter();
        FireSlime1AI fireSlime1AI = (FireSlime1AI)GetAI();
        FireSlime1 fireSlime1 = (FireSlime1)fireSlime1AI.getCharacter();
        GameObject myBody = fireSlime1.GetGameObject();

        attackRange = fireSlime1.getAttr().getAttackRange();
        speed = fireSlime1.getAttr().getSpeed();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override State Update()
    {
        base.Update();
        FireSlime1AI fireSlime1AI = (FireSlime1AI)GetAI();
        FireSlime1 fireSlime1 = (FireSlime1)fireSlime1AI.getCharacter();
        GameObject myBody = fireSlime1.GetGameObject();

        float distance = Vector3.Distance(myBody.transform.position, fireSlime1.currentTarget.transform.position);
        //如果有目标在视野内，则移动向目标，直到可以攻击到目标
        if (distance < attackRange)
        {
            myBody.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            return State.SUCESSED;
        }

        Vector3 dir = (fireSlime1.currentTarget.transform.position - myBody.transform.position).normalized;
        myBody.GetComponent<Rigidbody2D>().velocity = dir * speed * Time.deltaTime;
        return State.RUNNING;
    }
}
