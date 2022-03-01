using System;
using GameClient;

// Token: 0x02004424 RID: 17444
internal class Mechanism99 : BeMechanism
{
	// Token: 0x060183AB RID: 99243 RVA: 0x0078B91E File Offset: 0x00789D1E
	public Mechanism99(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060183AC RID: 99244 RVA: 0x0078B934 File Offset: 0x00789D34
	public override void OnInit()
	{
		this.startCD = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.CD = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.buffInfoArray = new int[this.data.ValueC.Length];
		for (int i = 0; i < this.data.ValueC.Length; i++)
		{
			this.buffInfoArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
		}
		if (this.data.StringValueA.Length > 0)
		{
			this.textInfo = this.data.StringValueA[0];
		}
		if (this.data.ValueD.Length > 0)
		{
			this.textLastTime = (float)TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) / 1000f;
		}
	}

	// Token: 0x060183AD RID: 99245 RVA: 0x0078BA69 File Offset: 0x00789E69
	public override void OnStart()
	{
		this.timer = this.startCD;
	}

	// Token: 0x060183AE RID: 99246 RVA: 0x0078BA78 File Offset: 0x00789E78
	public override void OnUpdate(int deltaTime)
	{
		this.timer -= deltaTime;
		if (this.timer <= 0)
		{
			for (int i = 0; i < this.buffInfoArray.Length; i++)
			{
				base.owner.buffController.TryAddBuff(this.buffInfoArray[i], null, false, null, 0);
			}
			this.timer = this.CD;
			if (this.textInfo.Length > 0)
			{
				SystemNotifyManager.SysDungeonSkillTip(this.textInfo, this.textLastTime, false);
			}
		}
	}

	// Token: 0x040117D4 RID: 71636
	private int startCD;

	// Token: 0x040117D5 RID: 71637
	private int CD;

	// Token: 0x040117D6 RID: 71638
	private int[] buffInfoArray;

	// Token: 0x040117D7 RID: 71639
	private string textInfo = string.Empty;

	// Token: 0x040117D8 RID: 71640
	private float textLastTime;

	// Token: 0x040117D9 RID: 71641
	private int timer;
}
