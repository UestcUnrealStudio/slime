using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class IceSlimeAI : CharacterAI {

    #region 所有状态
    private MoveState_IceSlime moveState;//移动状态
    public void SetMoveState(MoveState_IceSlime moveState)
    {
        this.moveState = moveState;
        moveState.SetCharacterAI(this);
    }
    public MoveState_IceSlime GetMoveState()
    {
        return moveState;
    }

    private MoveToEnemyState_IceSlime moveToEnemyState;//移动向敌人的状态
    public void SetMoveToEnemyState(MoveToEnemyState_IceSlime moveToEnemyState)
    {
        this.moveToEnemyState = moveToEnemyState;
        moveState.SetCharacterAI(this);
    }
    public MoveToEnemyState_IceSlime GetMoveToEnemyState()
    {
        return moveToEnemyState;
    }

    private MoveToEnemy_IceSlime moveToEnemy;
    public void SetMoveToEnemy(MoveToEnemy_IceSlime moveToEnemy)
    {
        this.moveToEnemy = moveToEnemy;
    }
    public MoveToEnemy_IceSlime GetMoveToEnemy()
    {
        return moveToEnemy;
    }

    private AttackState_IceSlime attackState;
    public void SetAttackState(AttackState_IceSlime attackState)
    {
        this.attackState = attackState;
        moveState.SetCharacterAI(this);
    }
    public AttackState_IceSlime GetAttackState()
    {
        return attackState;
    }

    private LaunchIceState_IceSlime launchIceState;//发射冰锥的状态
    public void SetLaunchIceState(LaunchIceState_IceSlime launchIceState)
    {
        this.launchIceState = launchIceState;
        moveState.SetCharacterAI(this);
    }
    public LaunchIceState_IceSlime GetLaunchIceState()
    {
        return launchIceState;
    }

    private ConditionHaveEnemy_IceSlime conditionHaveEnemy;
    public void SetConditionHaveEnemy(ConditionHaveEnemy_IceSlime conditionHaveEnemy)
    {
        this.conditionHaveEnemy = conditionHaveEnemy;
    }
    public ConditionHaveEnemy_IceSlime GetConditionHaveEnemy()
    {
        return conditionHaveEnemy;
    }

    private DistanceCondition_IceSlime distanceCondition;
    public void SetDistanceCondition(DistanceCondition_IceSlime distanceCondition)
    {
        this.distanceCondition = distanceCondition;
    }
    public DistanceCondition_IceSlime GetDistanceCondition()
    {
        return distanceCondition;
    }

    private LaunchIce_IceSlime launchIce;
    public void SetLaunchIce(LaunchIce_IceSlime launchIce)
    {
        this.launchIce = launchIce;
    }
    public LaunchIce_IceSlime GetLaunchIce()
    {
        return launchIce;
    }
    #endregion

    private Selector root_Node;

    public IceSlimeAI() : base()
    {
        //移动状态
        SetMoveState(new MoveState_IceSlime());
        moveState.SetCharacterAI(this);

        SetMoveToEnemyState(new MoveToEnemyState_IceSlime());
        moveToEnemyState.SetCharacterAI(this);

        SetMoveToEnemy(new MoveToEnemy_IceSlime());
        moveToEnemy.SetCharacterAI(this);

        SetConditionHaveEnemy(new ConditionHaveEnemy_IceSlime());
        conditionHaveEnemy.SetCharacterAI(this);

        SetDistanceCondition(new DistanceCondition_IceSlime());
        distanceCondition.SetCharacterAI(this);

        SetAttackState(new AttackState_IceSlime());
        attackState.SetCharacterAI(this);

        SetLaunchIceState(new LaunchIceState_IceSlime());
        launchIceState.SetCharacterAI(this);

        SetLaunchIce(new LaunchIce_IceSlime());
        launchIce.SetCharacterAI(this);

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
