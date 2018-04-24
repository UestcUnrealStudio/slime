using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class MoveState_IceSlime : Selector
{
    public override void Enter()
    {
        base.Enter();
        //第一次初始化
        if (childrenStates.Count == 0)
        {
            IceSlimeAI iceSlimeAI = (IceSlimeAI)GetAI();
            childrenStates.Add(iceSlimeAI.GetMoveToEnemyState());
        }
      
    }
    
    public override State Update()
    {
        return base.Update();
    }
}
