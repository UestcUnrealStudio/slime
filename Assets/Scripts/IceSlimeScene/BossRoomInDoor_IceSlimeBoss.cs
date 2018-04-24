using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomInDoor_IceSlimeBoss : MonoBehaviour {

    public Sprite CloseDoorSprite;
    public Sprite OpenDoorSprite;
    private BossRoom_IceSlimeScene room;
    public void SetRoom(BossRoom_IceSlimeScene room)
    {
        this.room = room;
    }
    public BossRoom_IceSlimeScene GetRoom()
    {
        return room;
    }

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = CloseDoorSprite;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !room.GetStart())
        {
            GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !room.GetStart())
        {
            Vector2 dir = (collider.transform.position - transform.position).normalized;
            if (dir.y > 0)
            {
                GetComponent<SpriteRenderer>().sprite = CloseDoorSprite;
                gameObject.tag = "Wall";
                gameObject.layer = LayerMask.NameToLayer("Wall");
                room.SetStart(true);
            }
        }
    }
}
