using System;

// Token: 0x020043FF RID: 17407
public class Mechanism63 : BeMechanism
{
	// Token: 0x060182B4 RID: 98996 RVA: 0x007853F5 File Offset: 0x007837F5
	public Mechanism63(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060182B5 RID: 98997 RVA: 0x00785410 File Offset: 0x00783810
	public override void OnInit()
	{
		this.m_OriginalSkillId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_ReplaceSkillId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.changeSkillLevel = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) != 1);
	}

	// Token: 0x060182B6 RID: 98998 RVA: 0x0078549C File Offset: 0x0078389C
	public override void OnStart()
	{
		this.RemoveHandle();
		this.m_ReplaceSkillHandle = base.owner.RegisterEvent(BeEventType.onReplaceSkill, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			BeSkill skill = base.owner.GetSkill(this.m_OriginalSkillId);
			if (array[0] == this.m_OriginalSkillId && this.IsYinGunagLuoren(this.m_OriginalSkillId))
			{
				BeSkill skill2 = base.owner.GetSkill(this.m_ReplaceSkillId);
				if (skill2 != null && skill2.CanUseSkill())
				{
					this.m_ReplaceSkillLevel = skill2.level;
					skill.StartCoolDown();
					if (this.changeSkillLevel)
					{
						skill2.level = skill.level;
					}
					array[0] = this.m_ReplaceSkillId;
				}
			}
		});
		this.m_CastSkillFinishHandle = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.m_ReplaceSkillId && this.m_ReplaceSkillLevel != -1)
			{
				BeSkill skill = base.owner.GetSkill(this.m_ReplaceSkillId);
				if (skill != null && skill.level != this.m_ReplaceSkillLevel && this.changeSkillLevel)
				{
					skill.level = this.m_ReplaceSkillLevel;
				}
			}
		});
	}

	// Token: 0x060182B7 RID: 98999 RVA: 0x007854ED File Offset: 0x007838ED
	private bool IsYinGunagLuoren(int id)
	{
		return id != 1514 || base.owner.sgGetCurrentState() == 6;
	}

	// Token: 0x060182B8 RID: 99000 RVA: 0x00785510 File Offset: 0x00783910
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x060182B9 RID: 99001 RVA: 0x00785518 File Offset: 0x00783918
	protected void RemoveHandle()
	{
		if (this.m_ReplaceSkillHandle != null)
		{
			this.m_ReplaceSkillHandle.Remove();
			this.m_ReplaceSkillHandle = null;
		}
		if (this.m_CastSkillFinishHandle != null)
		{
			this.m_CastSkillFinishHandle.Remove();
			this.m_CastSkillFinishHandle = null;
		}
	}

	// Token: 0x0401170A RID: 71434
	protected int m_OriginalSkillId;

	// Token: 0x0401170B RID: 71435
	protected int m_ReplaceSkillId;

	// Token: 0x0401170C RID: 71436
	protected BeEventHandle m_ReplaceSkillHandle;

	// Token: 0x0401170D RID: 71437
	protected BeEventHandle m_CastSkillFinishHandle;

	// Token: 0x0401170E RID: 71438
	protected int m_ReplaceSkillLevel = -1;

	// Token: 0x0401170F RID: 71439
	protected bool changeSkillLevel = true;
}
