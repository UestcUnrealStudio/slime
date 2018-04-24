using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class MoveToEnemyState_IceSlime1 : Sequence
{
    private float eyeViewDistance = 15;//视野长度

    public override void Enter()
    {
        base.Enter();
        IceSlime1AI iceSlime1AI = (IceSlime1AI)GetAI();
        if (childrenStates.Count == 0)
        {
            AddChild(iceSlime1AI.GetConditionHavaEnemy());
            iceSlime1AI.GetConditionHavaEnemy().currentState = State.NONE;
            AddChild(iceSlime1AI.GetMoveToEnemy());
            iceSlime1AI.GetMoveToEnemy().currentState = State.NONE;
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
