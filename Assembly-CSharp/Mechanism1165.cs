using System;

// Token: 0x020042DA RID: 17114
public class Mechanism1165 : BeMechanism
{
	// Token: 0x06017AEA RID: 97002 RVA: 0x0074C716 File Offset: 0x0074AB16
	public Mechanism1165(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017AEB RID: 97003 RVA: 0x0074C720 File Offset: 0x0074AB20
	public override void OnInit()
	{
		base.OnInit();
		this.mDelayTime = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mTimeAcc = 0;
	}

	// Token: 0x06017AEC RID: 97004 RVA: 0x0074C757 File Offset: 0x0074AB57
	public override void OnUpdate(int deltaTime)
	{
		this.mTimeAcc += deltaTime;
		if (this.mTimeAcc >= this.mDelayTime)
		{
			this.UpdatePressButton();
			base.Finish();
		}
	}

	// Token: 0x06017AED RID: 97005 RVA: 0x0074C784 File Offset: 0x0074AB84
	private void UpdatePressButton()
	{
		base.owner.UpdatePressPosition();
	}

	// Token: 0x04011050 RID: 69712
	private int mDelayTime;

	// Token: 0x04011051 RID: 69713
	private int mTimeAcc;
}
