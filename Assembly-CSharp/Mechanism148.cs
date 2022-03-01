using System;
using UnityEngine;

// Token: 0x0200431D RID: 17181
public class Mechanism148 : BeMechanism
{
	// Token: 0x06017C5F RID: 97375 RVA: 0x00756BF6 File Offset: 0x00754FF6
	public Mechanism148(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C60 RID: 97376 RVA: 0x00756C00 File Offset: 0x00755000
	public override void OnInit()
	{
		base.OnInit();
		this.speed = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f;
		this.accTime = (float)TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) / 1000f;
	}

	// Token: 0x06017C61 RID: 97377 RVA: 0x00756C74 File Offset: 0x00755074
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null || base.owner.m_pkGeActor == null)
		{
			return;
		}
		GameObject entityNode = base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Charactor);
		if (entityNode == null)
		{
			return;
		}
		ScrollAnimator componentInChildren = entityNode.GetComponentInChildren<ScrollAnimator>();
		if (componentInChildren != null)
		{
			componentInChildren.SetSpeed(this.speed, this.accTime);
		}
	}

	// Token: 0x04011194 RID: 70036
	private float speed;

	// Token: 0x04011195 RID: 70037
	private float accTime;

	// Token: 0x04011196 RID: 70038
	private float deccTime;
}
