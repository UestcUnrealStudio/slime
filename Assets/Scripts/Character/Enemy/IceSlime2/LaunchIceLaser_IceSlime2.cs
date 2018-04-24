using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class LaunchIceLaser_IceSlime2 : IState {

    private float attackRate;

    private GameObject iceLaser;//冰霜激光

    private float iceLaserExpandSpeed = 400;//冰霜激光的速度

    private float recoverTime = 0.5f;

    private GameObject iIceLaser;
    public override void Enter()
    {
        base.Enter();
        IceSlime2AI iceSlime2AI = (IceSlime2AI)GetAI();
        IceSlime2 iceSlime2 = (IceSlime2)iceSlime2AI.getCharacter();
        GameObject myBody = iceSlime2.GetGameObject();
        attackRate = iceSlime2.getAttr().getAttackRate();
        iceLaser = iceSlime2.GetIceLaser();
        currentRecoverTime = 0;
        currentAttackRate = 0;
        LineRenderer lineRenderer = myBody.GetComponent<LineRenderer>();
        Vector3 startPos = Vector3.zero;
        Vector3 endPos = Vector3.zero;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    public override void Exit()
    {
        base.Exit();
    }
    private float currentRecoverTime = 0;
    private float currentAttackRate = 0;
    private bool isFire = false;
    public override State Update()
    {
        IceSlime2AI iceSlime2AI = (IceSlime2AI)GetAI();
        IceSlime2 iceSlime2 = (IceSlime2)iceSlime2AI.getCharacter();
        GameObject myBody = iceSlime2.GetGameObject();
        LineRenderer lineRenderer = myBody.GetComponent<LineRenderer>();
        Vector3 startPos = Vector3.zero;
        Vector3 endPos = Vector3.zero;
        if (currentAttackRate < attackRate)
        {
            //准备发射
            currentAttackRate += Time.deltaTime;
            startPos = myBody.transform.position;
            endPos = iceSlime2.currentTarget.transform.position;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, endPos);
            isFire = false;
        }
        else
        {
            startPos = Vector3.zero;
            endPos = Vector3.zero;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, endPos);
            if (!isFire)
            {
                //发射
                iIceLaser = Object.Instantiate(iceLaser, myBody.transform.position, Quaternion.identity);
                iIceLaser.GetComponent<IceLaser>().SetOwner(iceSlime2);
                float angle = Vector3.Angle(myBody.transform.up, (iceSlime2.currentTarget.transform.position - myBody.transform.position).normalized);
                Vector3 cro = Vector3.Cross(myBody.transform.up, (iceSlime2.currentTarget.transform.position - myBody.transform.position).normalized);
                float dot = Vector3.Dot(cro.normalized, myBody.transform.forward);
                angle *= dot;
                iIceLaser.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                iIceLaser.GetComponent<Rigidbody2D>().velocity = iIceLaser.transform.up * iceLaserExpandSpeed * Time.deltaTime;
                isFire = true;
            }
            else
            {
                if (iIceLaser.gameObject == null)
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
        }
        return State.RUNNING;
    }
}
