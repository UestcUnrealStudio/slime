using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class AttackState_FireSlime : Selector
{
    public override void Enter()
    {
        base.Enter();
        FireSlimeAI fireSlimeAI = (FireSlimeAI)GetAI();
        FireSlime fireSlime = (FireSlime)fireSlimeAI.getCharacter();
        GameObject myBody = fireSlime.GetGameObject();

        if (childrenStates.Count == 0)
        {
            LaunchFusedLaserState_FireSlime launchFusedLaserState = fireSlimeAI.GetLaunchFusedLaserState();
            childrenStates.Add(launchFusedLaserState);
            launchFusedLaserState.currentState = State.NONE;
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
