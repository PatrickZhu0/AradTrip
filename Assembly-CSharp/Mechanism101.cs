using System;

// Token: 0x02004250 RID: 16976
internal class Mechanism101 : BeMechanism
{
	// Token: 0x060177CD RID: 96205 RVA: 0x0073927A File Offset: 0x0073767A
	public Mechanism101(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177CE RID: 96206 RVA: 0x00739284 File Offset: 0x00737684
	public override void OnInit()
	{
		this.buffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffInfoIdArray = new int[this.data.ValueB.Length];
		for (int i = 0; i < this.data.ValueB.Length; i++)
		{
			this.buffInfoIdArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
		}
	}

	// Token: 0x060177CF RID: 96207 RVA: 0x0073931F File Offset: 0x0073771F
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
		{
			for (int i = 0; i < this.buffInfoIdArray.Length; i++)
			{
				BuffInfoData buffInfoData = new BuffInfoData(this.buffInfoIdArray[i], 0, 0);
				buffInfoData = base.owner.buffController.GetTriggerBuff(buffInfoData);
				if (buffInfoData != null)
				{
					buffInfoData.StartCD();
				}
			}
		});
	}

	// Token: 0x04010E0C RID: 69132
	private int buffId;

	// Token: 0x04010E0D RID: 69133
	private int[] buffInfoIdArray;
}
