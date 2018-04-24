using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class MoveToEnemy_FireSlimeBoss : IState
{
    private float speed;
    private float attackRange;
    public override void Enter()
    {
        base.Enter();
        speed = GetAI().getCharacter().getAttr().getSpeed();
        attackRange = GetAI().getCharacter().getAttr().getAttackRange();
        Debug.Log("准备移动向敌人");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override State Update()
    {
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
        GameObject myBody = fireSlimeBoss.GetGameObject();

        float distance = Vector3.Distance(myBody.transform.position, fireSlimeBoss.currentTarget.transform.position);
        //如果有目标在视野内，则移动向目标，直到可以攻击到目标
        if (distance < attackRange)
        {
            Debug.Log(distance + " 1 " + attackRange);
            myBody.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            return State.SUCESSED;
        }

        BossRoom_FireSlimeScene room = (BossRoom_FireSlimeScene)myBody.GetComponentInParent(typeof(BossRoom_FireSlimeScene));
        float dx = myBody.transform.position.x;
        float dy = myBody.transform.position.y;
        if (dx >= room.transform.position.x + room.dx || dx <= room.transform.position.x - room.dx)
        {
            myBody.GetComponent<Rigidbody2D>().velocity = new Vector2(0, myBody.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (dy >= room.transform.position.y + room.dy || dy <= room.transform.position.y - room.dy)
        {
            myBody.GetComponent<Rigidbody2D>().velocity = new Vector2(myBody.GetComponent<Rigidbody2D>().velocity.x, 0);
        }

        Vector3 dir = (fireSlimeBoss.currentTarget.transform.position - myBody.transform.position).normalized;
      
        myBody.GetComponent<Rigidbody2D>().velocity = dir * speed * Time.deltaTime;
        Debug.Log(dir + " " + myBody.GetComponent<Rigidbody2D>().velocity + " " + speed);
        return State.RUNNING;
    }
}
