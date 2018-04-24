using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class DistanceCondition_FireSlimeBoss : ConditionNode
{
    private float attackRange;
    public override void Enter()
    {
        base.Enter();
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();

        attackRange = fireSlimeBoss.getAttr().getAttackRange();

        Debug.Log("判断距离是否足够");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override State Update()
    {
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
        GameObject myBody = fireSlimeBoss.GetGameObject();
        float distance = Vector3.Distance(myBody.transform.position, fireSlimeBoss.currentTarget.transform.position);
        Debug.Log(distance + " " + attackRange);
        if (distance<attackRange)
        {
            Debug.Log("距离足够");
            return State.SUCESSED;
        }
        Debug.Log("距离不够");
        return State.FAILED;
    }
}
