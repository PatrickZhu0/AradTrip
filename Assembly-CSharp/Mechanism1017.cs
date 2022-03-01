using System;
using System.Collections.Generic;

// Token: 0x02004256 RID: 16982
public class Mechanism1017 : BeMechanism
{
	// Token: 0x060177F4 RID: 96244 RVA: 0x0073A5EB File Offset: 0x007389EB
	public Mechanism1017(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177F5 RID: 96245 RVA: 0x0073A600 File Offset: 0x00738A00
	public override void OnInit()
	{
		base.OnInit();
		this.InitData();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			int num = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true) - 1;
			this.addValueArr[num] = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			this.coefficientArr[num] = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
			this.selfExtraAddRateArr[num] = TableManager.GetValueFromUnionCell(this.data.ValueD[i], this.level, true);
		}
		for (int j = 0; j < this.data.ValueE.Count; j++)
		{
			this.coeffSpecialList.Add(TableManager.GetValueFromUnionCell(this.data.ValueE[j], this.level, true));
		}
	}

	// Token: 0x060177F6 RID: 96246 RVA: 0x0073A72C File Offset: 0x00738B2C
	private void InitData()
	{
		this.typeCount = 12;
		this.addValueArr = new int[this.typeCount];
		this.coefficientArr = new int[this.typeCount];
		this.selfExtraAddRateArr = new int[this.typeCount];
		this.equipAddValueArr = new int[this.typeCount];
		this.equipAddRateArr = new int[this.typeCount];
	}

	// Token: 0x060177F7 RID: 96247 RVA: 0x0073A796 File Offset: 0x00738B96
	public override void OnStart()
	{
		this.SetBuffReleaser();
		this.InitExtraAdd();
		this.SetEquipDataAdd();
		this.ChangeAttr();
	}

	// Token: 0x060177F8 RID: 96248 RVA: 0x0073A7B0 File Offset: 0x00738BB0
	public override void OnFinish()
	{
		this.Recover();
	}

	// Token: 0x060177F9 RID: 96249 RVA: 0x0073A7B8 File Offset: 0x00738BB8
	private void SetBuffReleaser()
	{
		if (this.attachBuff == null)
		{
			return;
		}
		this.attachBuffReleaser = this.attachBuff.releaser;
	}

	// Token: 0x060177FA RID: 96250 RVA: 0x0073A7D8 File Offset: 0x00738BD8
	private void InitExtraAdd()
	{
		for (int i = 0; i < this.typeCount; i++)
		{
			if (this.attachBuffReleaser != null && this.attachBuffReleaser != base.owner)
			{
				this.selfExtraAddRateArr[i] = GlobalLogic.VALUE_1000;
			}
		}
	}

	// Token: 0x060177FB RID: 96251 RVA: 0x0073A828 File Offset: 0x00738C28
	private void ChangeAttr()
	{
		if (this.attachBuffReleaser == null || this.attachBuffReleaser.GetEntityData() == null || this.attachBuffReleaser.GetEntityData().battleData == null)
		{
			return;
		}
		this.recoverValueArr = new int[this.typeCount];
		for (int i = 0; i < this.typeCount; i++)
		{
			Mechanism1017.ChangeAttType changeAttType = i + Mechanism1017.ChangeAttType.HPMaxAdd;
			Mechanism1017.EffectType effectType = (!this.IsEffectBySta(changeAttType)) ? Mechanism1017.EffectType.Spr : Mechanism1017.EffectType.Sta;
			int effectValue = this.GetEffectValue(effectType, this.attachBuffReleaser);
			VFactor vfactor = VFactor.zero;
			if (this.coefficientArr[i] != 0)
			{
				vfactor = new VFactor((long)effectValue, (long)this.coefficientArr[i]);
			}
			vfactor += VFactor.one;
			vfactor *= this.GetSpecialCoff(i, effectType);
			vfactor *= new VFactor((long)this.selfExtraAddRateArr[i], (long)GlobalLogic.VALUE_1000);
			int num = this.addValueArr[i];
			num = this.EquipAdd(i, num, !this.IsNeedPriorityCalc(changeAttType));
			if (vfactor != 0L)
			{
				num *= vfactor;
			}
			num = this.EquipAdd(i, num, this.IsNeedPriorityCalc(changeAttType));
			if (num != 0)
			{
				this.recoverValueArr[i] = num;
				this.ChangeDataByType(changeAttType, this.recoverValueArr[i]);
			}
		}
	}

	// Token: 0x060177FC RID: 96252 RVA: 0x0073A988 File Offset: 0x00738D88
	private VFactor GetSpecialCoff(int index, Mechanism1017.EffectType type)
	{
		if (index >= this.coeffSpecialList.Count)
		{
			return VFactor.one;
		}
		int effectValue = this.GetEffectValue(type, base.owner);
		VFactor zero = VFactor.zero;
		if (this.coeffSpecialList[index] != 0)
		{
			zero = new VFactor((long)effectValue, (long)this.coeffSpecialList[index]);
		}
		return zero + VFactor.one;
	}

	// Token: 0x060177FD RID: 96253 RVA: 0x0073A9F4 File Offset: 0x00738DF4
	private int EquipAdd(int index, int value, bool needCalc)
	{
		if (!needCalc)
		{
			return value;
		}
		VFactor f = new VFactor((long)this.equipAddRateArr[index], (long)GlobalLogic.VALUE_1000);
		int num = value + value * f;
		return num + this.equipAddValueArr[index];
	}

	// Token: 0x060177FE RID: 96254 RVA: 0x0073AA38 File Offset: 0x00738E38
	private void Recover()
	{
		if (this.recoverValueArr == null)
		{
			return;
		}
		for (int i = 0; i < this.typeCount; i++)
		{
			Mechanism1017.ChangeAttType changeAttType = i + Mechanism1017.ChangeAttType.HPMaxAdd;
			if (changeAttType != Mechanism1017.ChangeAttType.Hp && changeAttType != Mechanism1017.ChangeAttType.Mp)
			{
				if (this.recoverValueArr[i] != 0)
				{
					this.ChangeDataByType(changeAttType, -this.recoverValueArr[i]);
				}
			}
		}
	}

	// Token: 0x060177FF RID: 96255 RVA: 0x0073AAA4 File Offset: 0x00738EA4
	private void ChangeDataByType(Mechanism1017.ChangeAttType changeType, int addValue)
	{
		if (base.owner == null || base.owner.GetEntityData() == null || base.owner.GetEntityData().battleData == null)
		{
			return;
		}
		BeEntityData entityData = base.owner.GetEntityData();
		BattleData battleData = base.owner.GetEntityData().battleData;
		bool add = true;
		switch (changeType)
		{
		case Mechanism1017.ChangeAttType.HPMaxAdd:
			entityData.ChangeMaxHp(addValue);
			this.DoSyncHPBar(base.owner);
			break;
		case Mechanism1017.ChangeAttType.MPMaxAdd:
			battleData.ChangeMaxMP(addValue);
			this.DoSyncHPBar(base.owner);
			break;
		case Mechanism1017.ChangeAttType.PhysicalDefenceAdd:
			battleData.SetValue(AttributeType.defence, addValue, add);
			break;
		case Mechanism1017.ChangeAttType.MagicDefenceAdd:
			battleData.SetValue(AttributeType.magicDefence, addValue, add);
			break;
		case Mechanism1017.ChangeAttType.AtkAdd:
			battleData.SetValue(AttributeType.baseAtk, addValue * GlobalLogic.VALUE_1000, add);
			break;
		case Mechanism1017.ChangeAttType.IntAdd:
			battleData.SetValue(AttributeType.baseInt, addValue * GlobalLogic.VALUE_1000, add);
			break;
		case Mechanism1017.ChangeAttType.Hp:
			base.owner.DoHPChange(addValue, true);
			break;
		case Mechanism1017.ChangeAttType.Mp:
			base.owner.DoMPChange(addValue, false);
			break;
		case Mechanism1017.ChangeAttType.PhysicalAttackAdd:
			battleData.SetValue(AttributeType.attack, addValue, add);
			break;
		case Mechanism1017.ChangeAttType.MagicAttackAdd:
			battleData.SetValue(AttributeType.magicAttack, addValue, add);
			break;
		case Mechanism1017.ChangeAttType.HpRecover:
			entityData.SetAttributeValue(AttributeType.hpRecover, addValue, add);
			battleData.hpRecover = base.owner.GetEntityData().battleData.fHpRecoer;
			break;
		case Mechanism1017.ChangeAttType.MpRecover:
			entityData.SetAttributeValue(AttributeType.mpRecover, addValue, add);
			battleData.mpRecover = base.owner.GetEntityData().battleData.fMpRecover;
			break;
		}
	}

	// Token: 0x06017800 RID: 96256 RVA: 0x0073AC50 File Offset: 0x00739050
	private int GetEffectValue(Mechanism1017.EffectType effectType, BeActor sourceActor)
	{
		if (sourceActor == null || sourceActor.IsDead() || sourceActor.GetEntityData() == null)
		{
			return 0;
		}
		BattleData battleData = sourceActor.GetEntityData().battleData;
		if (battleData == null)
		{
			return 0;
		}
		int result = 0;
		if (effectType == Mechanism1017.EffectType.Sta)
		{
			result = battleData.sta * VFactor.NewVFactor(GlobalLogic.VALUE_1, GlobalLogic.VALUE_1000);
		}
		else if (effectType == Mechanism1017.EffectType.Spr)
		{
			result = battleData.spr * VFactor.NewVFactor(GlobalLogic.VALUE_1, GlobalLogic.VALUE_1000);
		}
		return result;
	}

	// Token: 0x06017801 RID: 96257 RVA: 0x0073ACDB File Offset: 0x007390DB
	protected void DoSyncHPBar(BeActor actor)
	{
		if (actor != null && actor.m_pkGeActor != null)
		{
			actor.m_pkGeActor.SyncHPBar();
		}
	}

	// Token: 0x06017802 RID: 96258 RVA: 0x0073ACF9 File Offset: 0x007390F9
	private bool IsNeedPriorityCalc(Mechanism1017.ChangeAttType type)
	{
		return type == Mechanism1017.ChangeAttType.HPMaxAdd || type == Mechanism1017.ChangeAttType.MPMaxAdd || type == Mechanism1017.ChangeAttType.HpRecover || type == Mechanism1017.ChangeAttType.MpRecover;
	}

	// Token: 0x06017803 RID: 96259 RVA: 0x0073AD1C File Offset: 0x0073911C
	private bool IsEffectBySta(Mechanism1017.ChangeAttType type)
	{
		return type == Mechanism1017.ChangeAttType.HPMaxAdd || type == Mechanism1017.ChangeAttType.PhysicalDefenceAdd || type == Mechanism1017.ChangeAttType.AtkAdd || type == Mechanism1017.ChangeAttType.Hp || type == Mechanism1017.ChangeAttType.PhysicalAttackAdd || type == Mechanism1017.ChangeAttType.HpRecover;
	}

	// Token: 0x06017804 RID: 96260 RVA: 0x0073AD50 File Offset: 0x00739150
	private void SetEquipDataAdd()
	{
		BeActor beActor = base.GetAttachBuffReleaser();
		if (beActor == null)
		{
			return;
		}
		List<BeMechanism> mechanismList = beActor.MechanismList;
		if (mechanismList == null)
		{
			return;
		}
		this.equipAddValueArr = new int[this.typeCount];
		this.equipAddRateArr = new int[this.typeCount];
		for (int i = 0; i < mechanismList.Count; i++)
		{
			Mechanism2027 mechanism = mechanismList[i] as Mechanism2027;
			if (mechanism != null)
			{
				if (beActor.sgGetCurrentState() == 14 && mechanism.IsContainSkillID(beActor.GetCurSkillID()))
				{
					for (int j = 0; j < this.typeCount; j++)
					{
						this.equipAddValueArr[j] += mechanism.addValueArr[j];
						this.equipAddRateArr[j] += mechanism.addRateArr[j];
						if (this.selfExtraAddRateArr[j] == 0)
						{
							this.selfExtraAddRateArr[j] += mechanism.selfExtraAddRateArr[j];
						}
						if (this.coefficientArr[j] == 0)
						{
							this.coefficientArr[j] += mechanism.coefficientArr[j];
						}
					}
				}
			}
		}
	}

	// Token: 0x06017805 RID: 96261 RVA: 0x0073AE87 File Offset: 0x00739287
	public int[] GetRecoverValueArr()
	{
		return this.recoverValueArr;
	}

	// Token: 0x04010E26 RID: 69158
	private int typeCount;

	// Token: 0x04010E27 RID: 69159
	private int[] addValueArr;

	// Token: 0x04010E28 RID: 69160
	private int[] coefficientArr;

	// Token: 0x04010E29 RID: 69161
	private int[] selfExtraAddRateArr;

	// Token: 0x04010E2A RID: 69162
	private List<int> coeffSpecialList = new List<int>();

	// Token: 0x04010E2B RID: 69163
	private int[] recoverValueArr;

	// Token: 0x04010E2C RID: 69164
	private BeActor attachBuffReleaser;

	// Token: 0x04010E2D RID: 69165
	private int[] equipAddValueArr;

	// Token: 0x04010E2E RID: 69166
	private int[] equipAddRateArr;

	// Token: 0x02004257 RID: 16983
	public enum ChangeAttType
	{
		// Token: 0x04010E30 RID: 69168
		None,
		// Token: 0x04010E31 RID: 69169
		HPMaxAdd,
		// Token: 0x04010E32 RID: 69170
		MPMaxAdd,
		// Token: 0x04010E33 RID: 69171
		PhysicalDefenceAdd,
		// Token: 0x04010E34 RID: 69172
		MagicDefenceAdd,
		// Token: 0x04010E35 RID: 69173
		AtkAdd,
		// Token: 0x04010E36 RID: 69174
		IntAdd,
		// Token: 0x04010E37 RID: 69175
		Hp,
		// Token: 0x04010E38 RID: 69176
		Mp,
		// Token: 0x04010E39 RID: 69177
		PhysicalAttackAdd,
		// Token: 0x04010E3A RID: 69178
		MagicAttackAdd,
		// Token: 0x04010E3B RID: 69179
		HpRecover,
		// Token: 0x04010E3C RID: 69180
		MpRecover,
		// Token: 0x04010E3D RID: 69181
		Count
	}

	// Token: 0x02004258 RID: 16984
	private enum EffectType
	{
		// Token: 0x04010E3F RID: 69183
		None,
		// Token: 0x04010E40 RID: 69184
		Sta,
		// Token: 0x04010E41 RID: 69185
		Spr
	}
}
