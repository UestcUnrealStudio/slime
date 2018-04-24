using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class DistanceCondition_IceSlime2 : ConditionNode {

    public override void Enter()
    {
        base.Enter();
    }

    // Update is called once per frame
    public override State Update () {
        IceSlime2AI iceSlime2AI = (IceSlime2AI)GetAI();
        IceSlime2 iceSlime2 = (IceSlime2)iceSlime2AI.getCharacter();
        GameObject myBody = iceSlime2.GetGameObject();

        float distance = Vector3.Distance(myBody.transform.position, iceSlime2.currentTarget.transform.position);

        if (distance < iceSlime2.getAttr().getAttackRange())
        {
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
