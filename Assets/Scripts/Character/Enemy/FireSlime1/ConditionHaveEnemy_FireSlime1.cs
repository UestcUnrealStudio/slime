using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class ConditionHaveEnemy_FireSlime1 : ConditionNode
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
        FireSlime1AI fireSlime1AI = (FireSlime1AI)GetAI();
        FireSlime1 fireSlime1 = (FireSlime1)fireSlime1AI.getCharacter();
        GameObject myBody = fireSlime1.GetGameObject();

        if (fireSlime1.currentTarget != null)
        {
            return State.SUCESSED;
        }

        fireSlime1.targets = Physics2D.OverlapCircleAll(myBody.transform.position, eyeViewDistance, LayerMask.GetMask("Player"));
        Collider2D[] targets = fireSlime1.targets;
        if (targets!=null&&targets.Length>0)
        {
            fireSlime1.currentTarget = targets[0];
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
