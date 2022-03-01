using System;
using GameClient;
using UnityEngine;

// Token: 0x020042C1 RID: 17089
public class Mechanism1143 : BeMechanism
{
	// Token: 0x06017A53 RID: 96851 RVA: 0x0074926B File Offset: 0x0074766B
	public Mechanism1143(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017A54 RID: 96852 RVA: 0x00749278 File Offset: 0x00747678
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.m_HideFuncFlag |= 1 << TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
	}

	// Token: 0x06017A55 RID: 96853 RVA: 0x007492DA File Offset: 0x007476DA
	private void InitSystem()
	{
		this.system = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemBattle);
		if (this.system == null)
		{
			this.system = (Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle);
		}
	}

	// Token: 0x06017A56 RID: 96854 RVA: 0x00749314 File Offset: 0x00747714
	public override void OnStart()
	{
		this.InitSystem();
		if (base.owner != null && base.owner.m_pkGeActor != null)
		{
			if (this.HasFlag(1) && base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Transform) != null)
			{
				base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Transform).CustomActive(false);
			}
			if (this.HasFlag(2) && base.owner.m_pkGeActor.goHPBar != null)
			{
				this.hpBarPos = base.owner.m_pkGeActor.goHPBar.transform.localPosition;
				base.owner.m_pkGeActor.goHPBar.transform.localPosition = new Vector3(0f, -1000f, 0f);
			}
			if (this.HasFlag(3))
			{
				base.owner.m_pkGeActor.SetHeadInfoVisible(false);
			}
			if (this.HasFlag(4))
			{
				base.owner.m_pkGeActor.SetFootIndicatorVisible(false);
			}
			if (this.HasFlag(5) && this.system != null && this.system.MonsterBossRoot != null)
			{
				this.system.MonsterBossRoot.CustomActive(false);
			}
		}
	}

	// Token: 0x06017A57 RID: 96855 RVA: 0x00749470 File Offset: 0x00747870
	public override void OnFinish()
	{
		if (base.owner != null && base.owner.m_pkGeActor != null)
		{
			if (this.HasFlag(1) && base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Transform) != null)
			{
				base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Transform).CustomActive(true);
			}
			if (this.HasFlag(2) && base.owner.m_pkGeActor.goHPBar != null)
			{
				base.owner.m_pkGeActor.goHPBar.transform.localPosition = this.hpBarPos;
			}
			if (this.HasFlag(3))
			{
				base.owner.m_pkGeActor.SetHeadInfoVisible(true);
			}
			if (this.HasFlag(4))
			{
				base.owner.m_pkGeActor.SetFootIndicatorVisible(true);
			}
			if (this.HasFlag(5) && this.system != null && this.system.MonsterBossRoot != null)
			{
				this.system.MonsterBossRoot.CustomActive(true);
			}
		}
	}

	// Token: 0x06017A58 RID: 96856 RVA: 0x00749596 File Offset: 0x00747996
	private bool HasFlag(int flag)
	{
		return (this.m_HideFuncFlag & 1 << flag) != 0;
	}

	// Token: 0x04010FDA RID: 69594
	private int m_HideFuncFlag;

	// Token: 0x04010FDB RID: 69595
	private Vector3 hpBarPos;

	// Token: 0x04010FDC RID: 69596
	private ClientSystemBattle system;

	// Token: 0x020042C2 RID: 17090
	protected enum HideFlag
	{
		// Token: 0x04010FDE RID: 69598
		NONE,
		// Token: 0x04010FDF RID: 69599
		ACTOR,
		// Token: 0x04010FE0 RID: 69600
		HP_BAR,
		// Token: 0x04010FE1 RID: 69601
		HEAD_INFO,
		// Token: 0x04010FE2 RID: 69602
		FOOT_BAR,
		// Token: 0x04010FE3 RID: 69603
		UI_HP_BAR
	}
}
