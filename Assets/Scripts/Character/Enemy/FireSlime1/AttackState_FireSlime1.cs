using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class AttackState_FireSlime1 : Selector {

    public override void Enter()
    {
        base.Enter();
        FireSlime1AI fireSlime1AI = (FireSlime1AI)GetAI();
        FireSlime1 fireSlime1 = (FireSlime1)fireSlime1AI.getCharacter();
        GameObject myBody = fireSlime1.GetGameObject();

        if (childrenStates.Count == 0)
        {
            childrenStates.Add(fireSlime1AI.GetThrowMeltedBombState());
            fireSlime1AI.GetThrowMeltedBombState().currentState = State.NONE;
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
