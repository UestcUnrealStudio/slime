using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class Gun : IWeapon
{
    private IBullet bullet;

    //是否需要装弹
    private bool isNeedReload = false;
    public void SetReloading(bool NeedReload)
    {
        isNeedReload = NeedReload;
    }

    private int maxBullet;//最大子弹数
    public void SetMaxBullet(int maxBullet)
    {
        this.maxBullet = maxBullet;
    }
    public int GetMaxBullet()
    {
        return maxBullet;
    }
    private int remainBullet;//剩余子弹数
    public void SetRemianBullet(int remainBullet)
    {
        this.remainBullet = remainBullet;
    }
    public int GetRemainBullet()
    {
        return remainBullet;
    }
    private float reLoadingTime;
    public void SetReLoadingTime(float reLoadingTime)
    {
        this.reLoadingTime = reLoadingTime;
    }
    public float GetReloadingTime()
    {
        return reLoadingTime;
    }

    private float currentTime;
    public float GetCurrentTime()
    {
        return currentTime;
    }
    public void SetCurrentTime(float currentTime)
    {
        this.currentTime = currentTime;
    }

    public Gun(float attack, float fireRate, float fireRange,IBullet bullet) : base(attack, fireRate, fireRange)
    {
        currentTime = fireRate;
        SetBullet(bullet);
        SetRemianBullet(maxBullet);
        SetReLoadingTime(0.5f);
    }

    public void SetBullet(IBullet bullet)
    {
        this.bullet = bullet;
        bullet.SetWeapon(this);
    }
    public IBullet GetBullet()
    {
        return bullet;
    }

    //攻击
    public override void Attack()
    {
        if (isNeedReload == true)
        {
            if (remainBullet > 0)
            {
                isNeedReload = false;
            }
            return;
        }

        if (currentTime >= fireRate)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x, mousePos.y, 0);
            float angle = Vector3.Angle(Vector3.up, (mousePos - GetOwner().transform.position).normalized); //求出两向量之间的夹角  
            Vector3 normal = Vector3.Cross(Vector3.up, (mousePos - GetOwner().transform.position).normalized);//叉乘求出法线向量  
            angle *= Vector3.Dot(normal.normalized, Vector3.forward.normalized);//求法线向量与物体上方向向量点乘，结果为1或-1，修正旋转方向

            float randomAngle = Random.Range(-10, 10);
            GameObject b = GameObject.Instantiate(bullet.gameObject, GetOwner().transform.position, Quaternion.identity);
            b.transform.rotation = Quaternion.Euler(new Vector3(b.transform.rotation.x, b.transform.rotation.y, angle + randomAngle));
            b.GetComponent<IBullet>().SetWeapon(this);

            remainBullet--;
            if (remainBullet <= 0)
            {
                isNeedReload = true;
            }
            currentTime = 0;
        }
    }
}
