using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom_FireSlimeScene : MonoBehaviour {
    public GameObject fireSlimeBossBody;

    public GameObject inDoor;

    public Sprite openDoorSprite;
    public Sprite closeDoorSprite;

    public GameObject shield;//被动的护盾

    public GameObject fireBall;//技能一的火球

    public GameObject moltenLava;//残留的熔浆

    public GameObject theEjectedMagma;//喷出来的熔浆

    public GameObject target;

    public GameObject fusedLaserBall;

    public float dx;
    public float dy;

    public float startTime;
    private float currentStartTime = 0;
    private bool Running = false;
    private bool isStart;
    public bool GetStart()
    {
        return isStart;
    }
    public void SetStart(bool isStart)
    {
        this.isStart = isStart;
    }
    private bool isEnd;
    private FireSlimeBoss fireSlimeBoss;
    // Use this for initialization
    void Start()
    {
        fireSlimeBoss = new FireSlimeBoss(fireSlimeBossBody, new FireSlimeBossAI(), new FireSlimeBossAtrr(500, 10, 300, 1, 15, new FireSlimeBossAtrrStrategy()));
        fireSlimeBoss.SetFireBall(fireBall);
        fireSlimeBoss.SetShield(shield);
        fireSlimeBoss.SetMoltenLava(moltenLava);
        fireSlimeBoss.SetTheEjectedMagma(theEjectedMagma);
        fireSlimeBoss.target = target;
        fireSlimeBoss.fusedLaserBall = fusedLaserBall;

        isStart = false;
        isEnd = false;
        currentStartTime = 0;
        Running = false;

        inDoor.SetActive(true);
        inDoor.GetComponent<SpriteRenderer>().sprite = closeDoorSprite;

        inDoor.GetComponent<SpriteRenderer>().sprite = closeDoorSprite;
        inDoor.GetComponent<BossRoomInDoor_FireSlimeBoss>().SetRoom(this);

    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            FireSlimeGameLoop._instance.SetOver(true);
            return;
        }

        if (fireSlimeBoss.GetGameObject() == null)
        {
            isEnd = true;
            return;
        }
        DoorsUpdate();

        if (isStart)
        {
            if (currentStartTime < startTime)
            {
                currentStartTime += Time.deltaTime;
                GameObject.Find("CM vcam1").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = fireSlimeBossBody.transform;
            }
            else
            {
                GameObject.Find("CM vcam1").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = GameObject.Find("Player").transform;
                Running = true;
            }
        }
        if (Running)
        {
            fireSlimeBoss.Update();
            fireSlimeBossBody.GetComponent<SkillUnit>().SetStart(true);
        }
    }

    void DoorsUpdate()
    {
        if (isEnd)
        {
            inDoor.GetComponent<SpriteRenderer>().sprite = openDoorSprite;
            inDoor.tag = "Untagged";
        }
    }
}
