using System;
using System.Collections.Generic;

// Token: 0x02004253 RID: 16979
public class Mechanism1014 : BeMechanism
{
	// Token: 0x060177E4 RID: 96228 RVA: 0x00739EB7 File Offset: 0x007382B7
	public Mechanism1014(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177E5 RID: 96229 RVA: 0x00739ECC File Offset: 0x007382CC
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor != null && !this.list.Contains(beActor) && beActor.protectManager.IsEnable())
			{
				this.list.Add(beActor);
				if (beActor.protectManager != null)
				{
					beActor.protectManager.SetEnable(false);
				}
			}
		});
	}

	// Token: 0x060177E6 RID: 96230 RVA: 0x00739EF3 File Offset: 0x007382F3
	public override void OnDead()
	{
		base.OnDead();
		this.ContinueProtect();
	}

	// Token: 0x060177E7 RID: 96231 RVA: 0x00739F01 File Offset: 0x00738301
	public override void OnFinish()
	{
		base.OnFinish();
		this.ContinueProtect();
	}

	// Token: 0x060177E8 RID: 96232 RVA: 0x00739F10 File Offset: 0x00738310
	private void ContinueProtect()
	{
		for (int i = 0; i < this.list.Count; i++)
		{
			if (this.list[i].protectManager != null)
			{
				this.list[i].protectManager.SetEnable(true);
			}
		}
	}

	// Token: 0x04010E1A RID: 69146
	private List<BeActor> list = new List<BeActor>();
}
