using System;

// Token: 0x020044DC RID: 17628
public class Skill5169 : BeSkill
{
	// Token: 0x06018894 RID: 100500 RVA: 0x007A9034 File Offset: 0x007A7434
	public Skill5169(int sid, int skillLevel) : base(sid, skillLevel)
	{
		this.mState = Skill5169.eState.Pre;
	}

	// Token: 0x06018895 RID: 100501 RVA: 0x007A905C File Offset: 0x007A745C
	public override void OnStart()
	{
		this.mState = Skill5169.eState.Pre;
		this.mSplitRate = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], 1, true);
		this.mAttackRate = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], 1, true);
		if (this.mAttackRate == 0)
		{
			this.mAttackRate = GlobalLogic.VALUE_500;
		}
	}

	// Token: 0x06018896 RID: 100502 RVA: 0x007A90C4 File Offset: 0x007A74C4
	private void _setState(BeActor actor, bool isControl)
	{
		if (actor != null && !actor.IsDeadOrRemoved())
		{
			if (isControl)
			{
				actor.sgForceSwitchState(new BeStateData
				{
					_State = 2,
					_timeout = -1
				});
				actor.sgSetCurrentStatesTimeout(int.MaxValue);
				actor.hasAI = false;
			}
			else
			{
				actor.sgForceSwitchState(new BeStateData
				{
					_State = 0
				});
				actor.sgSetCurrentStatesTimeout(1);
				actor.hasAI = true;
			}
		}
	}

	// Token: 0x06018897 RID: 100503 RVA: 0x007A9144 File Offset: 0x007A7544
	public override bool CheckSpellCondition(ActionState state)
	{
		BeEntityData entityData = base.owner.GetEntityData();
		return base.owner.stateController.CanDuplicate() && base.owner.CurrentBeScene.GetSummonCountByID(entityData.monsterID, null) <= 0;
	}

	// Token: 0x06018898 RID: 100504 RVA: 0x007A9194 File Offset: 0x007A7594
	private void _createFake()
	{
		BeEntityData entityData = base.owner.GetEntityData();
		int num = entityData.monsterID + entityData.level * GlobalLogic.VALUE_100;
		BeActor beActor = base.owner.CurrentBeScene.DuplicateMonster(base.owner, new VFactor((long)this.mAttackRate, (long)GlobalLogic.VALUE_1000), 0);
		if (beActor != null)
		{
			this.mDup = beActor;
			this.mPos = base.owner.GetPosition();
			this.mDup.GetEntityData().type = 1;
			if (this.mDup.m_pkGeActor.goFootInfo != null)
			{
				this.mDup.m_pkGeActor.goFootInfo.SetActive(false);
			}
			if (this.mDup.m_pkGeActor.goInfoBar != null)
			{
				this.mDup.m_pkGeActor.goInfoBar.SetActive(false);
			}
			this._setState(this.mDup, true);
			this._setState(base.owner, true);
		}
		else
		{
			this.mDup = null;
		}
	}

	// Token: 0x06018899 RID: 100505 RVA: 0x007A92A8 File Offset: 0x007A76A8
	public override void OnUpdate(int iDeltime)
	{
		if (this.mDup != null && this.mState == Skill5169.eState.Start)
		{
			base.owner.SetMoveSpeedX(VInt.NewVInt((!base.owner.GetFace()) ? (-this.mSplitRate) : this.mSplitRate, GlobalLogic.VALUE_1000));
			this.mDup.SetMoveSpeedX(VInt.NewVInt((!base.owner.GetFace()) ? this.mSplitRate : (-this.mSplitRate), GlobalLogic.VALUE_1000));
			this.mDup.SetFace(!base.owner.GetFace(), false, false);
			if (base.owner.HasAction("Walk02"))
			{
				base.owner.PlayAction("Walk02", 1f);
			}
			if (this.mDup.HasAction("Walk02"))
			{
				this.mDup.PlayAction("Walk02", 1f);
			}
		}
	}

	// Token: 0x0601889A RID: 100506 RVA: 0x007A93AB File Offset: 0x007A77AB
	public override void OnFinish()
	{
		if (this.mDup != null)
		{
			this._setState(this.mDup, false);
			this._setState(base.owner, false);
			this.mDup = null;
		}
		this.mState = Skill5169.eState.End;
	}

	// Token: 0x0601889B RID: 100507 RVA: 0x007A93E0 File Offset: 0x007A77E0
	public override void OnCancel()
	{
		if (this.mDup != null)
		{
			this._setState(this.mDup, false);
			this._setState(base.owner, false);
			this.mDup = null;
		}
		this.mState = Skill5169.eState.End;
	}

	// Token: 0x0601889C RID: 100508 RVA: 0x007A9415 File Offset: 0x007A7815
	public override void OnEnterPhase(int phase)
	{
		if (phase == 1)
		{
			this.mState = Skill5169.eState.Pre;
		}
		else if (phase == 2)
		{
			this.mState = Skill5169.eState.Start;
			this._createFake();
		}
	}

	// Token: 0x04011B35 RID: 72501
	private BeActor mDup;

	// Token: 0x04011B36 RID: 72502
	private VInt3 mPos;

	// Token: 0x04011B37 RID: 72503
	private int mSplitRate = 1000;

	// Token: 0x04011B38 RID: 72504
	private int mAttackRate = 500;

	// Token: 0x04011B39 RID: 72505
	private Skill5169.eState mState;

	// Token: 0x020044DD RID: 17629
	private enum eState
	{
		// Token: 0x04011B3B RID: 72507
		Pre,
		// Token: 0x04011B3C RID: 72508
		Start,
		// Token: 0x04011B3D RID: 72509
		End
	}
}
