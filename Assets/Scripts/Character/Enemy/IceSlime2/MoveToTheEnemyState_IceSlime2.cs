using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class MoveToTheEnemyState_IceSlime2 : Sequence
{
    public override void Enter()
    {
        base.Enter();
     
        IceSlime2AI iceSlime2AI = (IceSlime2AI)GetAI();
        if (childrenStates.Count == 0)
        {
            AddChild(iceSlime2AI.GetConditionHavaEnemy());
            Decorator_NotNode decorator_NotNode = new Decorator_NotNode();
            AddChild(decorator_NotNode);
            decorator_NotNode.AddChild(iceSlime2AI.GetDistanceCondition());
            iceSlime2AI.GetDistanceCondition().currentState = State.NONE;
            decorator_NotNode.currentState = State.NONE;
            AddChild(iceSlime2AI.GetMoveToTheEnemy());
            iceSlime2AI.GetConditionHavaEnemy().currentState = State.NONE;
            iceSlime2AI.GetMoveToTheEnemy().currentState = State.NONE;
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
