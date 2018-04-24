using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour {
    private IceSlime1 owner;
    public void SetOwner(IceSlime1 owner)
    {
        this.owner = owner;
    }
    public IceSlime1 GetOwner()
    {
        return owner;
    }

    private int attack = 1;
    public void SetAttack(int attack)
    {
        this.attack = attack;
    }
    public int GetAttack()
    {
        return attack;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        string colliderLayer = LayerMask.LayerToName(collider.gameObject.layer);
        if (colliderLayer == "Player" || colliderLayer == "Obstacle" || colliderLayer == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
