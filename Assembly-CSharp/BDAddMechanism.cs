using System;

// Token: 0x02004105 RID: 16645
public class BDAddMechanism : BDEventBase
{
	// Token: 0x06016A79 RID: 92793 RVA: 0x006DDE96 File Offset: 0x006DC296
	public BDAddMechanism(int id, int d, int lv, bool levelBySkill, bool phaseDelete, bool finishDeleteAll)
	{
		this.mId = id;
		this.mDuration = d;
		this.mLevel = lv;
		this.mLevelBySkill = levelBySkill;
		this.mPhaseDelete = phaseDelete;
		this.mFinishDeleteAll = finishDeleteAll;
	}

	// Token: 0x06016A7A RID: 92794 RVA: 0x006DDECC File Offset: 0x006DC2CC
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		BeActor beActor = pkEntity as BeActor;
		if (beActor != null)
		{
			BeSkill curSkill = beActor.GetCurSkill();
			if (curSkill != null && this.mLevelBySkill)
			{
				this.mLevel = curSkill.level;
			}
			beActor.AddSkillMechanism(this.mId, this.mDuration, this.mLevel, this.mPhaseDelete, this.mFinishDeleteAll);
		}
	}

	// Token: 0x04010275 RID: 66165
	private int mId;

	// Token: 0x04010276 RID: 66166
	private int mDuration;

	// Token: 0x04010277 RID: 66167
	private int mLevel;

	// Token: 0x04010278 RID: 66168
	private bool mLevelBySkill;

	// Token: 0x04010279 RID: 66169
	private bool mPhaseDelete;

	// Token: 0x0401027A RID: 66170
	private bool mFinishDeleteAll;
}
