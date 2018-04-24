using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class ConditionHavaEnemy_IceSlime1 : ConditionNode
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
        IceSlime1AI iceSlime1AI = (IceSlime1AI)GetAI();
        IceSlime1 iceSlime1 = (IceSlime1)iceSlime1AI.getCharacter();
        GameObject myBody = iceSlime1.GetGameObject();

        if (iceSlime1.currentTarget != null)
        {
            return State.SUCESSED;
        }

        iceSlime1.targets = Physics2D.OverlapCircleAll(myBody.transform.position, eyeViewDistance, LayerMask.GetMask("Player"));
        Collider2D[] targets = iceSlime1.targets;
        if (targets != null && targets.Length > 0)
        {
            iceSlime1.currentTarget = targets[0];
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
