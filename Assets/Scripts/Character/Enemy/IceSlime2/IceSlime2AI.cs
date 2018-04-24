using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class IceSlime2AI : CharacterAI
{

    #region 所有状态
    private ConditionHavaEnemy_IceSlime2 conditionHavaEnemy;
    public void SetConditionHaveEnemy(ConditionHavaEnemy_IceSlime2 conditionHavaEnemy)
    {
        this.conditionHavaEnemy = conditionHavaEnemy;
    }
    public ConditionHavaEnemy_IceSlime2 GetConditionHavaEnemy()
    {
        return conditionHavaEnemy;
    }

    private DistanceCondition_IceSlime2 distanceCondition;
    public void SetDistaneCondition(DistanceCondition_IceSlime2 distanceCondition)
    {
        this.distanceCondition = distanceCondition;
    }
    public DistanceCondition_IceSlime2 GetDistanceCondition()
    {
        return distanceCondition;
    }

    private MoveState_IceSlime2 moveState;
    public void SetMoveState(MoveState_IceSlime2 moveState)
    {
        this.moveState = moveState;
    }
    public MoveState_IceSlime2 GetMoveState()
    {
        return moveState;
    }

    private MoveToTheEnemyState_IceSlime2 moveToTheEnemyState;
    public void SetMoveToTheEnemyState(MoveToTheEnemyState_IceSlime2 moveToTheEnemyState)
    {
        this.moveToTheEnemyState = moveToTheEnemyState;
    }
    public MoveToTheEnemyState_IceSlime2 GetMoveToTheEnemyState()
    {
        return moveToTheEnemyState;
    }

    private MoveToTheEnemy_IceSlime2 moveToTheEnemy;
    public void SetMoveToTheEnemy(MoveToTheEnemy_IceSlime2 moveToTheEnemy)
    {
        this.moveToTheEnemy = moveToTheEnemy;
    }
    public MoveToTheEnemy_IceSlime2 GetMoveToTheEnemy()
    {
        return moveToTheEnemy;
    }

    private AttackState_IceSlime2 attackState;
    public void SetAttackState(AttackState_IceSlime2 attackState)
    {
        this.attackState = attackState;
    }
    public AttackState_IceSlime2 GetAttackState()
    {
        return attackState;
    }

    private LaunchIceLaserState_IceSlime2 launchIceLaserState;
    public void SetLaunchIceLaserState(LaunchIceLaserState_IceSlime2 launchIceLaserState)
    {
        this.launchIceLaserState = launchIceLaserState;
    }
    public LaunchIceLaserState_IceSlime2 GetLaunchIceLaserState()
    {
        return launchIceLaserState;
    }

    private LaunchIceLaser_IceSlime2 launchIceLaser;
    public void SetLaunchIceLaser(LaunchIceLaser_IceSlime2 launchIceLaser)
    {
        this.launchIceLaser = launchIceLaser;
    }
    public LaunchIceLaser_IceSlime2 GetLaunchIceLaser()
    {
        return launchIceLaser;
    }

    #endregion
    private Selector root_Node;
    public IceSlime2AI() : base()
    {
        SetMoveState(new MoveState_IceSlime2());
        moveState.SetCharacterAI(this);
        SetMoveToTheEnemyState(new MoveToTheEnemyState_IceSlime2());
        moveToTheEnemyState.SetCharacterAI(this);
        SetAttackState(new AttackState_IceSlime2());
        attackState.SetCharacterAI(this);
        SetLaunchIceLaserState(new LaunchIceLaserState_IceSlime2());
        launchIceLaserState.SetCharacterAI(this);
        SetConditionHaveEnemy(new ConditionHavaEnemy_IceSlime2());
        conditionHavaEnemy.SetCharacterAI(this);
        SetDistaneCondition(new DistanceCondition_IceSlime2());
        distanceCondition.SetCharacterAI(this);
        SetLaunchIceLaser(new LaunchIceLaser_IceSlime2());
        launchIceLaser.SetCharacterAI(this);
        SetMoveToTheEnemy(new MoveToTheEnemy_IceSlime2());
        moveToTheEnemy.SetCharacterAI(this);

        root_Node = new Selector();
        root_Node.AddChild(attackState);
        root_Node.AddChild(moveState);
        root_Node.currentState = State.NONE;

    }
    public override void UpdateAI()
    {
        root_Node.Tick();
    }
}
