using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class ConditionHaveEnemy_IceSlime : ConditionNode {

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
        IceSlimeAI iceSlimeAI = (IceSlimeAI)GetAI();
        IceSlime iceSlime = (IceSlime)iceSlimeAI.getCharacter();
        GameObject myBody = iceSlime.GetGameObject();

        if (iceSlime.currentTarget != null)
        {
            return State.SUCESSED;
        }

        iceSlime.targets = Physics2D.OverlapCircleAll(myBody.transform.position, eyeViewDistance, LayerMask.GetMask("Player"));
        Collider2D[] targets = iceSlime.targets;

        if (targets != null && targets.Length > 0)
        {
            iceSlime.currentTarget = targets[0];
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
