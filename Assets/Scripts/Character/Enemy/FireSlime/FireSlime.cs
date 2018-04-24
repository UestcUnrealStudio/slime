using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class FireSlime : ICharacter
{
    private GameObject fusedLaser;
    public void SetFusedLaser(GameObject fusedLaser)
    {
        this.fusedLaser = fusedLaser;
    }
    public GameObject GetFusedLaser()
    {
        return fusedLaser;
    }

    public Collider2D[] targets;//所有可以攻击的目标
    public Collider2D currentTarget;//当前追逐或者攻击的目标

    public FireSlime(GameObject myBody, CharacterAI AI, ICharacterAttr attr,GameObject fusedLaser) : base(myBody, AI, attr)
    {
        SetFusedLaser(fusedLaser);
        if (myBody.GetComponent<FireSlimeBody>() == null)
        {
            Debug.Log("实例为空" + myBody.name);
        }
        myBody.GetComponent<FireSlimeBody>().SetCharacter(this);
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

    public override void UnderAttack(Player player)
    {
        base.UnderAttack(player);
    }

}
