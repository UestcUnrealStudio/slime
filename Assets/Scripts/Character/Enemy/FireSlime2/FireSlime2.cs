using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class FireSlime2 : ICharacter
{
    private GameObject fire;//吐火焰
    public void SetFire(GameObject fire)
    {
        this.fire = fire;
    }
    public GameObject GetFire()
    {
        return fire;
    }

    private GameObject rushFire;//冲击火焰
    public void SetRushFire(GameObject rushFire)
    {
        this.rushFire = rushFire;
    }
    public GameObject GetRushFire()
    {
        return rushFire;
    }

    public Collider2D[] targets;//所有可以攻击的目标
    public Collider2D currentTarget;//当前追逐或者攻击的目标

    public FireSlime2(GameObject myBody, CharacterAI AI, ICharacterAttr attr,GameObject fire,GameObject rushFire) : base(myBody, AI, attr)
    {
        SetFire(fire);
        SetRushFire(rushFire);
        myBody.GetComponent<FireSlime2Body>().SetOwner(this);
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
