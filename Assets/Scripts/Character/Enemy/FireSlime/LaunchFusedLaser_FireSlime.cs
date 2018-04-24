using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class LaunchFusedLaser_FireSlime : IState {

    private float attackRange;
    private float attackRate;
    private float recovetTime = 0.5f;
    private float fuseLaserSpeed = 300;

    private GameObject fusedLaser;

   public LaunchFusedLaser_FireSlime()
    {
        currentState = State.NONE;
    }

    public override void Enter()
    {
        FireSlimeAI fireSlimeAI = (FireSlimeAI)GetAI();
        FireSlime fireSlime = (FireSlime)fireSlimeAI.getCharacter();
        GameObject myBody = fireSlime.GetGameObject();

        attackRange = fireSlime.getAttr().getAttackRange();
        attackRate = fireSlime.getAttr().getAttackRate();
        fusedLaser = fireSlime.GetFusedLaser();
        currentAttackRate = 0;
        currentRecoverTime = 0;
        currentDuring = fireDuring;
        count = 3;
        isFire = false;
    }

    private float currentAttackRate=0;
    private float currentRecoverTime = 0;
    private bool isFire = false;

    private float fireDuring = 0.2f;
    private float currentDuring;
    private int count = 3;
    public override State Update()
    {
        FireSlimeAI fireSlimeAI = (FireSlimeAI)GetAI();
        FireSlime fireSlime = (FireSlime)fireSlimeAI.getCharacter();
        GameObject myBody = fireSlime.GetGameObject();
        if (currentAttackRate < attackRate)
        { 
            currentAttackRate += Time.deltaTime;
        }
        else
        {
            if (!isFire)
            {
                float angle = Vector3.Angle(myBody.GetComponent<FireSlimeBody>().FirePostion.up, (fireSlime.currentTarget.transform.position - myBody.GetComponent<FireSlimeBody>().FirePostion.position).normalized);
                Vector3 cross = Vector3.Cross(myBody.GetComponent<FireSlimeBody>().FirePostion.up, (fireSlime.currentTarget.transform.position - myBody.GetComponent<FireSlimeBody>().FirePostion.position).normalized);
                angle *= Vector3.Dot(myBody.GetComponent<FireSlimeBody>().FirePostion.forward, cross.normalized);
                if (currentDuring >= fireDuring)
                {
                    GameObject iFusedLaser = Object.Instantiate(fusedLaser, myBody.GetComponent<FireSlimeBody>().FirePostion.position, Quaternion.identity);
                    iFusedLaser.transform.localRotation *= Quaternion.Euler(0, 0, angle);
                    iFusedLaser.GetComponent<Rigidbody2D>().velocity = iFusedLaser.transform.up * fuseLaserSpeed * Time.deltaTime;
                    count--;
                    currentDuring = 0;
                }
                currentDuring += Time.deltaTime;
                if (count <= 0)
                {
                    isFire = true;
                }
            }
            else
            {
                if (currentRecoverTime < recovetTime)
                {
                    currentRecoverTime += Time.deltaTime;
                }
                else
                {
                    currentRecoverTime = 0;

                    return State.SUCESSED;
                }
            }
        }
        return State.RUNNING;
    }
}
