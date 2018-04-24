using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBullet : MonoBehaviour {
    private IWeapon OwnerWeapon;
    public float bulletSpeed;
    public float lastTime;
    void Start()
    {
        if (GetWeapon() == null) Debug.Log("11");
        GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(transform.up);
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * bulletSpeed;
        Destroy(gameObject, lastTime);
    }

    public void SetWeapon(IWeapon Weapon)
    {
        OwnerWeapon = Weapon;
    }

    public IWeapon GetWeapon()
    {
        return OwnerWeapon;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            Destroy(gameObject);
        }

        FireSlimeBody fireSlimeBody = collider.GetComponent<FireSlimeBody>();
        FireSlime1Body fireSlime1Body = collider.GetComponent<FireSlime1Body>();
        FireSlime2Body fireSlime2Body = collider.GetComponent<FireSlime2Body>();
        FSlimeBossBody fSlimeBossBody = collider.GetComponent<FSlimeBossBody>();

        if (fireSlimeBody != null || fireSlime2Body != null || fireSlime1Body != null || fSlimeBossBody != null)
        {
            Destroy(gameObject);
        }

        IceSlimeBody iceSlimeBody = collider.GetComponent<IceSlimeBody>();
        IceSlime1Body iceSlime1Body = collider.GetComponent<IceSlime1Body>();
        IceSlime2Body iceSlime2Body = collider.GetComponent<IceSlime2Body>();
        IceSlimeBossBody iceSlimeBossBody = collider.GetComponent<IceSlimeBossBody>();
        if (iceSlimeBody!=null||iceSlime1Body!=null||iceSlime2Body!=null||iceSlimeBossBody!=null)
        {
            Destroy(gameObject);
        }
    }
}
