using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class Room1 : MonoBehaviour
{

    public GameObject ice;//iceSlime的冰锥
    public GameObject iceBullet;//iceSlime1的冰霜弹
    public GameObject iceLaser;//iceSlime2的冰霜光束

    public GameObject inDoor;
    public GameObject outDoor;

    public Sprite CloseDoorSprite;
    public Sprite OpenDoorSprite;

    public int max_X;
    public int max_Y;

    public GameObject target;

    public List<GameObject> iceSlimeBody;
 
    public List<GameObject> iceSlime1Body;

    public List<GameObject> iceSlime2Body;

    public List<Transform> spawnPostions;

    private List<ICharacter> remainEnemys = new List<ICharacter>();
    private List<ICharacter> exitEnemys = new List<ICharacter>();
    private List<GameObject> targets = new List<GameObject>();

    private bool isStart = false;
    public void SetStart(bool isStart)
    {
        this.isStart = isStart;
    }
    public bool GetStart()
    {
        return isStart;
    }
    private bool isEnd = false;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < iceSlimeBody.Count; i++)
        {
            IceSlime iceSlime = new IceSlime(iceSlimeBody[i], new IceSlimeAI(), new IceSlimeAttr(30, 5, 300, 1, 25f, new IceSlimeAttrStrategy()), ice);
            iceSlimeBody[i].SetActive(false);
            remainEnemys.Add(iceSlime);
        }

        for (int i = 0; i < iceSlime1Body.Count; i++)
        {
            IceSlime1 iceSlime1 = new IceSlime1(iceSlime1Body[i], new IceSlime1AI(), new IceSlime1Attr(30, 5, 300, 1, 8f, 8f, new IceSlime1AttrStrategy()), iceBullet);
            remainEnemys.Add(iceSlime1);
            iceSlime1Body[i].SetActive(false);
        }

        for (int i = 0; i < iceSlime2Body.Count; i++)
        {
            IceSlime2 iceSlime2 = new IceSlime2(iceSlime2Body[i], new IceSlime2AI(), new IceSlime2Attr(30, 5, 300, 1, 20, new IceSlime2AttrStrategy()), iceLaser);
            remainEnemys.Add(iceSlime2);
            iceSlime2Body[i].SetActive(false);
        }
        InitEnemys();

        inDoor.SetActive(true);
        inDoor.GetComponent<SpriteRenderer>().sprite = CloseDoorSprite;
        inDoor.GetComponent<InDoor>().SetRoom(this);
        outDoor.SetActive(true);
        outDoor.GetComponent<SpriteRenderer>().sprite = CloseDoorSprite;
        outDoor.tag = "Wall";
        outDoor.layer = LayerMask.NameToLayer("Wall");

        for (int i = 0; i < prePos.Length; i++)
        {
            prePos[i] = -1;
        }

        for (int i = 0; i < spawnPostions.Count; i++)
        {
            GameObject iTarget = Instantiate(target, spawnPostions[i].transform.position, Quaternion.identity);
            targets.Add(iTarget);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            inDoor.GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
            inDoor.tag = "Untagged";
            inDoor.layer = 0;
            outDoor.GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
            outDoor.tag = "Untagged";
            outDoor.layer = 0;
        }
        if (isStart)
        {
            EnemysUpdate();
        }
    }

    private int count = 3;
    void EnemysUpdate()
    {
        if (remainEnemys.Count == 0 && exitEnemys.Count == 0)
        {
            isEnd = true;
            return;
        }

        if (exitEnemys.Count <=1 )
        {
            if (remainEnemys.Count > count)
            {
                for (int i = 0; i < count; i++)
                {
                    int d = Random.Range(0, remainEnemys.Count);
                    exitEnemys.Add(remainEnemys[d]);
                    remainEnemys[d].GetGameObject().SetActive(true);
                    remainEnemys[d].GetGameObject().transform.position = SetprePos();
                    remainEnemys.Remove(remainEnemys[d]);
                }
            }
            else
            {
                for (int i = 0; i < remainEnemys.Count; i++)
                {
                    exitEnemys.Add(remainEnemys[i]);
                    remainEnemys[i].GetGameObject().SetActive(true);
                    remainEnemys[i].GetGameObject().transform.position = SetprePos();
                    remainEnemys.Remove(remainEnemys[i]);
                }
            }
        }
        for (int i = 0; i < exitEnemys.Count; i++)
        {
            if (exitEnemys[i].GetGameObject() == null)
            {
                exitEnemys.Remove(exitEnemys[i]);
            }
            else
            {
                exitEnemys[i].Update();
            }
        }
    }

    public int orignCount;
    void InitEnemys()
    {
        for (int i = 0; i < orignCount; i++)
        {
            int d = Random.Range(0, remainEnemys.Count);
            exitEnemys.Add(remainEnemys[d]);
            remainEnemys[d].GetGameObject().SetActive(true);
            remainEnemys[d].GetGameObject().transform.position = SetprePos();
            remainEnemys.Remove(remainEnemys[d]);
        }
    }

    private int[] prePos = new int[4];
    private int prePosCount = 0;
    Vector3 SetprePos()
    {
        int i = Random.Range(0, spawnPostions.Count);
        bool isRepeat = false;
        for (int d = 0; d < prePosCount; d++)
        {
            if (prePos[d] == i)
            {
                isRepeat = true;
                break;
            }
        }
        while (isRepeat)
        {
            i = Random.Range(0, spawnPostions.Count);
            int d = 0;
            for (; d < prePosCount; d++)
            {
                if (prePos[d] == i)
                {
                    isRepeat = true;
                    break;
                }
            }
            if (d == prePosCount)
            {
                isRepeat = false;
            }
        }

        if (prePosCount >= prePos.Length)
        {
            for (int x = 1; x < prePos.Length; x++)
            {
                prePos[x - 1] = prePos[x];
            }
            prePos[prePos.Length - 1] = i;
        }
        else
        {
            prePos[prePosCount] = i;
        }
        return spawnPostions[i].position;
    }
}
