using System;

// Token: 0x020043EB RID: 17387
public class Mechanism44 : BeMechanism
{
	// Token: 0x0601821E RID: 98846 RVA: 0x0078125C File Offset: 0x0077F65C
	public Mechanism44(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601821F RID: 98847 RVA: 0x007812B7 File Offset: 0x0077F6B7
	public override void OnInit()
	{
		this.m_ReduceMp = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x06018220 RID: 98848 RVA: 0x007812E4 File Offset: 0x0077F6E4
	public override void OnStart()
	{
		base.owner.GetEntityData().ChangeMPReduce(this.m_ReduceMp);
		this.m_JumpBackHandle = base.owner.RegisterEvent(BeEventType.onJumpBackAttack, delegate(object[] args)
		{
			if (base.owner.HasSkill(this.m_ReplaceJumpAttackId))
			{
				base.owner.UseSkill(this.m_ReplaceJumpAttackId, true);
			}
		});
		this.m_ReplaceSkillHandle = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			if (array[0] == this.m_NormalTuciId)
			{
				array[0] = this.m_ReplaceAttackId;
			}
			if (array[0] == this.m_NormalJumpAttackId)
			{
				array[0] = this.m_ReplaceJumpAttackId;
				int[] currSkillPhase = new int[]
				{
					1820,
					18200
				};
				base.owner.SetCurrSkillPhase(currSkillPhase);
			}
		});
		this.ReplaceAttackId();
	}

	// Token: 0x06018221 RID: 98849 RVA: 0x0078134B File Offset: 0x0077F74B
	protected void ReplaceAttackId()
	{
		this.m_AttackData = base.owner.AddReplaceAttackId(this.m_ReplaceAttackId, 2);
	}

	// Token: 0x06018222 RID: 98850 RVA: 0x00781365 File Offset: 0x0077F765
	protected void RestoreAttackId()
	{
		base.owner.RemoveReplaceAttackId(this.m_AttackData);
	}

	// Token: 0x06018223 RID: 98851 RVA: 0x00781378 File Offset: 0x0077F778
	public override void OnFinish()
	{
		this.RemoveHandle();
		this.RestoreAttackId();
		if (base.owner.HasSkill(this.m_SkillId))
		{
			base.owner.GetSkill(this.m_SkillId).Cancel();
		}
	}

	// Token: 0x06018224 RID: 98852 RVA: 0x007813B4 File Offset: 0x0077F7B4
	public void RemoveHandle()
	{
		base.owner.GetEntityData().ChangeMPReduce(-this.m_ReduceMp);
		if (this.m_JumpBackHandle != null)
		{
			this.m_JumpBackHandle.Remove();
		}
		if (this.m_ReplaceSkillHandle != null)
		{
			this.m_ReplaceSkillHandle.Remove();
		}
	}

	// Token: 0x0401167A RID: 71290
	protected int m_ReduceMp;

	// Token: 0x0401167B RID: 71291
	protected int m_SkillId = 1811;

	// Token: 0x0401167C RID: 71292
	protected int m_ReplaceAttackId = 1819;

	// Token: 0x0401167D RID: 71293
	protected int m_ReplaceJumpAttackId = 1820;

	// Token: 0x0401167E RID: 71294
	protected int m_NormalJumpAttackId = 1513;

	// Token: 0x0401167F RID: 71295
	protected int m_NormalTuciId = 1504;

	// Token: 0x04011680 RID: 71296
	protected BeEventHandle m_JumpBackHandle;

	// Token: 0x04011681 RID: 71297
	protected BeEventHandle m_ReplaceSkillHandle;

	// Token: 0x04011682 RID: 71298
	protected BeActor.NormalAttack m_AttackData = default(BeActor.NormalAttack);
}
