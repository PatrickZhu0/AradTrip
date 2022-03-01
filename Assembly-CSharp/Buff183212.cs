using System;
using GameClient;

// Token: 0x0200421D RID: 16925
internal class Buff183212 : Buff183211
{
	// Token: 0x060176D6 RID: 95958 RVA: 0x00732B13 File Offset: 0x00730F13
	public Buff183212(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack)
	{
	}

	// Token: 0x060176D7 RID: 95959 RVA: 0x00732B34 File Offset: 0x00730F34
	public override void OnUpdate(int delta)
	{
		if (base.owner.battleType == BattleType.Training)
		{
			base.OnUpdate(delta);
			return;
		}
		if (this.in_cd)
		{
			this.acc_pre += delta;
			if (this.acc_pre <= 4000)
			{
				return;
			}
		}
		if (base.owner != null && base.owner.isLocalActor && this.system == null)
		{
			this.system = (Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle);
			if (this.system != null)
			{
				this.system.SetMuscleShiftActive(true);
			}
		}
		if (this.in_cd)
		{
			this.acc += delta;
			if (this.acc < this.initCD)
			{
				if (this.system != null)
				{
					this.system.SetMuscleShiftCD((float)this.acc / (float)this.initCD);
				}
			}
			else
			{
				this.canuse = true;
				if (this.system != null)
				{
					this.system.SetMuscleShiftCount(this.count);
				}
				this.in_cd = false;
			}
		}
		else
		{
			base.OnUpdate(delta);
		}
	}

	// Token: 0x060176D8 RID: 95960 RVA: 0x00732C60 File Offset: 0x00731060
	public override bool CanUseSkill(int curSkillId, int skillId)
	{
		if (base.owner.battleType == BattleType.Training)
		{
			this.canuse = true;
		}
		return base.CanUseSkill(curSkillId, skillId) && this.canuse;
	}

	// Token: 0x04010D1C RID: 68892
	private int initCD = 10000;

	// Token: 0x04010D1D RID: 68893
	private bool canuse;

	// Token: 0x04010D1E RID: 68894
	private bool in_cd = true;

	// Token: 0x04010D1F RID: 68895
	private int acc;

	// Token: 0x04010D20 RID: 68896
	private int acc_pre;
}
