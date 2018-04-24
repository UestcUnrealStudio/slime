using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class ThrowMeltedBombState_FireSlime1 : Sequence {

    private GameObject meltedBomb;//熔浆弹

    private float BombSpeed = 300f;

    private float attackRange;//攻击距离

    private float attackRate;//攻击频率

    private float recoverTime = 2;

    public override void Enter()
    {
        base.Enter();
        FireSlime1AI fireSlime1AI = (FireSlime1AI)GetAI();
        FireSlime1 fireSlime1 = (FireSlime1)fireSlime1AI.getCharacter();

        if (childrenStates.Count==0)
        {
            AddChild(fireSlime1AI.GetConditionHaveEnemy());
            fireSlime1AI.GetConditionHaveEnemy().currentState = State.NONE;
            AddChild(fireSlime1AI.GetDistanceCondition());
            fireSlime1AI.GetDistanceCondition().currentState = State.NONE;
            AddChild(fireSlime1AI.GetThrowMeltedBomb());
            fireSlime1AI.GetThrowMeltedBomb().currentState = State.NONE;
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
