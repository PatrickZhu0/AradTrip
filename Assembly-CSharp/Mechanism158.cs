using System;

// Token: 0x02004326 RID: 17190
internal class Mechanism158 : BeMechanism
{
	// Token: 0x06017C8B RID: 97419 RVA: 0x00757E1B File Offset: 0x0075621B
	public Mechanism158(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C8C RID: 97420 RVA: 0x00757E25 File Offset: 0x00756225
	public override void OnInit()
	{
		base.OnInit();
		this.isLeft = (TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) == 1);
	}

	// Token: 0x06017C8D RID: 97421 RVA: 0x00757E62 File Offset: 0x00756262
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.isOldLeft = base.owner.GetFace();
			base.owner.SetFace(this.isLeft, true, true);
		}
	}

	// Token: 0x06017C8E RID: 97422 RVA: 0x00757E93 File Offset: 0x00756293
	public override void OnFinish()
	{
		if (base.owner != null)
		{
			base.owner.SetFace(this.isOldLeft, true, true);
		}
	}

	// Token: 0x040111BE RID: 70078
	private bool isLeft;

	// Token: 0x040111BF RID: 70079
	private bool isOldLeft;
}
