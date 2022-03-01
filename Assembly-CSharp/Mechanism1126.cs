using System;
using UnityEngine;

// Token: 0x020042B5 RID: 17077
public class Mechanism1126 : BeMechanism
{
	// Token: 0x060179FB RID: 96763 RVA: 0x0074732B File Offset: 0x0074572B
	public Mechanism1126(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179FC RID: 96764 RVA: 0x00747340 File Offset: 0x00745740
	public override void OnInit()
	{
		base.OnInit();
		this.m_EffectPath = this.data.StringValueA[0];
		this.m_AttchNodeName = this.data.StringValueA[1];
		this.m_OffsetPos.x = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_OffsetPos.y = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		this.m_OffsetPos.z = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[2], this.level, true);
	}

	// Token: 0x060179FD RID: 96765 RVA: 0x0074740B File Offset: 0x0074580B
	public override void OnStart()
	{
		base.OnStart();
		this.CreateEffect();
	}

	// Token: 0x060179FE RID: 96766 RVA: 0x00747419 File Offset: 0x00745819
	public override void OnFinish()
	{
		base.OnFinish();
		this.RecyleEffect();
	}

	// Token: 0x060179FF RID: 96767 RVA: 0x00747428 File Offset: 0x00745828
	protected void CreateEffect()
	{
		if (base.owner.m_pkGeActor == null)
		{
			return;
		}
		this.m_Effect = base.owner.m_pkGeActor.CreateEffect(this.m_EffectPath, this.m_AttchNodeName, 1E+10f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		this.m_OffsetPos.x = this.m_OffsetPos.x / 1000f;
		this.m_OffsetPos.y = this.m_OffsetPos.y / 1000f;
		this.m_OffsetPos.z = this.m_OffsetPos.z / 1000f;
		this.m_Effect.SetLocalPosition(this.m_OffsetPos);
	}

	// Token: 0x06017A00 RID: 96768 RVA: 0x007474D6 File Offset: 0x007458D6
	protected void RecyleEffect()
	{
		if (this.m_Effect == null)
		{
			return;
		}
		this.m_Effect.Remove();
		this.m_Effect = null;
	}

	// Token: 0x04010FA6 RID: 69542
	protected string m_EffectPath;

	// Token: 0x04010FA7 RID: 69543
	protected string m_AttchNodeName;

	// Token: 0x04010FA8 RID: 69544
	protected Vector3 m_OffsetPos = Vector3.zero;

	// Token: 0x04010FA9 RID: 69545
	protected GeEffectEx m_Effect;
}
