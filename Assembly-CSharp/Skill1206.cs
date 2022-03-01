using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x0200444F RID: 17487
public class Skill1206 : BeSkill
{
	// Token: 0x06018460 RID: 99424 RVA: 0x0078EC8F File Offset: 0x0078D08F
	public Skill1206(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018461 RID: 99425 RVA: 0x0078EC9C File Offset: 0x0078D09C
	public override void OnInit()
	{
		base.OnInit();
		this.weaponType = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.effectSkills = BeSkill.GetEffectSkills(this.skillData.ValueB, base.level);
		this.buffInfoID = ((!BattleMain.IsModePvP(base.battleType)) ? TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true));
	}

	// Token: 0x06018462 RID: 99426 RVA: 0x0078ED43 File Offset: 0x0078D143
	public override void OnPostInit()
	{
		this.RemoveHandle();
		if (base.owner != null && base.owner.GetWeaponType() == this.weaponType)
		{
			this.DoEffect();
		}
	}

	// Token: 0x06018463 RID: 99427 RVA: 0x0078ED72 File Offset: 0x0078D172
	public override void OnWeaponChange()
	{
		this.OnPostInit();
	}

	// Token: 0x06018464 RID: 99428 RVA: 0x0078ED7A File Offset: 0x0078D17A
	private void RemoveHandle()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x06018465 RID: 99429 RVA: 0x0078ED99 File Offset: 0x0078D199
	private void DoEffect()
	{
		this.handler = base.owner.RegisterEvent(BeEventType.onCastSkill, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num != 0 && this.effectSkills != null && this.effectSkills.Contains(num) && this.buffInfoID != 0)
			{
				BuffInfoData info = new BuffInfoData(this.buffInfoID, base.level, 0);
				BeBuff beBuff = base.owner.buffController.TryAddBuff(info, null, false, default(VRate), null);
				if (beBuff != null)
				{
					int buffCountByID = base.owner.buffController.GetBuffCountByID(beBuff.buffID);
					this.UpdateBuffInfo(false, buffCountByID);
					beBuff.RegisterEvent(BeEventType.onBuffFinish, delegate(object[] args2)
					{
						int buffID = (int)args2[0];
						int num2 = base.owner.buffController.GetBuffCountByID(buffID);
						num2--;
						this.UpdateBuffInfo(false, num2);
					});
				}
			}
		});
	}

	// Token: 0x06018466 RID: 99430 RVA: 0x0078EDBC File Offset: 0x0078D1BC
	private void UpdateBuffInfo(bool hide = false, int num = 0)
	{
		if (base.owner != null && base.owner.isLocalActor)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.SetBuffNum(num);
			}
		}
	}

	// Token: 0x04011837 RID: 71735
	private int weaponType;

	// Token: 0x04011838 RID: 71736
	private List<int> effectSkills;

	// Token: 0x04011839 RID: 71737
	private int buffInfoID;

	// Token: 0x0401183A RID: 71738
	private BeEventHandle handler;
}
