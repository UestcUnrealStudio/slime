using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
public class ConditionHavaEnemy_IceSlime2 : ConditionNode
{
    private float eyeViewDistance = 30;//视野长度

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
        IceSlime2AI iceSlime2AI = (IceSlime2AI)GetAI();
        IceSlime2 iceSlime2 = (IceSlime2)iceSlime2AI.getCharacter();
        GameObject myBody = iceSlime2.GetGameObject();
        if (iceSlime2.currentTarget != null)
        {
            return State.SUCESSED;
        }

        iceSlime2.targets = Physics2D.OverlapCircleAll(myBody.transform.position, eyeViewDistance, LayerMask.GetMask("Player"));
        Collider2D[] targets = iceSlime2.targets;
        if (targets != null && targets.Length > 0)
        {
            iceSlime2.currentTarget = targets[0];
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
