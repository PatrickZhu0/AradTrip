using System;

// Token: 0x02004387 RID: 17287
public class Mechanism2078 : BeMechanism
{
	// Token: 0x06017F86 RID: 98182 RVA: 0x0076D295 File Offset: 0x0076B695
	public Mechanism2078(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F87 RID: 98183 RVA: 0x0076D29F File Offset: 0x0076B69F
	public override void OnStart()
	{
		base.OnStart();
		this.SetAutoChaser(base.owner, true);
	}

	// Token: 0x06017F88 RID: 98184 RVA: 0x0076D2B4 File Offset: 0x0076B6B4
	public override void OnFinish()
	{
		base.OnFinish();
		this.SetAutoChaser(base.owner, false);
	}

	// Token: 0x06017F89 RID: 98185 RVA: 0x0076D2CC File Offset: 0x0076B6CC
	private void SetAutoChaser(BeActor owner, bool active)
	{
		if (owner == null)
		{
			return;
		}
		BeMechanism mechanism = owner.GetMechanism(Mechanism2072.ChaserMgrID);
		if (mechanism == null)
		{
			return;
		}
		Mechanism2072 mechanism2 = mechanism as Mechanism2072;
		if (mechanism2 != null)
		{
			mechanism2.SetAutoChaserFlag(active, this.level);
		}
	}
}
