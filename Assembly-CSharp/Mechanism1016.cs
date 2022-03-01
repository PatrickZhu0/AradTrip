using System;
using System.Collections.Generic;

// Token: 0x02004255 RID: 16981
public class Mechanism1016 : BeMechanism
{
	// Token: 0x060177F1 RID: 96241 RVA: 0x0073A41F File Offset: 0x0073881F
	public Mechanism1016(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177F2 RID: 96242 RVA: 0x0073A44C File Offset: 0x0073884C
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.buffList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.onlyMainActor = (TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) == 1);
	}

	// Token: 0x060177F3 RID: 96243 RVA: 0x0073A4D8 File Offset: 0x007388D8
	public override void OnStart()
	{
		base.OnStart();
		if (this.onlyMainActor && !base.owner.isMainActor)
		{
			return;
		}
		BeBuff beBuff = base.owner.buffController.HasBuffByID(558929);
		BeBuff beBuff2 = base.owner.buffController.HasBuffByID(558930);
		if (beBuff != null)
		{
			base.owner.buffController.RemoveBuff(558929, 0, 0);
			base.owner.buffController.TryAddBuff(this.buffInfoID01, null, false, null, 0);
		}
		else if (beBuff2 != null)
		{
			base.owner.buffController.RemoveBuff(558930, 0, 0);
			base.owner.buffController.TryAddBuff(this.buffInfoID, null, false, null, 0);
		}
		else
		{
			int index = base.owner.FrameRandom.InRange(0, this.buffList.Count);
			base.owner.buffController.TryAddBuff(this.buffList[index], null, false, null, 0);
		}
	}

	// Token: 0x04010E22 RID: 69154
	private List<int> buffList = new List<int>();

	// Token: 0x04010E23 RID: 69155
	private int buffInfoID = 568929;

	// Token: 0x04010E24 RID: 69156
	private int buffInfoID01 = 568930;

	// Token: 0x04010E25 RID: 69157
	private bool onlyMainActor;
}
