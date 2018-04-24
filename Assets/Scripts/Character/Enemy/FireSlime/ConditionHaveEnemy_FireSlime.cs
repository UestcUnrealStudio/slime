using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class ConditionHaveEnemy_FireSlime : IState {

    private float eyeViewDistance = 30;

    public ConditionHaveEnemy_FireSlime()
    {
        currentState = State.NONE;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override State Update()
    {
        FireSlimeAI fireSlimeAI = (FireSlimeAI)GetAI();
        FireSlime fireSlime = (FireSlime)fireSlimeAI.getCharacter();
        GameObject myBody = fireSlime.GetGameObject();

        if (fireSlime.currentTarget != null)
        {
            return State.SUCESSED;
        }

        fireSlime.targets = Physics2D.OverlapCircleAll(myBody.transform.position, eyeViewDistance, LayerMask.GetMask("Player"));
        Collider2D[] targets = fireSlime.targets;

        if (targets != null && targets.Length > 0)
        {
            fireSlime.currentTarget = targets[0];
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
