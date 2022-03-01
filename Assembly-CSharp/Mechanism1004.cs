using System;

// Token: 0x0200424C RID: 16972
public class Mechanism1004 : BeMechanism
{
	// Token: 0x060177BE RID: 96190 RVA: 0x00738C72 File Offset: 0x00737072
	public Mechanism1004(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177BF RID: 96191 RVA: 0x00738C7C File Offset: 0x0073707C
	public override void OnInit()
	{
		base.OnInit();
		this.time = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.xRange = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.yRange = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mode = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.speed = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
	}

	// Token: 0x060177C0 RID: 96192 RVA: 0x00738D58 File Offset: 0x00737158
	public override void OnStart()
	{
		base.OnStart();
		ShockData sd = default(ShockData);
		sd.time = (float)this.time / 1000f;
		sd.xrange = (float)this.xRange / 1000f;
		sd.yrange = (float)this.yRange / 1000f;
		sd.mode = this.mode;
		sd.speed = (float)this.speed / 1000f;
		base.owner.AddShock(sd);
	}

	// Token: 0x04010DFD RID: 69117
	protected int time;

	// Token: 0x04010DFE RID: 69118
	protected int xRange;

	// Token: 0x04010DFF RID: 69119
	protected int yRange;

	// Token: 0x04010E00 RID: 69120
	protected int mode;

	// Token: 0x04010E01 RID: 69121
	protected int speed;
}
