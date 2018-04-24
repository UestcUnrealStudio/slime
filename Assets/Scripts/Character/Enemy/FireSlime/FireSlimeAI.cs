using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;
public class FireSlimeAI : CharacterAI
{
    #region 所有状态
    private AttackState_FireSlime attackState;
    public void SetAttackState(AttackState_FireSlime attackState)
    {
        this.attackState = attackState;
    }
    public AttackState_FireSlime GetAttackState()
    {
        return attackState;
    }

    private LaunchFusedLaserState_FireSlime launchFusedLaserState;
    public void SetLaunchFusedLaserState(LaunchFusedLaserState_FireSlime launchFusedLaserState)
    {
        this.launchFusedLaserState = launchFusedLaserState;
    }
    public LaunchFusedLaserState_FireSlime GetLaunchFusedLaserState()
    {
        return launchFusedLaserState;
    }

    private MoveState_FireSlime moveState;
    public void SetMoveState(MoveState_FireSlime moveState)
    {
        this.moveState = moveState;
    }
    public MoveState_FireSlime GetMoveState()
    {
        return moveState;
    }

    private MoveToEnemyState_FireSlime moveToEnemyState;
    public void SetMoveToEnemyState(MoveToEnemyState_FireSlime moveToEnemyState)
    {
        this.moveToEnemyState = moveToEnemyState;
    }
    public MoveToEnemyState_FireSlime GetMoveToEnemyState()
    {
        return moveToEnemyState;
    }

    private ConditionHaveEnemy_FireSlime conditionHasEnemy;
    public void setConditionHasEnemy(ConditionHaveEnemy_FireSlime conditionHasEnemy)
    {
        this.conditionHasEnemy = conditionHasEnemy;
    }
    public ConditionHaveEnemy_FireSlime GetConditionHasEnemy()
    {
        return conditionHasEnemy;
    }

    private LaunchFusedLaser_FireSlime launchFusedLaser;
    public void SetLaunchFusedLaser(LaunchFusedLaser_FireSlime launchFusedLaser)
    {
        this.launchFusedLaser = launchFusedLaser;
    }
    public LaunchFusedLaser_FireSlime GetLaunchFusedLaser()
    {
        return launchFusedLaser;
    }

    private MoveToEnemy_FireSlime moveToEnemy;
    public void SetMoveToEnemy(MoveToEnemy_FireSlime moveToEnemy)
    {
        this.moveToEnemy = moveToEnemy;
    }
    public MoveToEnemy_FireSlime GetMoveToEnemy()
    {
        return moveToEnemy;
    }

    private DistanceCondition_FireSlime distanceCondition;
    public void SetDistanceCondition(DistanceCondition_FireSlime distanceCondition)
    {
        this.distanceCondition = distanceCondition;
    }
    public DistanceCondition_FireSlime GetDistanceCondition()
    {
        return distanceCondition;
    }
    #endregion

    private Selector root_State;

    public FireSlimeAI() : base()
    {
        SetAttackState(new AttackState_FireSlime());
        attackState.SetCharacterAI(this);
        SetLaunchFusedLaserState(new LaunchFusedLaserState_FireSlime());
        launchFusedLaserState.SetCharacterAI(this);
        SetMoveState(new MoveState_FireSlime());
        moveState.SetCharacterAI(this);
        SetMoveToEnemyState(new MoveToEnemyState_FireSlime());
        moveToEnemyState.SetCharacterAI(this);
        setConditionHasEnemy(new ConditionHaveEnemy_FireSlime());
        conditionHasEnemy.SetCharacterAI(this);
        SetLaunchFusedLaser(new LaunchFusedLaser_FireSlime());
        launchFusedLaser.SetCharacterAI(this);
        SetMoveToEnemy(new MoveToEnemy_FireSlime());
        moveToEnemy.SetCharacterAI(this);
        SetDistanceCondition(new DistanceCondition_FireSlime());
        distanceCondition.SetCharacterAI(this);

        root_State = new Selector();
        root_State.AddChild(attackState);
        root_State.AddChild(moveState);
        root_State.currentState = State.NONE;
    }

    public override void UpdateAI()
    {
        root_State.Tick();
    }
}
