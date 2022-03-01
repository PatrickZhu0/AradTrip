using System;

// Token: 0x020041D7 RID: 16855
public class DelayCallUnit : PooledClassObj
{
	// Token: 0x06017424 RID: 95268 RVA: 0x0072715D File Offset: 0x0072555D
	public void Init(int delayTime, DelayCaller.Del func, int repeatCount = 0, int repeatTime = 0, bool needClear = false)
	{
		this.func = func;
		this.delayTime = delayTime;
		this.repeatCount = repeatCount;
		this.repeatTime = repeatTime;
		this.needCallBeforeClear = needClear;
		this.firstCall = true;
		this.canRemove = false;
	}

	// Token: 0x06017425 RID: 95269 RVA: 0x00727192 File Offset: 0x00725592
	public override void OnReused()
	{
	}

	// Token: 0x06017426 RID: 95270 RVA: 0x00727194 File Offset: 0x00725594
	public override void OnRecycle()
	{
		this.func = null;
		this.delayTime = 0;
		this.tacc = 0;
		this.canRemove = false;
		this.sumtime = 0;
		this.repeatTime = 0;
		this.repeatCount = 0;
		this.firstCall = true;
		this.needCallBeforeClear = false;
		this.id = uint.MaxValue;
	}

	// Token: 0x06017427 RID: 95271 RVA: 0x007271E8 File Offset: 0x007255E8
	public void Update(int delta)
	{
		if (this.canRemove)
		{
			return;
		}
		this.sumtime += delta;
		this.tacc += delta;
		if (this.firstCall && this.tacc >= this.delayTime)
		{
			this.DoCall();
			this.tacc -= this.delayTime;
			this.firstCall = false;
			this.canRemove = (this.repeatCount == 0);
			return;
		}
		if (!this.firstCall && this.repeatCount != 0 && this.tacc >= this.repeatTime)
		{
			this.DoCall();
			this.repeatCount--;
			this.tacc -= this.repeatTime;
			this.canRemove = (this.repeatCount == 0);
			return;
		}
	}

	// Token: 0x06017428 RID: 95272 RVA: 0x007272C7 File Offset: 0x007256C7
	public void DoCall()
	{
		if (this.func != null)
		{
			this.func();
		}
	}

	// Token: 0x06017429 RID: 95273 RVA: 0x007272DF File Offset: 0x007256DF
	public bool CanRemove()
	{
		return this.canRemove;
	}

	// Token: 0x0601742A RID: 95274 RVA: 0x007272E7 File Offset: 0x007256E7
	public void SetRemove(bool flag)
	{
		this.canRemove = flag;
	}

	// Token: 0x0601742B RID: 95275 RVA: 0x007272F0 File Offset: 0x007256F0
	public bool NeedCallBeforeClear()
	{
		return this.needCallBeforeClear;
	}

	// Token: 0x04010BC3 RID: 68547
	protected DelayCaller.Del func;

	// Token: 0x04010BC4 RID: 68548
	protected int delayTime;

	// Token: 0x04010BC5 RID: 68549
	protected int tacc;

	// Token: 0x04010BC6 RID: 68550
	protected bool canRemove;

	// Token: 0x04010BC7 RID: 68551
	protected int sumtime;

	// Token: 0x04010BC8 RID: 68552
	protected int repeatTime;

	// Token: 0x04010BC9 RID: 68553
	protected int repeatCount;

	// Token: 0x04010BCA RID: 68554
	protected bool firstCall = true;

	// Token: 0x04010BCB RID: 68555
	protected bool needCallBeforeClear;

	// Token: 0x04010BCC RID: 68556
	public uint id;
}
