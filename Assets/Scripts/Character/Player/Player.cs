using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private IWeapon myWeapon;
    public void SetWeapon(IWeapon weapon)
    {
        myWeapon = weapon;
        myWeapon.SetOwner(this);
    }
    public IWeapon GetWeapon()
    {
        return myWeapon;
    }

    private int health;
    public void SetHealth(int health)
    {
        this.health = health;
    }
    public int GetHealth()
    {
        return health;
    }

    //是否已死亡
    public bool isDead = false;
    public float Speed;

    private bool beAttacked = false;

    public int maxHealth;

    //枪的属性
    public float gunAttack;
    public float gunFireRate;
    public float gunFireRange;
    public IBullet bullet;

    //剑的属性
    public float swordAttack;
    public float swordFireRate;
    public float swordFireRange;

    //自身UI
    public Slider reloadSlider = null;
    public List<RawImage> remainBulletImage = null;

    //武器
    Sword sword;
    Gun gun;
    // Use this for initialization
    void Awake()
    {
        sword = new Sword(swordAttack, swordFireRate, swordFireRange);
        gun = new Gun(gunAttack, gunFireRate, gunFireRange, bullet);
        SetWeapon(gun);
        myWeapon.SetOwner(this);
        gun.SetMaxBullet(remainBulletImage.Count);
        FullHP();
        isDead = false;
    }

    void Start()
    {
        isDead = false;
    }

    //血量调节
    //补满血
    void FullHP()
    {
        health = maxHealth;
    }
    //改变血量
    public void ChangeHP(int changeValue)
    {
        health += changeValue;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            isDead = true;
        }
    }
    //按键输入
    void InputProgress()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(h, v).normalized * Speed * Time.deltaTime;
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
       /*if (Input.GetAxis("Mouse ScrollWheel") >= 0.2f || Input.GetAxis("Mouse ScrollWheel") <= -0.2f)
        {
            ChangeWeapon();
        }*/
        if (Input.GetButton("Attack"))
        {
            Attack();
        }
        if (Input.GetButtonDown("Reloading")&&GetWeapon() is Gun)
        {
            if (gun.GetRemainBullet() == gun.GetMaxBullet())
            {
                return;
            }
            gun.SetReloading(true);
            gun.SetRemianBullet(0);
        }

        
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        InputProgress();
        UpdateSelfUI();
        BeAttackedState();

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //如果武器是枪
        if (GetWeapon() is Gun)
        {
            gun.SetCurrentTime(gun.GetCurrentTime() + Time.deltaTime);
        }

       /* float angle = Vector2.Angle(transform.right, GetComponent<Rigidbody2D>().velocity);
        Vector3 cross = Vector3.Cross(transform.right, GetComponent<Rigidbody2D>().velocity);
        float dot = Vector3.Dot(transform.forward, cross.normalized);
       
        angle *= dot;
        Debug.Log(transform.forward + " " + cross.normalized + " " + dot + " " + angle);
        float radians = Mathf.PI / 180 * angle;
        Debug.Log(Mathf.Cos(radians));*/
        RaycastHit2D raycastHit2D = Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y) + GetComponent<Rigidbody2D>().velocity.normalized, LayerMask.GetMask("Wall"));
        Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + GetComponent<Rigidbody2D>().velocity.normalized);
        if (raycastHit2D.collider != null)
        {
            Debug.Log("撞墙");
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if ((mousePos - transform.position).x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if ((mousePos - transform.position).x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }


    //自身UI的更新
    private float currentReloadingTime = 0;
  
    void UpdateSelfUI()
    {
        if (GetWeapon() is Gun)
        {
            //子弹数的更新
            if (gun.GetRemainBullet() > 0)
            {
                reloadSlider.gameObject.SetActive(false);
                for (int i = remainBulletImage.Count - 1; i >= 0; i--)
                {
                    if (i < gun.GetRemainBullet())
                    {
                        remainBulletImage[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        remainBulletImage[i].gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                for (int i = remainBulletImage.Count - 1; i >= 0; i--)
                {
                    remainBulletImage[i].gameObject.SetActive(false);
                }
                if (currentReloadingTime > gun.GetReloadingTime())
                {
                    gun.SetRemianBullet(gun.GetMaxBullet());
                    currentReloadingTime = 0;
                    reloadSlider.gameObject.SetActive(false);
                }
                else
                {
                    reloadSlider.gameObject.SetActive(true);
                    currentReloadingTime += Time.deltaTime;
                    reloadSlider.value = currentReloadingTime / gun.GetReloadingTime();
                }
            }
        }
        else if (GetWeapon() is Sword)
        {
            for (int i = 0; i < remainBulletImage.Count; i++)
            {
                remainBulletImage[i].gameObject.SetActive(false);
            }
            reloadSlider.gameObject.SetActive(false);
        }
    }

    //武器
    

    //攻击
    public void Attack()
    {
        myWeapon.Attack();
    }

   //被攻击闪烁效果
    public float spashTime;
    private float curretnSpashTime = 0;
    public float count;
    private float currentCount = 0;
    private void BeAttackedState()
    {
        if (beAttacked)
        {
            Color color = GetComponent<SpriteRenderer>().color;
            if (spashTime > curretnSpashTime)
            {
                curretnSpashTime += Time.deltaTime;
                currentCount += Time.deltaTime;
                if (currentCount > count)
                {
                    if (GetComponent<SpriteRenderer>().color.a == 0)
                    {
                        GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1);
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0);
                    }
                    currentCount = 0;
                }
                GetComponent<PolygonCollider2D>().enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1);
                GetComponent<PolygonCollider2D>().enabled = true;
                currentCount = 0;
                curretnSpashTime = 0;
                beAttacked = false;
            }
        }
    }

    //被攻击
    public void UnderAttack(int damage)
    {
        ChangeHP(-damage);
        beAttacked = true;
    }

    //切换武器
    public void ChangeWeapon()
    {
        if (myWeapon is Gun)
        {
            SetWeapon(sword);
            Debug.Log("切换为剑");
        }
        else if (myWeapon is Sword)
        {
            SetWeapon(gun);
            Debug.Log("切换为枪");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "FireSlimeBoss")
        {
            if (collider.GetComponent<FusedLaser>()!=null)
            {
                FusedLaser fusedLaser = collider.GetComponent<FusedLaser>();
                UnderAttack(fusedLaser.attack);
            }
            else if (collider.GetComponent<MoltenLava_FireSlime1>() !=null)
            {
                MoltenLava_FireSlime1 moltenLava = collider.GetComponent<MoltenLava_FireSlime1>();
                UnderAttack(moltenLava.attack);
            }
            else if (collider.GetComponent<MoltenLava_FireSlimeBoss>() != null)
            {
                MoltenLava_FireSlimeBoss moltenLava = collider.GetComponent<MoltenLava_FireSlimeBoss>();
                UnderAttack(moltenLava.attack);
            }
            else if (collider.GetComponent<FireBall>() != null)
            {
                FireBall fireBall = collider.GetComponent<FireBall>();
                UnderAttack(fireBall.attack);
            }
            else if (collider.GetComponent<Magma_FireSlimeBoss>() != null)
            {
                Magma_FireSlimeBoss magma = collider.GetComponent<Magma_FireSlimeBoss>();
                UnderAttack(magma.attack);
            }
        }
        else if (scene.name == "IceSlimeBoss")
        {
            if (collider.GetComponent<Ice>() != null)
            {
                Ice ice = collider.GetComponent<Ice>();
                UnderAttack(ice.GetAttack());
            }

            if (collider.GetComponent<IceBullet>() != null)
            {
                IceBullet iceBullet = collider.GetComponent<IceBullet>();
                UnderAttack(iceBullet.GetAttack());
            }

            if (collider.GetComponent<IceLaser>() != null)
            {
                IceLaser iceLaser = collider.GetComponent<IceLaser>();
                UnderAttack(iceLaser.GetAttack());
            }
            if (collider.GetComponent<IceBlock>() != null)
            {
                IceBlock iceBlock = collider.GetComponent<IceBlock>();
                UnderAttack(iceBlock.attack);
            }
            if (collider.GetComponent<IceBullet_IceSlimeBoss>() != null)
            {
                IceBullet_IceSlimeBoss iceBullet = collider.GetComponent<IceBullet_IceSlimeBoss>();
                UnderAttack(iceBullet.attack);
            }
            if (collider.GetComponent<Skill2IceBullet_IceSlimeBoss>() != null)
            {
                UnderAttack(1);
            }
            if (collider.GetComponent<Skill4IceBullet>() != null)
            {
                Skill4IceBullet iceBullet = collider.GetComponent<Skill4IceBullet>();
                UnderAttack(iceBullet.attack);
            }
        }
    }
}
