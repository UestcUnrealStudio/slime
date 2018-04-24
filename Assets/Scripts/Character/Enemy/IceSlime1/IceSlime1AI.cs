using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class IceSlime1AI : CharacterAI {
    #region 所有状态
    private DistanceCondition_IceSlime1 distanceCondition;
    public void SetDistanceCondition(DistanceCondition_IceSlime1 distanceCondition)
    {
        this.distanceCondition = distanceCondition;
    }
    public DistanceCondition_IceSlime1 GetDistanceCondition()
    {
        return distanceCondition;
    }

    private ConditionHavaEnemy_IceSlime1 conditionHavaEnemy;
    public void SetConditionHaveEnemy(ConditionHavaEnemy_IceSlime1 conditionHavaEnemy)
    {
        this.conditionHavaEnemy = conditionHavaEnemy;
    }
    public ConditionHavaEnemy_IceSlime1 GetConditionHavaEnemy()
    {
        return conditionHavaEnemy;
    }

    private AttackState_IceSlime1 attackState;//攻击状态
    public void SetAttackState(AttackState_IceSlime1 attackState)
    {
        this.attackState = attackState;
    }
    public AttackState_IceSlime1 GetAttackState()
    {
        return attackState;
    }

    private LaunchIceBulletState_IceSlime1 launchIceBulletState;//发射冰霜弹
    public void SetLaunchIceBulletState(LaunchIceBulletState_IceSlime1 launchIceBulletState)
    {
        this.launchIceBulletState = launchIceBulletState;
    }
    public LaunchIceBulletState_IceSlime1 GetLaunchIceBulletState()
    {
        return launchIceBulletState;
    }

    private LaunchIceBullet_IceSlime1 launchIceBullet;
    public void SetlaunchIceBullet(LaunchIceBullet_IceSlime1 launchIceBullet)
    {
        this.launchIceBullet = launchIceBullet;
    }
    public LaunchIceBullet_IceSlime1 GetLaunchIceBullet()
    {
        return launchIceBullet;
    }

    private MoveState_IceSlime1 moveState;//移动状态
    public void SetMoveState(MoveState_IceSlime1 moveState)
    {
        this.moveState = moveState;
    }    
    public MoveState_IceSlime1 GetMoveState()
    {
        return moveState;
    }

    private MoveToEnemyState_IceSlime1 moveToEnemyState;//移动向敌人方向
    public void SetMoveToEnemyState(MoveToEnemyState_IceSlime1 moveToEnemyState)
    {
        this.moveToEnemyState = moveToEnemyState;
    }
    public MoveToEnemyState_IceSlime1 GetMoveToEnemyState()
    {
        return moveToEnemyState;
    }

    private MoveToEnemy_IceSlime1 moveToEnemy;
    public void SetMoveToEnemy(MoveToEnemy_IceSlime1 moveToEnemy)
    {
        this.moveToEnemy = moveToEnemy;
    }
    public MoveToEnemy_IceSlime1 GetMoveToEnemy()
    {
        return moveToEnemy;
    }

    #endregion

    private Selector root_Node;

    public IceSlime1AI() : base()
    {
        SetAttackState(new AttackState_IceSlime1());
        attackState.SetCharacterAI(this);
        SetLaunchIceBulletState(new LaunchIceBulletState_IceSlime1());
        launchIceBulletState.SetCharacterAI(this);
        SetMoveState(new MoveState_IceSlime1());
        moveState.SetCharacterAI(this);
        SetMoveToEnemyState(new MoveToEnemyState_IceSlime1());
        moveToEnemyState.SetCharacterAI(this);
        SetMoveToEnemy(new MoveToEnemy_IceSlime1());
        moveToEnemy.SetCharacterAI(this);
        SetlaunchIceBullet(new LaunchIceBullet_IceSlime1());
        launchIceBullet.SetCharacterAI(this);
        SetConditionHaveEnemy(new ConditionHavaEnemy_IceSlime1());
        conditionHavaEnemy.SetCharacterAI(this);
        SetDistanceCondition(new DistanceCondition_IceSlime1());
        distanceCondition.SetCharacterAI(this);
        root_Node = new Selector();
        root_Node.AddChild(attackState);
        root_Node.AddChild(moveState);
        root_Node.currentState = State.NONE;
    }

    public override void UpdateAI()
    {
        if (getCharacter().GetGameObject() == null)
        {
            Debug.Log("NULL");
        }
        root_Node.Tick();
    }
}
