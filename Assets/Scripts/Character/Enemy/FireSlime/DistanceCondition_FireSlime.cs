using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class DistanceCondition_FireSlime : ConditionNode
{
    private float attackRange;

    public override void Enter()
    {
        FireSlimeAI fireSlimeAI = (FireSlimeAI)GetAI();
        FireSlime fireSlime = (FireSlime)fireSlimeAI.getCharacter();

        attackRange = fireSlime.getAttr().getAttackRange();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override State Update()
    {
        FireSlimeAI fireSlimeAI = (FireSlimeAI)GetAI();
        FireSlime fireSlime = (FireSlime)fireSlimeAI.getCharacter();
        GameObject myBody = fireSlime.GetGameObject();

        if (Vector3.Distance(myBody.transform.position,fireSlime.currentTarget.transform.position)<attackRange)
        {
            return State.SUCESSED;
        }

        return State.FAILED;
    }
}
