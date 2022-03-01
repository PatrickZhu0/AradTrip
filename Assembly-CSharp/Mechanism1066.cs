using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x0200428B RID: 17035
public class Mechanism1066 : BeMechanism
{
	// Token: 0x0601791D RID: 96541 RVA: 0x00741531 File Offset: 0x0073F931
	public Mechanism1066(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601791E RID: 96542 RVA: 0x00741548 File Offset: 0x0073F948
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.phaseList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
	}

	// Token: 0x0601791F RID: 96543 RVA: 0x007415A3 File Offset: 0x0073F9A3
	public override void OnStart()
	{
		this.Reset();
		this.changeNextHandle = base.owner.RegisterEvent(BeEventType.onNextPhaseBeforeExecute, delegate(object[] args)
		{
			int item = (int)args[1];
			if (this.phaseList.Contains(item) && base.owner.GetCurrentSkill() != null && base.owner.GetCurrentSkill().buttonState == ButtonState.RELEASE)
			{
				bool[] array = (bool[])args[0];
				array[0] = true;
			}
		});
	}

	// Token: 0x06017920 RID: 96544 RVA: 0x007415CD File Offset: 0x0073F9CD
	public override void OnFinish()
	{
		base.OnFinish();
		this.Reset();
	}

	// Token: 0x06017921 RID: 96545 RVA: 0x007415DB File Offset: 0x0073F9DB
	private void Reset()
	{
		if (this.changeNextHandle != null)
		{
			this.changeNextHandle.Remove();
			this.changeNextHandle = null;
		}
	}

	// Token: 0x04010EF7 RID: 69367
	private int phase;

	// Token: 0x04010EF8 RID: 69368
	private BeEventHandle changeNextHandle;

	// Token: 0x04010EF9 RID: 69369
	private List<int> phaseList = new List<int>();
}
