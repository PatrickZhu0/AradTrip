using System;

// Token: 0x0200421C RID: 16924
public class Buff183205 : BeBuff
{
	// Token: 0x060176D3 RID: 95955 RVA: 0x007326AD File Offset: 0x00730AAD
	public Buff183205(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x060176D4 RID: 95956 RVA: 0x007326C8 File Offset: 0x00730AC8
	public override void OnStart()
	{
		this.effect1 = base.owner.m_pkGeActor.CreateEffect(this.effectPath, "[actor]LWeapon", 0f, Vec3.zero, 1f, 1f, true, false, EffectTimeType.BUFF, false);
		this.effect2 = base.owner.m_pkGeActor.CreateEffect(this.effectPath, "[actor]RWeapon", 0f, Vec3.zero, 1f, 1f, true, false, EffectTimeType.BUFF, false);
	}

	// Token: 0x060176D5 RID: 95957 RVA: 0x00732748 File Offset: 0x00730B48
	public override void OnFinish()
	{
		if (this.effect1 != null)
		{
			base.owner.m_pkGeActor.DestroyEffect(this.effect1);
			this.effect1 = null;
		}
		if (this.effect2 != null)
		{
			base.owner.m_pkGeActor.DestroyEffect(this.effect2);
			this.effect2 = null;
		}
	}

	// Token: 0x04010D19 RID: 68889
	private string effectPath = "Effects/Hero_Sanda/Eff_Sanda_qiangquan/Prefab/Eff_Sanda_qiangquan_chixu";

	// Token: 0x04010D1A RID: 68890
	private GeEffectEx effect1;

	// Token: 0x04010D1B RID: 68891
	private GeEffectEx effect2;
}
