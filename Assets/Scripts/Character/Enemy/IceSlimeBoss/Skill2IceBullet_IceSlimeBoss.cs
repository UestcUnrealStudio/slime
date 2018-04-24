using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2IceBullet_IceSlimeBoss : MonoBehaviour {

    public float rotateSpeed;

    public float lifeTime;
    public IceSlimeBoss owner;

    private float currentLifeTime = 0;
    // Update is called once per frame
    void Update()
    {
        if (owner.GetGameObject() == null)
        {
            return;
        }
        if (currentLifeTime < lifeTime)
        {
            transform.RotateAround(owner.GetGameObject().transform.position, owner.GetGameObject().transform.forward, rotateSpeed * Time.deltaTime);
            currentLifeTime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<IBullet>() != null)
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
