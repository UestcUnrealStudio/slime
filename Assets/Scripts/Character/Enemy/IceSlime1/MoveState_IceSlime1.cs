using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class MoveState_IceSlime1 : Selector
{
 
    public override void Enter()
    {
        base.Enter();

        //第一次初始化
        if (childrenStates.Count == 0)
        {
            IceSlime1AI iceSlime1AI = (IceSlime1AI)GetAI();
            childrenStates.Add(iceSlime1AI.GetMoveToEnemyState());
        }
    }
    public override State Update()
    {
        return base.Update();
    }
}
