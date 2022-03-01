using System;
using System.Collections.Generic;

// Token: 0x020044E5 RID: 17637
public class Skill5573 : BeSkill
{
	// Token: 0x060188BE RID: 100542 RVA: 0x007AA239 File Offset: 0x007A8639
	public Skill5573(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060188BF RID: 100543 RVA: 0x007AA264 File Offset: 0x007A8664
	public override void OnInit()
	{
		this.m_UnUseSkillList.Clear();
		this.m_UnUseSkillList.Add(5568);
		this.m_UnUseSkillList.Add(5569);
		this.m_UnUseSkillList.Add(5573);
		this.m_UnUseSkillList.Add(5570);
	}

	// Token: 0x060188C0 RID: 100544 RVA: 0x007AA2BC File Offset: 0x007A86BC
	public override void OnStart()
	{
		this.mState = Skill5573.eState.Pre;
	}

	// Token: 0x060188C1 RID: 100545 RVA: 0x007AA2C8 File Offset: 0x007A86C8
	private void _setState(BeActor actor, bool isControl)
	{
		if (actor != null && !actor.IsDead())
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

	// Token: 0x060188C2 RID: 100546 RVA: 0x007AA348 File Offset: 0x007A8748
	public override bool CheckSpellCondition(ActionState state)
	{
		BeEntityData entityData = base.owner.GetEntityData();
		return base.owner.stateController.CanDuplicate() && base.owner.CurrentBeScene.GetSummonCountByID(entityData.monsterID, null) <= 0;
	}

	// Token: 0x060188C3 RID: 100547 RVA: 0x007AA398 File Offset: 0x007A8798
	private void _createFake()
	{
		BeEntityData entityData = base.owner.GetEntityData();
		int num = entityData.monsterID + entityData.level * GlobalLogic.VALUE_100;
		base.owner.aiManager.SetSkillsEnable(this.m_UnUseSkillList, false);
		this.mFront = base.owner.CurrentBeScene.DuplicateMonster(base.owner);
		if (this.mFront != null)
		{
			this.mFront.aiManager.SetSkillsEnable(this.m_UnUseSkillList, false);
			this.mFront.RemoveSkill(5574);
			this.mFront.GetEntityData().type = 1;
			this._setState(this.mFront, true);
		}
		else
		{
			this.mFront = null;
		}
		this.mBack = base.owner.CurrentBeScene.DuplicateMonster(base.owner);
		if (this.mBack != null)
		{
			this.mBack.aiManager.SetSkillsEnable(this.m_UnUseSkillList, false);
			this.mBack.RemoveSkill(5574);
			this.mBack.GetEntityData().type = 1;
			this._setState(this.mBack, true);
		}
		else
		{
			this.mBack = null;
		}
	}

	// Token: 0x060188C4 RID: 100548 RVA: 0x007AA4D4 File Offset: 0x007A88D4
	public override void OnUpdate(int iDeltime)
	{
		if (this.mFront != null && this.mState == Skill5573.eState.Start)
		{
			this.mFront.SetMoveSpeedX(base.owner.GetFace() ? this.mSplitRate : (-this.mSplitRate));
			this.mFront.SetFace(true, false, false);
			if (this.mFront.HasAction("Walk"))
			{
				this.mFront.PlayAction("Walk", 1f);
			}
		}
		if (this.mBack != null && this.mState == Skill5573.eState.Start)
		{
			this.mBack.SetMoveSpeedX((!base.owner.GetFace()) ? this.mSplitRate : (-this.mSplitRate));
			this.mBack.SetFace(false, false, false);
			if (this.mBack.HasAction("Walk"))
			{
				this.mBack.PlayAction("Walk", 1f);
			}
		}
	}

	// Token: 0x060188C5 RID: 100549 RVA: 0x007AA5E4 File Offset: 0x007A89E4
	public override void OnFinish()
	{
		if (this.mFront != null)
		{
			this._setState(this.mFront, false);
			this.mFront = null;
		}
		if (this.mBack != null)
		{
			this._setState(this.mBack, false);
			this.mBack = null;
		}
		this.mState = Skill5573.eState.End;
	}

	// Token: 0x060188C6 RID: 100550 RVA: 0x007AA638 File Offset: 0x007A8A38
	public override void OnCancel()
	{
		if (this.mFront != null)
		{
			this._setState(this.mFront, false);
			this.mFront = null;
		}
		if (this.mBack != null)
		{
			this._setState(this.mBack, false);
			this.mBack = null;
		}
		this.mState = Skill5573.eState.End;
	}

	// Token: 0x060188C7 RID: 100551 RVA: 0x007AA68A File Offset: 0x007A8A8A
	public override void OnEnterPhase(int phase)
	{
		if (phase == 1)
		{
			this.mState = Skill5573.eState.Pre;
		}
		else if (phase == 2)
		{
			this.mState = Skill5573.eState.Start;
			this._createFake();
		}
	}

	// Token: 0x04011B5F RID: 72543
	private BeActor mFront;

	// Token: 0x04011B60 RID: 72544
	private BeActor mBack;

	// Token: 0x04011B61 RID: 72545
	private VInt mSplitRate = VInt.NewVInt(3000, 1000);

	// Token: 0x04011B62 RID: 72546
	private List<int> m_UnUseSkillList = new List<int>();

	// Token: 0x04011B63 RID: 72547
	private Skill5573.eState mState;

	// Token: 0x020044E6 RID: 17638
	private enum eState
	{
		// Token: 0x04011B65 RID: 72549
		Pre,
		// Token: 0x04011B66 RID: 72550
		Start,
		// Token: 0x04011B67 RID: 72551
		End
	}
}
