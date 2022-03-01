using System;

// Token: 0x020042C4 RID: 17092
internal class Mechanism115 : BeMechanism
{
	// Token: 0x06017A60 RID: 96864 RVA: 0x007497E2 File Offset: 0x00747BE2
	public Mechanism115(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017A61 RID: 96865 RVA: 0x007497EC File Offset: 0x00747BEC
	public override void OnInit()
	{
		this.skillPhaseId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.time = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.timeRate = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		if (this.data.ValueD.Count > 0)
		{
			this.relateByLevel = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
		if (this.data.ValueE.Count > 0)
		{
			this.skillPhaseStartTime = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
	}

	// Token: 0x06017A62 RID: 96866 RVA: 0x007498ED File Offset: 0x00747CED
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeSkillTime, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.skillPhaseId)
			{
				int[] array = (int[])args[1];
				if (this.skillPhaseStartTime > 0)
				{
					array[0] = this.skillPhaseStartTime;
				}
				array[0] += ((this.relateByLevel != 1) ? this.time : (this.time * this.level));
				array[1] += ((this.relateByLevel != 1) ? this.timeRate : (this.timeRate * this.level));
			}
		});
	}

	// Token: 0x04010FE7 RID: 69607
	private int skillPhaseId;

	// Token: 0x04010FE8 RID: 69608
	private int time;

	// Token: 0x04010FE9 RID: 69609
	private int timeRate;

	// Token: 0x04010FEA RID: 69610
	private int relateByLevel;

	// Token: 0x04010FEB RID: 69611
	private int monsterId;

	// Token: 0x04010FEC RID: 69612
	private int skillPhaseStartTime;

	// Token: 0x04010FED RID: 69613
	private BeEventHandle monsterHandle;
}
