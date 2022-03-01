using System;
using System.Collections.Generic;

// Token: 0x02004281 RID: 17025
public class Mechanism1055 : BeMechanism
{
	// Token: 0x060178E8 RID: 96488 RVA: 0x007402A1 File Offset: 0x0073E6A1
	public Mechanism1055(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060178E9 RID: 96489 RVA: 0x007402C4 File Offset: 0x0073E6C4
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.skillList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.time = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		for (int j = 0; j < this.data.ValueC.Count; j++)
		{
			this.buffInfoList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true));
		}
	}

	// Token: 0x060178EA RID: 96490 RVA: 0x00740395 File Offset: 0x0073E795
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onBeExcuteGrab, new BeEventHandle.Del(this.BeExcuteGrab));
	}

	// Token: 0x060178EB RID: 96491 RVA: 0x007403BF File Offset: 0x0073E7BF
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.UpdateRestoreAITarget(deltaTime);
	}

	// Token: 0x060178EC RID: 96492 RVA: 0x007403D0 File Offset: 0x0073E7D0
	private void UpdateRestoreAITarget(int deltaTime)
	{
		if (!this.assignAITargetFlag)
		{
			return;
		}
		if (this.curTime >= this.time)
		{
			this.curTime = 0;
			this.assignAITargetFlag = false;
			base.owner.aiManager.ForceAssignAiTarget(null);
		}
		else
		{
			this.curTime += deltaTime;
		}
	}

	// Token: 0x060178ED RID: 96493 RVA: 0x0074042C File Offset: 0x0073E82C
	private void BeExcuteGrab(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (!base.owner.IsCastingSkill())
		{
			return;
		}
		int iCurSkillID = base.owner.m_iCurSkillID;
		if (!this.skillList.Contains(iCurSkillID))
		{
			return;
		}
		this.SetAITarget(beActor);
		this.AddBuff(beActor);
	}

	// Token: 0x060178EE RID: 96494 RVA: 0x00740486 File Offset: 0x0073E886
	private void SetAITarget(BeActor graber)
	{
		if (this.time <= 0)
		{
			return;
		}
		this.curTime = 0;
		this.assignAITargetFlag = true;
		base.owner.aiManager.ForceAssignAiTarget(graber);
	}

	// Token: 0x060178EF RID: 96495 RVA: 0x007404B4 File Offset: 0x0073E8B4
	private void AddBuff(BeActor graber)
	{
		if (graber == null)
		{
			return;
		}
		for (int i = 0; i < this.buffInfoList.Count; i++)
		{
			graber.buffController.TryAddBuffInfo(this.buffInfoList[i], base.owner, this.level);
		}
	}

	// Token: 0x04010ED6 RID: 69334
	private List<int> skillList = new List<int>();

	// Token: 0x04010ED7 RID: 69335
	private int time;

	// Token: 0x04010ED8 RID: 69336
	private List<int> buffInfoList = new List<int>();

	// Token: 0x04010ED9 RID: 69337
	private int curTime;

	// Token: 0x04010EDA RID: 69338
	private bool assignAITargetFlag;
}
