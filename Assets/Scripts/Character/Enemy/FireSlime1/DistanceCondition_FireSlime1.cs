using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class DistanceCondition_FireSlime1 : ConditionHaveEnemy_FireSlime1
{

    private float attackRange;
    public override void Enter()
    {
        base.Enter();
        FireSlime1AI fireSlime1AI = (FireSlime1AI)GetAI();
        FireSlime1 fireSlime1 = (FireSlime1)fireSlime1AI.getCharacter();
        GameObject myBody = fireSlime1.GetGameObject();

        attackRange = fireSlime1.getAttr().getAttackRange();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override State Update()
    {
        FireSlime1AI fireSlime1AI = (FireSlime1AI)GetAI();
        FireSlime1 fireSlime1 = (FireSlime1)fireSlime1AI.getCharacter();
        GameObject myBody = fireSlime1.GetGameObject();

        if (Vector3.Distance(myBody.transform.position, fireSlime1.currentTarget.transform.position) < attackRange)
        {
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
