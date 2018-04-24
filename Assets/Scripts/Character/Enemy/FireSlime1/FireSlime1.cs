using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class FireSlime1 : ICharacter
{
    private GameObject meltedBomb;//熔浆弹
    public void SetMeltedBomb(GameObject meltedBomb)
    {
        this.meltedBomb = meltedBomb;
    }
    public GameObject GetMeltedBomb()
    {
        return meltedBomb;
    }

    public Collider2D[] targets;//所有可以攻击的目标
    public Collider2D currentTarget;//当前追逐或者攻击的目标

    public FireSlime1(GameObject myBody, CharacterAI AI, ICharacterAttr attr,GameObject meltedBomb) : base(myBody, AI, attr)
    {
        SetMeltedBomb(meltedBomb);
        if (myBody.GetComponent<FireSlime1Body>() == null)
        {
            Debug.Log("实例为空" + myBody.name);
            myBody.GetComponent<FireSlime1Body>().SetOwner(this);
        }
        myBody.GetComponent<FireSlime1Body>().SetOwner(this);
    }

    public override void Update()
    {
        base.Update();
        Room1_FireSlimeScene room = (Room1_FireSlimeScene)GetGameObject().GetComponentInParent(typeof(Room1_FireSlimeScene));
        float dx = GetGameObject().transform.position.x;
        float dy = GetGameObject().transform.position.y;
        if (dx >= room.transform.position.x + room.max_X || dx <= room.transform.position.x - room.max_X)
        {
            GetGameObject().GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetGameObject().GetComponent<Rigidbody2D>().velocity.y);
        }
        if (dy >= room.transform.position.y + room.max_Y || dy <= room.transform.position.y - room.max_Y)
        {
            GetGameObject().GetComponent<Rigidbody2D>().velocity = new Vector2(GetGameObject().GetComponent<Rigidbody2D>().velocity.x, 0);
        }
    }
}
