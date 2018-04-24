﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class MoveToEnemy_IceSlime : IState
{
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
        IceSlimeAI iceSlimeAI = (IceSlimeAI)GetAI();
        IceSlime iceSlime = (IceSlime)iceSlimeAI.getCharacter();
        GameObject myBody = iceSlime.GetGameObject();

        float distance = Vector3.Distance(myBody.transform.position, iceSlime.currentTarget.transform.position);

        //如果有目标在视野内，则移动向目标，直到可以攻击到目标
        if (distance < iceSlime.getAttr().getAttackRange())
        {
            myBody.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            return State.SUCESSED;
        }

        Room1 room = (Room1)myBody.GetComponentInParent(typeof(Room1));
        float dx = myBody.transform.position.x;
        float dy = myBody.transform.position.y;
        if (dx >= room.transform.position.x + room.max_X || dx <= room.transform.position.x - room.max_X)
        {
            myBody.GetComponent<Rigidbody2D>().velocity = new Vector2(0, myBody.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (dy >= room.transform.position.y + room.max_Y || dy <= room.transform.position.y - room.max_Y)
        {
            myBody.GetComponent<Rigidbody2D>().velocity = new Vector2(myBody.GetComponent<Rigidbody2D>().velocity.x, 0);
        }

        Vector3 dir = (iceSlime.currentTarget.transform.position - myBody.transform.position).normalized;
        myBody.GetComponent<Rigidbody2D>().velocity = dir * GetAI().getCharacter().getAttr().getSpeed() * Time.deltaTime;
        return State.RUNNING;
    }
}
