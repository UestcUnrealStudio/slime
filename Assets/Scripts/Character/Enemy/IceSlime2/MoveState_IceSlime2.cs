using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class MoveState_IceSlime2 : Selector {

    public override void Enter()
    {
        base.Enter();
        //第一次初始化
        if (childrenStates.Count == 0)
        {
            IceSlime2AI iceSlime2AI = (IceSlime2AI)GetAI();
            childrenStates.Add(iceSlime2AI.GetMoveToTheEnemyState());
            iceSlime2AI.GetMoveToTheEnemyState().currentState = State.NONE;
        }
     
    }

    public override State Update()
    {
        return base.Update();
    }
}
