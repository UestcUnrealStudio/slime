using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class MoveState_FireSlime1 : Selector
{
 
    public override void Enter()
    {
        base.Enter();
        FireSlime1AI fireSlime1AI = (FireSlime1AI)GetAI();
        FireSlime1 fireSlime1 = (FireSlime1)fireSlime1AI.getCharacter();
        GameObject myBody = fireSlime1.GetGameObject();

        if (childrenStates.Count == 0)
        {
            childrenStates.Add(fireSlime1AI.GetMoveToEnemyState());
            fireSlime1AI.GetMoveToEnemyState().currentState = State.NONE;
        }
    }
    public override State Update()
    {
        return base.Update();
    }
}
