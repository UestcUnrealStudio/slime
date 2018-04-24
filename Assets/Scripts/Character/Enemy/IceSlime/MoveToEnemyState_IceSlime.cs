using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class MoveToEnemyState_IceSlime : Sequence {

    public override void Enter()
    {
        base.Enter();

        IceSlimeAI iceSlimeAI = (IceSlimeAI)GetAI();
        if (childrenStates.Count == 0)
        {
            AddChild(iceSlimeAI.GetConditionHaveEnemy());
            iceSlimeAI.GetConditionHaveEnemy().currentState = State.NONE;
            AddChild(iceSlimeAI.GetMoveToEnemy());
            iceSlimeAI.GetMoveToEnemy().currentState = State.NONE;
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
