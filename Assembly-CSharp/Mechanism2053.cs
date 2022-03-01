using System;

// Token: 0x0200436D RID: 17261
public class Mechanism2053 : BeMechanism
{
	// Token: 0x06017E87 RID: 97927 RVA: 0x00766309 File Offset: 0x00764709
	public Mechanism2053(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017E88 RID: 97928 RVA: 0x00766314 File Offset: 0x00764714
	public override void OnInit()
	{
		base.OnInit();
		this.srcSkillID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.targetSkillID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017E89 RID: 97929 RVA: 0x00766377 File Offset: 0x00764777
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onReachMaxEnergy, new BeEventHandle.Del(this.onReachMaxEnergy));
	}

	// Token: 0x06017E8A RID: 97930 RVA: 0x007663A1 File Offset: 0x007647A1
	private void onReachMaxEnergy(object[] args)
	{
		if (base.owner.sgGetCurrentState() == 14 && base.owner.GetCurSkillID() == this.srcSkillID)
		{
			base.owner.UseSkill(this.targetSkillID, false);
		}
	}

	// Token: 0x0401135C RID: 70492
	private int srcSkillID;

	// Token: 0x0401135D RID: 70493
	private int targetSkillID;
}
