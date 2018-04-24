using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class LaunchIce_IceSlime : IState
{

    private GameObject ice;//发射的冰锥

    private float iceSpeed = 400f;

    private float attackRate;//攻击频率

    private float recoverTime = 0.5f;

    private float angle;
    public override void Enter()
    {
        base.Enter();
        IceSlimeAI iceSlimeAI = (IceSlimeAI)GetAI();
        IceSlime iceSlime = (IceSlime)iceSlimeAI.getCharacter();
        GameObject myBody = iceSlime.GetGameObject();
        ice = iceSlime.GetIce();
        attackRate = iceSlime.getAttr().getAttackRate();
        currentAttackRate = 0;
        currentRecoverTime = 0;
        isFire = false;
        currentDuring = fireDuring;
        count = 5;
        angle = Vector3.Angle(myBody.transform.up, (iceSlime.currentTarget.transform.position - myBody.transform.position).normalized);
        Vector3 cro = Vector3.Cross(myBody.transform.up, (iceSlime.currentTarget.transform.position - myBody.transform.position).normalized);
        angle *= Vector3.Dot(cro.normalized, myBody.transform.forward);
    }

    public override void Exit()
    {
        base.Exit();
    }

    private float currentAttackRate = 0;
    private float currentRecoverTime = 0;
    private bool isFire = false;
    private int count = 5;

    private float fireDuring = 0.3f;
    private float currentDuring;
    public override State Update()
    {
        IceSlimeAI iceSlimeAI = (IceSlimeAI)GetAI();
        IceSlime iceSlime = (IceSlime)iceSlimeAI.getCharacter();
        GameObject myBody = iceSlime.GetGameObject();
        if (currentAttackRate < attackRate)
        {
            currentAttackRate += Time.deltaTime;
            currentState = State.RUNNING;
        }
        else
        {
            if (!isFire)
            {
                if (currentDuring >= fireDuring) { 
                    currentDuring = 0;
                    GameObject go = Object.Instantiate(ice, myBody.transform.position, Quaternion.identity);
                    float rad = Random.Range(-5, 5);
                    go.transform.localRotation *= Quaternion.Euler(0, 0, angle + rad);
                    go.GetComponent<Rigidbody2D>().velocity = go.transform.up * iceSpeed * Time.deltaTime;
                    count--;
                }
                currentDuring += Time.deltaTime;
                if (count <= 0)
                {
                    isFire = true;
                }
            }
            else
            {
                if (currentRecoverTime < recoverTime)
                {
                    currentRecoverTime += Time.deltaTime;
                }
                else
                {
                    return State.SUCESSED; ;
                }
            }
        }
        return State.RUNNING;
    }
}
