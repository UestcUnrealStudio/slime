using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class Room1_FireSlimeScene : MonoBehaviour {

    public GameObject fusedLaser;//FireSlime的熔浆激光

    public GameObject meltedBomb;//FireSlime1的熔浆弹

    public GameObject iFire;//FireSlime2的火焰
    public GameObject rushFire;//FireSlime2的冲击火焰

    public GameObject inDoor;
    public GameObject outDoor;

    public GameObject target;

    public Sprite CloseDoorSprite;
    public Sprite OpenDoorSprite;

    public int max_X;
    public int max_Y;

    public List<GameObject> fireSlimeBodies;
   
    public List<GameObject> fireSlime1Bodies;
    
    public List<GameObject> fireSlime2Bodies;

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
        for (int i = 0; i < fireSlimeBodies.Count; i++)
        {
            FireSlime fireSlime = new FireSlime(fireSlimeBodies[i], new FireSlimeAI(), new FireSlimeAttr(30, 5, 300, 0.5f, 8, new FireSlime1AtrrStrategy()), fusedLaser);
            fireSlimeBodies[i].SetActive(false);
            remainEnemys.Add(fireSlime);
        }

        for (int i = 0; i < fireSlime1Bodies.Count; i++)
        {
            FireSlime1 fireSlime1 = new FireSlime1(fireSlime1Bodies[i], new FireSlime1AI(), new FireSlimeAttr(30, 10, 300, 1f, 10, new FireSlime1AtrrStrategy()), meltedBomb);
            remainEnemys.Add(fireSlime1);
            fireSlime1Bodies[i].SetActive(false);
        }

        for (int i = 0; i < fireSlime2Bodies.Count; i++)
        {
            FireSlime2 fireSlime2 = new FireSlime2(fireSlime2Bodies[i], new FireSlime2AI(), new FireSlime2Attr(15, 5, 350, 0.4f, 8, new FireSlime2AttrStrategy()), iFire, rushFire);
            remainEnemys.Add(fireSlime2);
            fireSlime2Bodies[i].SetActive(false);
        }
        //InitEnemys();

        inDoor.SetActive(true);
        inDoor.GetComponent<SpriteRenderer>().sprite = CloseDoorSprite;
       
        inDoor.GetComponent<InDoor_FireSlimeScene>().SetRoom(this);
        outDoor.SetActive(true);
        outDoor.tag = "Wall";
        outDoor.layer = LayerMask.NameToLayer("Wall");
        outDoor.GetComponent<SpriteRenderer>().sprite = CloseDoorSprite;

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

    private float showTime = 1;
    private float currentshowTime = 0;
    void EnemysUpdate()
    {
        if (remainEnemys.Count == 0 && exitEnemys.Count == 0)
        {
            isEnd = true;
            for (int i = 0; i < targets.Count; i++)
            {
                Destroy(targets[i]);
                targets.Remove(targets[i]);
            }
            return;
        }

        if (exitEnemys.Count <= 1)
        {
            if (remainEnemys.Count > count)
            {
                for (int i = 0; i < count;)
                {
                    int d = Random.Range(0, remainEnemys.Count);
                    remainEnemys[d].GetGameObject().transform.position = SetprePos();

                    /* GameObject iTarget = Instantiate(target, remainEnemys[d].GetGameObject().transform.position, Quaternion.identity);
                     if (currentshowTime < showTime)
                     {
                         currentshowTime += Time.deltaTime;

                         continue;
                     }*/

                    remainEnemys[d].GetGameObject().SetActive(true);
                    exitEnemys.Add(remainEnemys[d]);
                    remainEnemys.Remove(remainEnemys[d]);
                    i++;
                }
            }
            else
            {
                for (int i = 0; i < remainEnemys.Count;)
                {
                    remainEnemys[i].GetGameObject().transform.position = SetprePos();
                    /*GameObject iTarget = Instantiate(target, remainEnemys[i].GetGameObject().transform.position, Quaternion.identity);
                    if (currentshowTime < showTime)
                    {
                        currentshowTime += Time.deltaTime;
                        continue;
                    }*/

                    remainEnemys[i].GetGameObject().SetActive(true);
                    exitEnemys.Add(remainEnemys[i]);
                    remainEnemys.Remove(remainEnemys[i]);
                    i++;
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
