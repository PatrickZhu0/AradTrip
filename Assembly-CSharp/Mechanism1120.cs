using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020042B2 RID: 17074
public class Mechanism1120 : BeMechanism
{
	// Token: 0x060179EB RID: 96747 RVA: 0x00746D96 File Offset: 0x00745196
	public Mechanism1120(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179EC RID: 96748 RVA: 0x00746DA0 File Offset: 0x007451A0
	public override void OnInit()
	{
		base.OnInit();
		this.m_EntityId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x060179ED RID: 96749 RVA: 0x00746DD0 File Offset: 0x007451D0
	public override void OnStart()
	{
		base.OnStart();
		this.CreateEntity();
	}

	// Token: 0x060179EE RID: 96750 RVA: 0x00746DE0 File Offset: 0x007451E0
	protected void CreateEntity()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.GetGrabTargetList(list);
		if (list.Count <= 0)
		{
			ListPool<BeActor>.Release(list);
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			base.owner.AddEntity(this.m_EntityId, list[i].GetPosition(), this.level, 0);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x04010F9E RID: 69534
	protected int m_EntityId;
}
