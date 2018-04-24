using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class DistanceCondition_IceSlime : ConditionNode
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
        IceSlimeAI iceSlimeAI = (IceSlimeAI)GetAI();
        IceSlime iceSlime = (IceSlime)iceSlimeAI.getCharacter();
        GameObject myBody = iceSlime.GetGameObject();
        attackRange = iceSlime.getAttr().getAttackRange();
        if (Vector3.Distance(myBody.transform.position, iceSlime.currentTarget.transform.position) < attackRange)
        {
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
