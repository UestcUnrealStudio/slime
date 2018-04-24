using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class MoveToEnemy_FireSlime : IState
{

    private float eyeViewDistance = 15;

    public MoveToEnemy_FireSlime()
    {
        currentState = State.NONE;
    }

    public override void Enter()
    {

    }

    public override State Update()
    {
        FireSlimeAI fireSlimeAI = (FireSlimeAI)GetAI();
        FireSlime fireSlime = (FireSlime)fireSlimeAI.getCharacter();
        GameObject myBody = fireSlime.GetGameObject();

        float distance = Vector3.Distance(myBody.transform.position, fireSlime.currentTarget.transform.position);
        //如果有目标在视野内，则移动向目标，直到可以攻击到目标
        if (distance < fireSlime.getAttr().getAttackRange())
        {
            myBody.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            return State.SUCESSED;
        }

        Vector3 dir = (fireSlime.currentTarget.transform.position - myBody.transform.position).normalized;
        myBody.GetComponent<Rigidbody2D>().velocity = dir * GetAI().getCharacter().getAttr().getSpeed() * Time.deltaTime;

        return State.RUNNING; ;
    }
}
