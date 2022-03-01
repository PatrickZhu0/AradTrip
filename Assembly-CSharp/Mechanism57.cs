using System;

// Token: 0x020043F8 RID: 17400
public class Mechanism57 : BeMechanism
{
	// Token: 0x0601826F RID: 98927 RVA: 0x0078348F File Offset: 0x0078188F
	public Mechanism57(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018270 RID: 98928 RVA: 0x00783499 File Offset: 0x00781899
	public override void OnStart()
	{
		this.RemoveHandle();
		this.handle = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
		{
			BeProjectile beProjectile = args[0] as BeProjectile;
			if (beProjectile != null && beProjectile.IsGenRune())
			{
				base.owner.TriggerEvent(BeEventType.onAddRune, null);
			}
		});
	}

	// Token: 0x06018271 RID: 98929 RVA: 0x007834C0 File Offset: 0x007818C0
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x06018272 RID: 98930 RVA: 0x007834C8 File Offset: 0x007818C8
	protected void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x040116C2 RID: 71362
	protected BeEventHandle handle;
}
