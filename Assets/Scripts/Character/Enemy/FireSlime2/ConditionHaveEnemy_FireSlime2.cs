using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class ConditionHaveEnemy_FireSlime2 : ConditionNode {

    private float eyeViewDistance = 30;

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
        FireSlime2AI fireSlime2AI = (FireSlime2AI)GetAI();
        FireSlime2 fireSlime2 = (FireSlime2)fireSlime2AI.getCharacter();
        GameObject myBody = fireSlime2.GetGameObject();
        if (fireSlime2.currentTarget != null)
        {
            return State.SUCESSED;
        }

        fireSlime2.targets = Physics2D.OverlapCircleAll(myBody.transform.position, eyeViewDistance, LayerMask.GetMask("Player"));
        Collider2D[] targets = fireSlime2.targets;
        Collider2D currentTarget;
        if (targets != null && targets.Length != 0)
        {
            fireSlime2.currentTarget = targets[0];
            currentTarget = targets[0];
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
