using System;

// Token: 0x020043E4 RID: 17380
public class Mechanism38 : BeMechanism
{
	// Token: 0x060181E2 RID: 98786 RVA: 0x0077F750 File Offset: 0x0077DB50
	public Mechanism38(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060181E3 RID: 98787 RVA: 0x0077F75C File Offset: 0x0077DB5C
	public override void OnInit()
	{
		this.m_ReplaceNormalAttackId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_BackupSkillId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_SkillId = TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true);
		this.m_PveBuffId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.m_PvpBuffId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x060181E4 RID: 98788 RVA: 0x0077F831 File Offset: 0x0077DC31
	public override void OnStart()
	{
		this.DoEffect();
		if (this.m_OwnerDeadHandle != null)
		{
			this.m_OwnerDeadHandle.Remove();
		}
		this.m_OwnerDeadHandle = base.owner.RegisterEvent(BeEventType.onDead, delegate(object[] args)
		{
			this.RemoveEffect();
		});
	}

	// Token: 0x060181E5 RID: 98789 RVA: 0x0077F86E File Offset: 0x0077DC6E
	protected void DoEffect()
	{
		this.ReplaceAttackId(false);
		this.AddBuff(false);
		this.ReplaceSkill(false);
	}

	// Token: 0x060181E6 RID: 98790 RVA: 0x0077F885 File Offset: 0x0077DC85
	protected void RemoveEffect()
	{
		this.ReplaceAttackId(true);
		this.AddBuff(true);
		this.ReplaceSkill(true);
	}

	// Token: 0x060181E7 RID: 98791 RVA: 0x0077F89C File Offset: 0x0077DC9C
	protected void ReplaceAttackId(bool restore = false)
	{
		if (!restore)
		{
			this.m_BackupAttackId = base.owner.GetEntityData().normalAttackID;
			base.owner.GetEntityData().normalAttackID = this.m_ReplaceNormalAttackId;
		}
		else
		{
			base.owner.GetEntityData().normalAttackID = this.m_BackupAttackId;
		}
	}

	// Token: 0x060181E8 RID: 98792 RVA: 0x0077F8F6 File Offset: 0x0077DCF6
	protected void ReplaceSkill(bool restore = false)
	{
		if (!restore)
		{
			this.RemoveReplaceSkillHandle();
			this.m_ReplaceSkillHandle = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
			{
				int[] array = (int[])args[0];
				int num = array[0];
				if (num == this.m_BackupSkillId)
				{
					array[0] = this.m_SkillId;
				}
			});
		}
		else
		{
			this.RemoveReplaceSkillHandle();
		}
	}

	// Token: 0x060181E9 RID: 98793 RVA: 0x0077F92E File Offset: 0x0077DD2E
	protected void RemoveReplaceSkillHandle()
	{
		if (this.m_ReplaceSkillHandle != null)
		{
			this.m_ReplaceSkillHandle.Remove();
		}
	}

	// Token: 0x060181EA RID: 98794 RVA: 0x0077F948 File Offset: 0x0077DD48
	protected void AddBuff(bool remove = false)
	{
		int num;
		if (!BattleMain.IsModePvP(base.battleType))
		{
			num = this.m_PveBuffId;
		}
		else
		{
			num = this.m_PvpBuffId;
		}
		if (!remove)
		{
			base.owner.buffController.TryAddBuff(num, -1, this.level);
		}
		else if (base.owner.buffController.HasBuffByID(num) != null)
		{
			base.owner.buffController.RemoveBuff(num, 0, 0);
		}
	}

	// Token: 0x060181EB RID: 98795 RVA: 0x0077F9CC File Offset: 0x0077DDCC
	public override void OnFinish()
	{
		this.RemoveEffect();
	}

	// Token: 0x04011640 RID: 71232
	protected int m_ReplaceNormalAttackId;

	// Token: 0x04011641 RID: 71233
	protected int m_BackupAttackId;

	// Token: 0x04011642 RID: 71234
	protected int m_SkillId;

	// Token: 0x04011643 RID: 71235
	protected int m_BackupSkillId;

	// Token: 0x04011644 RID: 71236
	protected int m_PveBuffId;

	// Token: 0x04011645 RID: 71237
	protected int m_PvpBuffId;

	// Token: 0x04011646 RID: 71238
	private BeEventHandle m_ReplaceSkillHandle;

	// Token: 0x04011647 RID: 71239
	private BeEventHandle m_OwnerDeadHandle;
}
