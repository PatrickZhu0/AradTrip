using System;
using UnityEngine;

// Token: 0x02004282 RID: 17026
public class Mechanism1056 : BeMechanism
{
	// Token: 0x060178F0 RID: 96496 RVA: 0x0074050D File Offset: 0x0073E90D
	public Mechanism1056(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060178F1 RID: 96497 RVA: 0x00740517 File Offset: 0x0073E917
	public override void OnInit()
	{
		base.OnInit();
		this.pos = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f;
	}

	// Token: 0x060178F2 RID: 96498 RVA: 0x00740550 File Offset: 0x0073E950
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner.m_pkGeActor != null)
		{
			base.owner.m_pkGeActor.SetHeadInfoVisible(false);
			this.actorNode = base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor);
			this.actorNode.transform.localPosition = base.owner.m_pkGeActor.GetPosition() + new Vector3(0f, this.pos, 0f);
		}
	}

	// Token: 0x060178F3 RID: 96499 RVA: 0x007405D8 File Offset: 0x0073E9D8
	public override void OnFinish()
	{
		base.OnFinish();
		if (base.owner.m_pkGeActor != null && this.actorNode != null)
		{
			base.owner.m_pkGeActor.SetHeadInfoVisible(true);
			this.actorNode.transform.localPosition = Vector3.zero;
		}
	}

	// Token: 0x04010EDB RID: 69339
	private float pos;

	// Token: 0x04010EDC RID: 69340
	private GameObject actorNode;
}
