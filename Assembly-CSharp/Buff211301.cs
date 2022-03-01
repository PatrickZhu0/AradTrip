using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x02004224 RID: 16932
public class Buff211301 : BeBuff
{
	// Token: 0x06017710 RID: 96016 RVA: 0x00733C74 File Offset: 0x00732074
	public Buff211301(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x06017711 RID: 96017 RVA: 0x00733CB4 File Offset: 0x007320B4
	public override void OnInit()
	{
		if (BattleMain.IsModePvP(base.battleType))
		{
			this.hpReplacePercent = new VFactor((long)TableManager.GetValueFromUnionCell(this.buffData.ValueD[0], this.level, true), (long)GlobalLogic.VALUE_1000);
			this.hpMpRate = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.buffData.ValueE[0], this.level, true), GlobalLogic.VALUE_1000);
			this.mpRateToDeleteBuff = new VFactor((long)TableManager.GetValueFromUnionCell(this.buffData.ValueF[0], this.level, true), (long)GlobalLogic.VALUE_1000);
		}
		else
		{
			this.hpReplacePercent = new VFactor((long)TableManager.GetValueFromUnionCell(this.buffData.ValueA[0], this.level, true), (long)GlobalLogic.VALUE_1000);
			this.hpMpRate = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.buffData.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
			this.mpRateToDeleteBuff = new VFactor((long)TableManager.GetValueFromUnionCell(this.buffData.ValueC[0], this.level, true), (long)GlobalLogic.VALUE_1000);
		}
		if (this.buffData.ValueG.Count > 0)
		{
			this.lifaMPCostRate = new VFactor((long)TableManager.GetValueFromUnionCell(this.buffData.ValueG[0], this.level, true), (long)GlobalLogic.VALUE_1000);
		}
	}

	// Token: 0x06017712 RID: 96018 RVA: 0x00733E54 File Offset: 0x00732254
	public override void OnStart()
	{
		this.RemoveHandler();
		this.handler = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			int num = (int)args[0];
			base.owner.m_pkGeActor.CreateEffect(Buff211301.effect, "[actor]Orign", 0f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		});
		this.handler2 = base.owner.RegisterEvent(BeEventType.onAfterCalFirstDamage, new BeEventHandle.Del(this.ShareDamage));
		if (!BattleMain.IsModePvP(base.battleType))
		{
			this.UpdateEquipData();
			this.handler3 = base.owner.RegisterEvent(BeEventType.OnChangeWeaponEnd, new BeEventHandle.Del(this.OnChangeWeapon));
			this.mEquipHandle = base.owner.RegisterEventNew(BeEventType.onChangeEquipEnd, new BeEvent.BeEventHandleNew.Function(this.OnChangeEquip));
		}
	}

	// Token: 0x06017713 RID: 96019 RVA: 0x00733EF9 File Offset: 0x007322F9
	protected void OnChangeWeapon(object[] args)
	{
		this.UpdateEquipData();
	}

	// Token: 0x06017714 RID: 96020 RVA: 0x00733F01 File Offset: 0x00732301
	protected void OnChangeEquip(BeEvent.BeEventParam param)
	{
		this.UpdateEquipData();
	}

	// Token: 0x06017715 RID: 96021 RVA: 0x00733F0C File Offset: 0x0073230C
	private void UpdateEquipData()
	{
		this.hpReplaceDeltaPercent = VFactor.zero;
		List<BeMechanism> mechanismList = base.owner.MechanismList;
		if (mechanismList == null)
		{
			return;
		}
		for (int i = 0; i < mechanismList.Count; i++)
		{
			if (mechanismList[i].isRunning)
			{
				Mechanism2094 mechanism = mechanismList[i] as Mechanism2094;
				if (mechanism != null)
				{
					this.hpReplaceDeltaPercent += mechanism.HpReplaceDelta;
				}
			}
		}
	}

	// Token: 0x06017716 RID: 96022 RVA: 0x00733F94 File Offset: 0x00732394
	private void ShareDamage(object[] args)
	{
		int hurtId = (int)args[2];
		if (!BeUtility.NeedShareBySGSH(hurtId, base.owner))
		{
			return;
		}
		if (!(bool)args[1])
		{
			return;
		}
		int[] array = (int[])args[0];
		int num = array[0];
		int num2 = this.DoWork(num);
		array[0] = num - num2;
	}

	// Token: 0x06017717 RID: 96023 RVA: 0x00733FEC File Offset: 0x007323EC
	private int DoWork(int value)
	{
		int num = value * (this.hpReplacePercent + this.hpReplaceDeltaPercent);
		int num2 = num;
		int num3 = num2 * this.hpMpRate.factor;
		if (base.owner.attribute != null && base.owner.attribute.professtion == 32)
		{
			num3 *= this.lifaMPCostRate;
		}
		if (num2 > 0)
		{
			base.owner.DoMPChange(-num3, false);
		}
		if (base.owner.attribute.GetMPRate() < this.mpRateToDeleteBuff)
		{
			base.Cancel();
		}
		return num2;
	}

	// Token: 0x06017718 RID: 96024 RVA: 0x00734095 File Offset: 0x00732495
	public override void OnFinish()
	{
		this.RemoveHandler();
	}

	// Token: 0x06017719 RID: 96025 RVA: 0x007340A0 File Offset: 0x007324A0
	private void RemoveHandler()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
		if (this.handler2 != null)
		{
			this.handler2.Remove();
			this.handler2 = null;
		}
		if (this.handler3 != null)
		{
			this.handler3.Remove();
			this.handler3 = null;
		}
		if (this.mEquipHandle != null)
		{
			this.mEquipHandle.Remove();
			this.mEquipHandle = null;
		}
	}

	// Token: 0x04010D48 RID: 68936
	private static string effect = "Effects/Hero_Mage/Huzhao/Prefab/Eff_Huzhao_beiji";

	// Token: 0x04010D49 RID: 68937
	private VFactor hpReplacePercent;

	// Token: 0x04010D4A RID: 68938
	private VInt hpMpRate = VInt.one;

	// Token: 0x04010D4B RID: 68939
	private VFactor mpRateToDeleteBuff = new VFactor(1L, 10L);

	// Token: 0x04010D4C RID: 68940
	private VFactor hpReplaceDeltaPercent = VFactor.zero;

	// Token: 0x04010D4D RID: 68941
	private VFactor lifaMPCostRate = VFactor.one;

	// Token: 0x04010D4E RID: 68942
	private BeEventHandle handler;

	// Token: 0x04010D4F RID: 68943
	private BeEventHandle handler2;

	// Token: 0x04010D50 RID: 68944
	private BeEventHandle handler3;

	// Token: 0x04010D51 RID: 68945
	private BeEvent.BeEventHandleNew mEquipHandle;
}
