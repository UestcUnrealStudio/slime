using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class FireSlime2AI : CharacterAI
{

    #region 所有状态
    private MoveState_FireSlime2 moveState;
    public void SetMoveState(MoveState_FireSlime2 moveState)
    {
        this.moveState = moveState;
    }
    public MoveState_FireSlime2 GetMoveState()
    {
        return moveState;
    }

    private RushState_FireSlime2 rushState;
    public void SetRushState(RushState_FireSlime2 rushState)
    {
        this.rushState = rushState;
    }
    public RushState_FireSlime2 GetRushState()
    {
        return rushState;
    }

    private ConditionHaveEnemy_FireSlime2 conditionHaveEnemy;
    public void SetConditionHaveEnemy(ConditionHaveEnemy_FireSlime2 conditionHaveEnemy)
    {
        this.conditionHaveEnemy = conditionHaveEnemy;
    }
    public ConditionHaveEnemy_FireSlime2 GetConditionHaveEnemy()
    {
        return conditionHaveEnemy;
    }

    private Rush_FireSlime2 rush;
    public void SetRush(Rush_FireSlime2 rush)
    {
        this.rush = rush;
    }
    public Rush_FireSlime2 GetRush()
    {
        return rush;
    }

    private VertigoState_FireSlime2 vertigoState;
    public void SetVertigoState(VertigoState_FireSlime2 vertigoState)
    {
        this.vertigoState = vertigoState;
    }
    public VertigoState_FireSlime2 GetVertigoState()
    {
        return vertigoState;
    }

    private ConditionHaveBumpIntoTheWall_FireSlime2 conditionHaveBumpIntoTheWall;
    public void SetConditionHavaBumpInToTheWall(ConditionHaveBumpIntoTheWall_FireSlime2 conditionHaveBumpIntoTheWall)
    {
        this.conditionHaveBumpIntoTheWall = conditionHaveBumpIntoTheWall;
    }
    public ConditionHaveBumpIntoTheWall_FireSlime2 GetConditionHaveBumpIntoTheWall()
    {
        return conditionHaveBumpIntoTheWall;
    }

    private Vertigo_FireSlime2 vertigo;
    public void SetVertigo(Vertigo_FireSlime2 vertigo)
    {
        this.vertigo = vertigo;
    }
    public Vertigo_FireSlime2 GetVertigo()
    {
        return vertigo;
    }

    #endregion
    private Selector root_Node;

    private bool haveBumpIntoTheWall = false;
    public void SetHaveBumpIntoTheWall(bool haveBumpIntoTheWall)
    {
        this.haveBumpIntoTheWall = haveBumpIntoTheWall;
    }
    public bool GetHaveBumpIntoTheWall()
    {
        return haveBumpIntoTheWall;
    }

    public FireSlime2AI():base()
    {
        SetMoveState(new MoveState_FireSlime2());
        moveState.SetCharacterAI(this);

        SetRushState(new RushState_FireSlime2());
        rushState.SetCharacterAI(this);

        SetConditionHaveEnemy(new ConditionHaveEnemy_FireSlime2());
        conditionHaveEnemy.SetCharacterAI(this);

        SetRush(new Rush_FireSlime2());
        rush.SetCharacterAI(this);

        SetVertigoState(new VertigoState_FireSlime2());
        vertigoState.SetCharacterAI(this);

        SetConditionHavaBumpInToTheWall(new ConditionHaveBumpIntoTheWall_FireSlime2());
        conditionHaveBumpIntoTheWall.SetCharacterAI(this);

        SetVertigo(new Vertigo_FireSlime2());
        vertigo.SetCharacterAI(this);

        root_Node = new Selector();
        root_Node.AddChild(moveState);
        root_Node.AddChild(vertigoState);

    }

    public override void Init(IState state)
    {
        base.Init(state);
    }

    public override void UpdateAI()
    {
        root_Node.Tick();
    }
}
