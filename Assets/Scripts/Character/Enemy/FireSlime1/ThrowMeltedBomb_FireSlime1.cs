using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class ThrowMeltedBomb_FireSlime1 : IState
{
    private GameObject meltedBomb;//熔浆弹

    private float BombSpeed = 300f;

    private float attackRate;//攻击频率

    private float recoverTime = 0.5f;

    public override void Enter()
    {
        base.Enter();
        FireSlime1AI fireSlime1AI = (FireSlime1AI)GetAI();
        FireSlime1 fireSlime1 = (FireSlime1)fireSlime1AI.getCharacter();
        GameObject myBody = fireSlime1.GetGameObject();
        attackRate = fireSlime1.getAttr().getAttackRate();
        meltedBomb = fireSlime1.GetMeltedBomb();
        currentAttackRate = 0;
        currentRecoverTime = 0;
        isFire = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    private float currentAttackRate = 0;
    private float currentRecoverTime = 0;
    private bool isFire = false;
    public override State Update()
    {
        base.Update();
        FireSlime1AI fireSlime1AI = (FireSlime1AI)GetAI();
        FireSlime1 fireSlime1 = (FireSlime1)fireSlime1AI.getCharacter();
        GameObject myBody = fireSlime1.GetGameObject();
        if (currentAttackRate < attackRate)
        {
            currentAttackRate += Time.deltaTime;
        }
        else
        {
            if (!isFire)
            {
                GameObject go = Object.Instantiate(meltedBomb, myBody.transform.position, Quaternion.identity);
                Vector3 iceBulletDir = (fireSlime1.currentTarget.transform.position - myBody.transform.position).normalized;
                go.GetComponent<Rigidbody2D>().velocity = iceBulletDir * BombSpeed * Time.deltaTime;
                go.GetComponent<MeltedBomb>().SetOwner(fireSlime1);
                isFire = true;
            }
            else
            {
                if (currentRecoverTime < recoverTime)
                {
                    currentRecoverTime += Time.deltaTime;
                }
                else
                {
                    return State.SUCESSED;
                }
            }
        }
        return State.RUNNING;
    }
}
