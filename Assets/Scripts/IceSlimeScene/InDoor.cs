﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDoor : MonoBehaviour
{
    public Sprite CloseDoorSprite;
    public Sprite OpenDoorSprite;
    private Room1 room;
    public void SetRoom(Room1 room)
    {
        this.room = room;
    }
    public Room1 GetRoom()
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
