using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class LaunchIceBullet_IceSlime1 : IState
{
    private float attackRate;

    private GameObject iceBullet;//冰霜弹

    private float iceBulletSpeed = 250;//冰霜弹的速度

    public override void Enter()
    {
        base.Enter();
        IceSlime1AI iceSlime1AI = (IceSlime1AI)GetAI();
        IceSlime1 iceSlime1 = (IceSlime1)iceSlime1AI.getCharacter();
        attackRate = iceSlime1.getAttr().getAttackRate();
        iceBullet = iceSlime1.GetIceBullet();
        currentAttackRate = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    
    private float currentAttackRate = 0;

    public override State Update()
    {
        IceSlime1AI iceSlime1AI = (IceSlime1AI)GetAI();
        IceSlime1 iceSlime1 = (IceSlime1)iceSlime1AI.getCharacter();
        GameObject myBody = iceSlime1.GetGameObject();

        if (currentAttackRate < attackRate)
        {
            //准备发射
            currentAttackRate += Time.deltaTime;
            currentState = State.RUNNING;
        }
        else
        {
            GameObject go = Object.Instantiate(iceBullet, myBody.transform.position, Quaternion.identity);
            Vector3 iceBulletDir = (iceSlime1.currentTarget.transform.position - myBody.transform.position).normalized;
            go.GetComponent<Rigidbody2D>().velocity = iceBulletDir * iceBulletSpeed * Time.deltaTime;
            go.GetComponent<IceBullet>().SetOwner(iceSlime1);

            return State.SUCESSED;
        }
        return State.RUNNING;
    }
}
