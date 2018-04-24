using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class ConditionHaveEnemy_IceSlimeBoss : ConditionNode
{
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
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();
        GameObject myBody = iceSlimeBoss.GetGameObject();

        if (iceSlimeBoss.currentTarget != null)
        {
            return State.SUCESSED;
        }

        iceSlimeBoss.targets = Physics2D.OverlapCircleAll(myBody.transform.position, eyeViewDistance, LayerMask.GetMask("Player"));
        Collider2D[] targets = iceSlimeBoss.targets;
        if (targets != null && targets.Length > 0)
        {
            iceSlimeBoss.currentTarget = targets[0];
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
