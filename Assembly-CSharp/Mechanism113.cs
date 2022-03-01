using System;

// Token: 0x020042B8 RID: 17080
internal class Mechanism113 : BeMechanism
{
	// Token: 0x06017A19 RID: 96793 RVA: 0x00747D9C File Offset: 0x0074619C
	public Mechanism113(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017A1A RID: 96794 RVA: 0x00747DA8 File Offset: 0x007461A8
	public override void OnInit()
	{
		this.hasBuffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017A1B RID: 96795 RVA: 0x00747E05 File Offset: 0x00746205
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = args[0] as BeBuff;
			if (beBuff.buffID == this.hasBuffId)
			{
				this.savedBuff = base.owner.buffController.TryAddBuff(this.buffInfoId, base.owner, false, null, 0);
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.hasBuffId)
			{
				base.owner.buffController.RemoveBuff(this.savedBuff);
				this.savedBuff = null;
			}
		});
	}

	// Token: 0x06017A1C RID: 96796 RVA: 0x00747E45 File Offset: 0x00746245
	public override void OnFinish()
	{
		if (this.savedBuff != null)
		{
			base.owner.buffController.RemoveBuff(this.savedBuff);
			this.savedBuff = null;
		}
	}

	// Token: 0x04010FB2 RID: 69554
	private int hasBuffId;

	// Token: 0x04010FB3 RID: 69555
	private int buffInfoId;

	// Token: 0x04010FB4 RID: 69556
	private BeBuff savedBuff;
}
