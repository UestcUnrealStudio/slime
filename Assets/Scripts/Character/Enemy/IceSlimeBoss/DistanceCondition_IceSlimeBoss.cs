using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class DistanceCondition_IceSlimeBoss : ConditionNode {
    private float attackRange;

    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override State Update()
    {
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();
        GameObject myBody = iceSlimeBoss.GetGameObject();

        float distance = Vector3.Distance(myBody.transform.position, iceSlimeBoss.currentTarget.transform.position);

        if (distance < iceSlimeBoss.getAttr().getAttackRange())
        {
            Debug.Log("距离足够");
            return State.SUCESSED;
        }
        Debug.Log("距离不够");
        return State.FAILED;
    }
}
