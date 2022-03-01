using System;

// Token: 0x02004222 RID: 16930
public class Buff2000025 : Buff2000020
{
	// Token: 0x06017703 RID: 96003 RVA: 0x0073386F File Offset: 0x00731C6F
	public Buff2000025(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack)
	{
	}

	// Token: 0x06017704 RID: 96004 RVA: 0x00733888 File Offset: 0x00731C88
	public override void OnInit()
	{
		base.OnInit();
		this.flashSummonId = TableManager.GetValueFromUnionCell(this.buffData.ValueD[0], this.level, true);
		this.createEntityInterval = TableManager.GetValueFromUnionCell(this.buffData.ValueE[0], this.level, true);
	}

	// Token: 0x06017705 RID: 96005 RVA: 0x007338EB File Offset: 0x00731CEB
	public override void OnStart()
	{
		base.OnStart();
		this.curCreateEntityTime = this.createEntityInterval;
	}

	// Token: 0x06017706 RID: 96006 RVA: 0x007338FF File Offset: 0x00731CFF
	public void SetEntityTotalTime(int time)
	{
		this.curCreateEntityTime = time;
	}

	// Token: 0x06017707 RID: 96007 RVA: 0x00733908 File Offset: 0x00731D08
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.flashSummonId != 0)
		{
			this.UpdateCreateEntity(deltaTime);
		}
	}

	// Token: 0x06017708 RID: 96008 RVA: 0x00733923 File Offset: 0x00731D23
	private void UpdateCreateEntity(int deltaTime)
	{
		if (this.curCreateEntityTime <= 0)
		{
			this.curCreateEntityTime = this.createEntityInterval;
			base.CreateBoomEntity(this.flashSummonId);
		}
		else
		{
			this.curCreateEntityTime -= deltaTime;
		}
	}

	// Token: 0x06017709 RID: 96009 RVA: 0x0073395C File Offset: 0x00731D5C
	protected override void PassBuff(BeActor target, int time)
	{
		Buff2000025 buff = target.buffController.TryAddBuff(2000025, time, this.level) as Buff2000025;
		if (buff != null)
		{
			this.passFlag = true;
			buff.SetTotalTime(this.curTotalTime);
			buff.SetEntityTotalTime(this.createEntityInterval);
		}
	}

	// Token: 0x04010D3F RID: 68927
	private int flashSummonId;

	// Token: 0x04010D40 RID: 68928
	private int createEntityInterval = 1000;

	// Token: 0x04010D41 RID: 68929
	private int curCreateEntityTime;
}
