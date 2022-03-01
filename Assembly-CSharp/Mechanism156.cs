using System;
using UnityEngine;

// Token: 0x02004324 RID: 17188
public class Mechanism156 : BeMechanism
{
	// Token: 0x06017C83 RID: 97411 RVA: 0x007579A6 File Offset: 0x00755DA6
	public Mechanism156(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C84 RID: 97412 RVA: 0x007579B0 File Offset: 0x00755DB0
	public override void OnInit()
	{
		base.OnInit();
		this.speedRate = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f;
		this.durTime = (float)TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) / 1000f;
	}

	// Token: 0x06017C85 RID: 97413 RVA: 0x00757A24 File Offset: 0x00755E24
	public override void OnStart()
	{
		if (base.owner != null && base.owner.m_pkGeActor != null)
		{
			GameObject entityNode = base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
			if (entityNode != null)
			{
				RotateAnimator componentInChildren = entityNode.GetComponentInChildren<RotateAnimator>();
				if (componentInChildren != null)
				{
					componentInChildren.SetSpeed(this.speedRate, this.durTime);
				}
			}
		}
	}

	// Token: 0x040111B4 RID: 70068
	private float speedRate;

	// Token: 0x040111B5 RID: 70069
	private float durTime;
}
