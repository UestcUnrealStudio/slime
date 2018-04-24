using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class DistanceCondition_IceSlime1 : ConditionNode
{
    private float attackRange;

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
        IceSlime1AI iceSlime1AI = (IceSlime1AI)GetAI();
        IceSlime1 iceSlime1 = (IceSlime1)iceSlime1AI.getCharacter();
        GameObject myBody = iceSlime1.GetGameObject();

        attackRange = iceSlime1.getAttr().getAttackRange();
        float distance = Vector3.Distance(myBody.transform.position, iceSlime1.currentTarget.transform.position);
        if (distance<attackRange)
        {
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
