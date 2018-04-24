using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class MoveState_IceSlimeBoss : Sequence
{
    public override void Enter()
    {
        base.Enter();
        //第一次初始化
        if (childrenStates.Count == 0)
        {
            MoveToEnemyState_IceSlimeBoss moveToEnemyState = new MoveToEnemyState_IceSlimeBoss();
            moveToEnemyState.SetCharacterAI(GetAI());
            AddChild(moveToEnemyState);
        }
    }

    public override State Update()
    {
        return base.Update();  
    }
}
