using System;

// Token: 0x020043E1 RID: 17377
public class Mechanism35 : BeMechanism
{
	// Token: 0x060181CD RID: 98765 RVA: 0x0077EE16 File Offset: 0x0077D216
	public Mechanism35(int mid, int lv) : base(mid, lv)
	{
		this.m_BombEntityId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x060181CE RID: 98766 RVA: 0x0077EE48 File Offset: 0x0077D248
	public override void OnStart()
	{
		this.m_HitOtherHandle = base.owner.RegisterEvent(BeEventType.onCollide, delegate(object[] args)
		{
			BeActor beActor = base.owner.GetOwner() as BeActor;
			if (beActor != null && !beActor.IsDeadOrRemoved())
			{
				beActor.AddEntity(this.m_BombEntityId, base.owner.GetPosition(), 1, 0);
			}
			base.owner.DoDead(false);
			base.owner.m_pkGeActor.SetActorVisible(false);
		});
	}

	// Token: 0x060181CF RID: 98767 RVA: 0x0077EE69 File Offset: 0x0077D269
	public override void OnFinish()
	{
		if (this.m_HitOtherHandle != null)
		{
			this.m_HitOtherHandle.Remove();
		}
	}

	// Token: 0x0401162D RID: 71213
	protected int m_BombEntityId;

	// Token: 0x0401162E RID: 71214
	protected BeEventHandle m_HitOtherHandle;
}
