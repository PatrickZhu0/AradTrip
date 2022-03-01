using System;

// Token: 0x02004365 RID: 17253
public class Mechanism2046 : BeMechanism
{
	// Token: 0x06017E48 RID: 97864 RVA: 0x00763FFD File Offset: 0x007623FD
	public Mechanism2046(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017E49 RID: 97865 RVA: 0x00764020 File Offset: 0x00762420
	public override void OnInit()
	{
		base.OnInit();
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.totalTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.percent = VFactor.NewVFactor(valueFromUnionCell, GlobalLogic.VALUE_1000);
	}

	// Token: 0x06017E4A RID: 97866 RVA: 0x0076408F File Offset: 0x0076248F
	public override void OnStart()
	{
		base.OnStart();
		this.originalScale = base.owner.GetScale();
		this.bStarted = true;
	}

	// Token: 0x06017E4B RID: 97867 RVA: 0x007640B0 File Offset: 0x007624B0
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (!this.bStarted)
		{
			return;
		}
		this.curTime += deltaTime;
		VFactor a = VFactor.NewVFactor(this.curTime, this.totalTime);
		if (a >= VFactor.one)
		{
			a = VFactor.one;
			this.bStarted = false;
		}
		VFactor b = a * this.percent;
		int i = this.originalScale.i * (VFactor.one + b);
		base.owner.SetScale(i);
	}

	// Token: 0x0401131B RID: 70427
	private VFactor percent = VFactor.zero;

	// Token: 0x0401131C RID: 70428
	private int totalTime;

	// Token: 0x0401131D RID: 70429
	private int curTime;

	// Token: 0x0401131E RID: 70430
	private VInt originalScale = VInt.one;

	// Token: 0x0401131F RID: 70431
	private bool bStarted;
}
