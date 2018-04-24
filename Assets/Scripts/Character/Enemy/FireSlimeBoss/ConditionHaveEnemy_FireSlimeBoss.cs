using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class ConditionHaveEnemy_FireSlimeBoss : ConditionNode
{
    private float eyeViewDistance = 25;
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
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
        GameObject myBody = fireSlimeBoss.GetGameObject();

        if (fireSlimeBoss.currentTarget != null)
        {
            Debug.Log("存在敌人");
            return State.SUCESSED;
        }

        fireSlimeBoss.targets = Physics2D.OverlapCircleAll(myBody.transform.position, eyeViewDistance, LayerMask.GetMask("Player"));
        Collider2D[] targets = fireSlimeBoss.targets;

        if (targets != null && targets.Length > 0)
        {
            fireSlimeBoss.currentTarget = targets[0];
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
