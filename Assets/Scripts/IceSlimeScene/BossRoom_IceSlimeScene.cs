using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom_IceSlimeScene : MonoBehaviour
{
    public GameObject inDoor;

    public Sprite openDoorSprite;
    public Sprite closeDoorSprite;

    public GameObject iceSlimeBossBody;

    public GameObject ice;//冰锥

    public GameObject iceBlock;//冰块

    public GameObject shield;//护盾

    public GameObject iceBullet;//冰霜弹

    public GameObject iceBulletSkill2;
    public GameObject IceBulletSkill3;
    public GameObject iceBulletSkill4;

    public float startTime;
    private float currentStartTime = 0;

    public float dx;
    public float dy;

    private bool isStart;
    public bool GetStart()
    {
        return isStart;
    }
    public void SetStart(bool isStart)
    {
        this.isStart = isStart;
    }

    private bool Running = false;
    private bool isEnd;
    private IceSlimeBoss iceSlimeBoss;
    // Use this for initialization
    void Start()
    {
        iceSlimeBoss = new IceSlimeBoss(iceSlimeBossBody, new IceSlimeBossAI(), new IceSlimeBossAttr(500, 10, 300, 1, 15, new IceSlimeBossAttrStrategy()));
        iceSlimeBoss.SetIce(ice);
        iceSlimeBoss.SetShield(shield);
        iceSlimeBoss.SetIceBlock(iceBlock);
        iceSlimeBoss.SetIceBullet(iceBullet);
        iceSlimeBoss.IceBulletSkill2 = iceBulletSkill2;
        iceSlimeBoss.IceBulletSkill3 = IceBulletSkill3;
        iceSlimeBoss.IceBulletSkill4 = iceBulletSkill4;

        isStart = false;
        isEnd = false;
        Running = false;

        currentStartTime = 0;

        inDoor.SetActive(true);
        inDoor.GetComponent<SpriteRenderer>().sprite = closeDoorSprite;

        inDoor.GetComponent<SpriteRenderer>().sprite = closeDoorSprite;
        inDoor.GetComponent<BossRoomInDoor_IceSlimeBoss>().SetRoom(this);

    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            IceSlimeGameLoop._instance.SetOver(true);
            return;
        }

        if (iceSlimeBoss.GetGameObject() == null)
        {
            Debug.Log("图");
            isEnd = true;
            return;
        }
        DoorsUpdate();

        if (isStart)
        {
            if (currentStartTime < startTime)
            {
                currentStartTime += Time.deltaTime;
                GameObject.Find("CM vcam1").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = iceSlimeBossBody.transform;
            }
            else
            {
                GameObject.Find("CM vcam1").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = GameObject.Find("Player").transform;
                Running = true;
            }
        }
        if (Running)
        {
            iceSlimeBoss.Update();
            iceSlimeBossBody.GetComponent<SkillUnit>().SetStart(true);
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
