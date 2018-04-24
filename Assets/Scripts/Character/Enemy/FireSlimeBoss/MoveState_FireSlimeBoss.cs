using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class MoveState_FireSlimeBoss : Selector
{
    public override void Enter()
    {
        base.Enter();
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        if (childrenStates.Count == 0)
        {
            MoveToEnemyState_FireSlimeBoss moveToEnemyState = new MoveToEnemyState_FireSlimeBoss();
            moveToEnemyState.SetCharacterAI(GetAI());
            AddChild(moveToEnemyState);
        }
        Debug.Log("进入移动状态");
    }

    public override State Update()
    {
        return base.Update();
    }
}
