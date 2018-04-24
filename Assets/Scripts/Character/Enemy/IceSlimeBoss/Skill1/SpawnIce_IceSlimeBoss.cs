using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class SpawnIce_IceSlimeBoss : IState
{
    private float iceBlockNumber = 5;
    private float iceBlockDistance = 5;
    private float iceBlockSpeed = 300;

    private GameObject iceBlock;
    public override void Enter()
    {
        base.Enter();
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();

        iceBlock = iceSlimeBoss.GetIceBlock();
    }

    public override void Exit()
    {
        base.Exit();
        GetAI().getCharacter().GetGameObject().GetComponent<SkillUnit>().ReSetCurrentSkillTime(0);
    }

    public override State Update()
    {
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();
        GameObject myBody = iceSlimeBoss.GetGameObject();

        for (int i = 0; i < iceBlockNumber; i++)
        {
            GameObject iIceBlock = Object.Instantiate(iceBlock, myBody.transform.position + myBody.transform.up * 3, Quaternion.identity);
            iIceBlock.transform.localRotation = iceBlock.transform.localRotation * Quaternion.Euler(0, 0, i * (360f / iceBlockNumber));
            Vector2 a = myBody.transform.up;
            float angle = 360 / iceBlockNumber;
            Vector3 b = new Vector2(a.x * Mathf.Cos(i * angle) + a.y * Mathf.Sin(i * angle), -a.x * Mathf.Sin(angle) + a.y * Mathf.Cos(angle));
            iIceBlock.transform.position += b * 3;

            iIceBlock.GetComponent<Rigidbody2D>().velocity = iIceBlock.transform.up * iceBlockSpeed * Time.deltaTime;
        }
        return State.SUCESSED;
    }

    void CalPos(Vector3 middlePos, int i, int number)
    {
        float angle = i * (360 / number);
    }
}
