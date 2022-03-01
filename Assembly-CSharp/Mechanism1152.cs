using System;

// Token: 0x020042C8 RID: 17096
public class Mechanism1152 : BeMechanism
{
	// Token: 0x06017A7F RID: 96895 RVA: 0x0074A31A File Offset: 0x0074871A
	public Mechanism1152(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017A80 RID: 96896 RVA: 0x0074A330 File Offset: 0x00748730
	public override void OnInit()
	{
		this.mChangeIntervalByRate = (TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) == 1);
		this.mChangeBuffID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (this.mChangeIntervalByRate)
		{
			this.mChangeRate = new VRate(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true));
		}
		else
		{
			this.mChangeTime = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
	}

	// Token: 0x06017A81 RID: 96897 RVA: 0x0074A3F8 File Offset: 0x007487F8
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.ChangeBuffTimeInterval();
			this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, new BeEventHandle.Del(this.OnAddBuffEvent));
			this.handleB = base.owner.RegisterEvent(BeEventType.onRemoveBuff, new BeEventHandle.Del(this.OnRemoveBuffEvent));
		}
	}

	// Token: 0x06017A82 RID: 96898 RVA: 0x0074A454 File Offset: 0x00748854
	public override void OnFinish()
	{
		this.ResotreBuffTimeInterval();
	}

	// Token: 0x06017A83 RID: 96899 RVA: 0x0074A45C File Offset: 0x0074885C
	protected void ChangeBuffTimeInterval()
	{
		if (base.owner == null || base.owner.buffController == null)
		{
			return;
		}
		this.mChangeBuffInstance = base.owner.buffController.HasBuffByID(this.mChangeBuffID);
		if (this.mChangeBuffInstance == null)
		{
			return;
		}
		if (this.mChangeIntervalByRate)
		{
			if (this.mChangeRate >= VRate.one)
			{
				return;
			}
			this.mChangeRateTime = this.mChangeBuffInstance.timeInterval * this.mChangeRate.factor;
			BeBuff beBuff = this.mChangeBuffInstance;
			beBuff.timeInterval -= this.mChangeRateTime;
		}
		else
		{
			if (this.mChangeTime >= this.mChangeBuffInstance.timeInterval)
			{
				return;
			}
			BeBuff beBuff2 = this.mChangeBuffInstance;
			beBuff2.timeInterval -= this.mChangeTime;
		}
	}

	// Token: 0x06017A84 RID: 96900 RVA: 0x0074A55C File Offset: 0x0074895C
	protected void ResotreBuffTimeInterval()
	{
		if (this.mChangeBuffInstance == null)
		{
			return;
		}
		if (this.mChangeIntervalByRate)
		{
			BeBuff beBuff = this.mChangeBuffInstance;
			beBuff.timeInterval += this.mChangeRateTime;
		}
		else
		{
			BeBuff beBuff2 = this.mChangeBuffInstance;
			beBuff2.timeInterval += this.mChangeTime;
		}
	}

	// Token: 0x06017A85 RID: 96901 RVA: 0x0074A5CC File Offset: 0x007489CC
	protected void OnAddBuffEvent(object[] args)
	{
		BeBuff beBuff = args[0] as BeBuff;
		if (beBuff == null || beBuff.buffID != this.mChangeBuffID)
		{
			return;
		}
		this.ChangeBuffTimeInterval();
	}

	// Token: 0x06017A86 RID: 96902 RVA: 0x0074A600 File Offset: 0x00748A00
	private void OnRemoveBuffEvent(object[] args)
	{
		int num = (int)args[0];
		if (num != this.mChangeBuffID)
		{
			return;
		}
		this.ResotreBuffTimeInterval();
	}

	// Token: 0x04011000 RID: 69632
	protected bool mChangeIntervalByRate;

	// Token: 0x04011001 RID: 69633
	protected int mChangeBuffID;

	// Token: 0x04011002 RID: 69634
	protected BeBuff mChangeBuffInstance;

	// Token: 0x04011003 RID: 69635
	protected VRate mChangeRate = VRate.zero;

	// Token: 0x04011004 RID: 69636
	protected int mChangeRateTime;

	// Token: 0x04011005 RID: 69637
	protected int mChangeTime;
}
