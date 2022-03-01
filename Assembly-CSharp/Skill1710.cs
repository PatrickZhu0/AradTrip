using System;

// Token: 0x0200446B RID: 17515
public class Skill1710 : BeSkill
{
	// Token: 0x06018573 RID: 99699 RVA: 0x00794CAA File Offset: 0x007930AA
	public Skill1710(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018574 RID: 99700 RVA: 0x00794CC0 File Offset: 0x007930C0
	public override void OnInit()
	{
		this.buffID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.replaceNormalAttackID = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.replaceSkillID1 = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], 1, true);
		this.replacedSkillID1 = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], 1, true);
		this.mpReduce = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
	}

	// Token: 0x06018575 RID: 99701 RVA: 0x00794D74 File Offset: 0x00793174
	public override void OnPostInit()
	{
		this.mpReduce = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		if (base.owner != null)
		{
			this.runeManager = (base.owner.AddMechanism(this.mechanismID, base.level, MechanismSourceType.NONE, null, 0) as Mechanism22);
		}
	}

	// Token: 0x06018576 RID: 99702 RVA: 0x00794DD4 File Offset: 0x007931D4
	public override void OnStart()
	{
		if (!this.started)
		{
			this.started = true;
			this.DoEffect();
		}
		else
		{
			this.started = false;
			this.Restore();
		}
	}

	// Token: 0x06018577 RID: 99703 RVA: 0x00794E00 File Offset: 0x00793200
	private void DoEffect()
	{
		base.owner.buffController.TryAddBuff(this.buffID, int.MaxValue, base.level);
		base.owner.GetEntityData().ChangeMPReduce(this.mpReduce);
		this.backupAttackID = base.owner.GetEntityData().normalAttackID;
		base.owner.GetEntityData().normalAttackID = this.replaceNormalAttackID;
		this.RemoveHandle();
		this.handle = base.owner.RegisterEvent(BeEventType.onMPChange, delegate(object[] args)
		{
			if (base.owner.GetEntityData().GetMP() < this.mpReduce)
			{
				base.PressAgainCancel();
			}
		});
		if (this.replaceSkillID1 != 0 && this.replacedSkillID1 != 0 && base.owner.GetActionNameBySkillID(this.replaceSkillID1) != null && base.owner.GetActionNameBySkillID(this.replacedSkillID1) != null)
		{
			this.handlePreSetAction = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
			{
				int[] array = (int[])args[0];
				int num = array[0];
				if (num == this.replaceSkillID1)
				{
					array[0] = this.replacedSkillID1;
				}
			});
		}
	}

	// Token: 0x06018578 RID: 99704 RVA: 0x00794EF7 File Offset: 0x007932F7
	public override void OnCancel()
	{
		if (this.started)
		{
			this.started = false;
			this.Restore();
		}
	}

	// Token: 0x06018579 RID: 99705 RVA: 0x00794F14 File Offset: 0x00793314
	private void Restore()
	{
		if (base.owner != null)
		{
			this.RemoveHandle();
			base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
			base.owner.GetEntityData().ChangeMPReduce(-this.mpReduce);
			base.owner.GetEntityData().normalAttackID = this.backupAttackID;
		}
	}

	// Token: 0x0601857A RID: 99706 RVA: 0x00794F77 File Offset: 0x00793377
	public void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
		if (this.handlePreSetAction != null)
		{
			this.handlePreSetAction.Remove();
			this.handlePreSetAction = null;
		}
	}

	// Token: 0x0601857B RID: 99707 RVA: 0x00794FB4 File Offset: 0x007933B4
	public int GetRuneCount()
	{
		int result = 0;
		if (this.runeManager != null)
		{
			result = this.runeManager.GetRuneCount();
		}
		return result;
	}

	// Token: 0x04011907 RID: 71943
	protected int buffID;

	// Token: 0x04011908 RID: 71944
	protected int mpReduce;

	// Token: 0x04011909 RID: 71945
	private int mechanismID = 1001;

	// Token: 0x0401190A RID: 71946
	public Mechanism22 runeManager;

	// Token: 0x0401190B RID: 71947
	private int replaceNormalAttackID;

	// Token: 0x0401190C RID: 71948
	private int backupAttackID;

	// Token: 0x0401190D RID: 71949
	private int replaceSkillID1;

	// Token: 0x0401190E RID: 71950
	private int replacedSkillID1;

	// Token: 0x0401190F RID: 71951
	protected BeEventHandle handle;

	// Token: 0x04011910 RID: 71952
	protected BeEventHandle handlePreSetAction;

	// Token: 0x04011911 RID: 71953
	private bool started;
}
