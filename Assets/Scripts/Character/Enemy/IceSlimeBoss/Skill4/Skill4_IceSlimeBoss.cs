using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class Skill4_IceSlimeBoss : IState {

    private float lastTime = 3;
    private float range = 10;
    private float iceBulletSpeed = 400;

    private GameObject iceBulletSkill4;

    private float recoverTime = 2;

    private List<GameObject> iceBlocks = new List<GameObject>();

    public override void Enter()
    {
        base.Enter();
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();
        GameObject myBody = iceSlimeBoss.GetGameObject();

        iceBulletSkill4 = iceSlimeBoss.IceBulletSkill4;
        currentRecoverTime = 0;
        currentLastTime = 0;
        havaFired = false;
    }

    public override void Exit()
    {
        base.Exit();
        GetAI().getCharacter().GetGameObject().GetComponent<SkillUnit>().ReSetCurrentSkillTime(3);
    }

    private bool havaFired = false;
    private float currentLastTime = 0;
    private float currentRecoverTime = 0;
    public override State Update()
    {
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();
        GameObject myBody = iceSlimeBoss.GetGameObject();

        if (!havaFired)
        {
            List<GameObject> iceBullets = new List<GameObject>();
            GameObject iceBullet = GameObject.Instantiate(iceBulletSkill4, myBody.transform.position + myBody.transform.up, Quaternion.identity);
            GameObject iceBullet1 = GameObject.Instantiate(iceBulletSkill4, myBody.transform.position + myBody.transform.right, Quaternion.identity);
            GameObject iceBullet2 = GameObject.Instantiate(iceBulletSkill4, myBody.transform.position - myBody.transform.up, Quaternion.identity);
            GameObject iceBullet3 = GameObject.Instantiate(iceBulletSkill4, myBody.transform.position - myBody.transform.right, Quaternion.identity);
            iceBullets.Add(iceBullet);
            iceBullets.Add(iceBullet1);
            iceBullets.Add(iceBullet2);
            iceBullets.Add(iceBullet3);

            GameObject iceBullet4 = GameObject.Instantiate(iceBulletSkill4, myBody.transform.position + new Vector3(1, 1).normalized, Quaternion.identity);
            GameObject iceBullet5 = GameObject.Instantiate(iceBulletSkill4, myBody.transform.position + new Vector3(-1, 1).normalized, Quaternion.identity);
            GameObject iceBullet6 = GameObject.Instantiate(iceBulletSkill4, myBody.transform.position + new Vector3(1, -1).normalized, Quaternion.identity);
            GameObject iceBullet7 = GameObject.Instantiate(iceBulletSkill4, myBody.transform.position + new Vector3(-1, -1).normalized, Quaternion.identity);
            iceBullets.Add(iceBullet4);
            iceBullets.Add(iceBullet5);
            iceBullets.Add(iceBullet6);
            iceBullets.Add(iceBullet7);

            Vector2 dir;
            for (int i = 0; i < iceBullets.Count; i++)
            {
                dir = (myBody.transform.position - iceBullets[i].transform.position).normalized;
                iceBullets[i].GetComponent<Rigidbody2D>().velocity = dir * iceBulletSpeed * Time.deltaTime;
                Debug.Log(iceBullets[i].GetComponent<Rigidbody2D>().velocity + " " + i);
            }
            havaFired = true;
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
        return State.RUNNING;
    }
}
