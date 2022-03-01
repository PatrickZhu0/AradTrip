using System;

// Token: 0x02004218 RID: 16920
public class Buff16 : BeBuff
{
	// Token: 0x060176C8 RID: 95944 RVA: 0x00732591 File Offset: 0x00730991
	public Buff16(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x060176C9 RID: 95945 RVA: 0x0073259F File Offset: 0x0073099F
	public override void OnStart()
	{
		this.RemoveHanlder();
		this.handler = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			base.Finish();
		});
	}

	// Token: 0x060176CA RID: 95946 RVA: 0x007325C6 File Offset: 0x007309C6
	public override void OnFinish()
	{
		this.RemoveHanlder();
	}

	// Token: 0x060176CB RID: 95947 RVA: 0x007325CE File Offset: 0x007309CE
	private void RemoveHanlder()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x04010D14 RID: 68884
	private BeEventHandle handler;
}
