using System;
using System.Collections.Generic;

// Token: 0x020042C3 RID: 17091
public class Mechanism1149 : BeMechanism
{
	// Token: 0x06017A59 RID: 96857 RVA: 0x007495AB File Offset: 0x007479AB
	public Mechanism1149(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017A5A RID: 96858 RVA: 0x007495B8 File Offset: 0x007479B8
	public override void OnInit()
	{
		base.OnInit();
		this._meiyingValue = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._geDangValue = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this._attackType = (AttackType)TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017A5B RID: 96859 RVA: 0x00749643 File Offset: 0x00747A43
	public override void OnStart()
	{
		base.OnStart();
		this._ChangeMeiYingData(false);
		this._ChangeGeDangData(false);
	}

	// Token: 0x06017A5C RID: 96860 RVA: 0x00749659 File Offset: 0x00747A59
	public override void OnFinish()
	{
		base.OnFinish();
		this._ChangeMeiYingData(true);
		this._ChangeGeDangData(true);
	}

	// Token: 0x06017A5D RID: 96861 RVA: 0x00749670 File Offset: 0x00747A70
	private void _ChangeMeiYingData(bool isRestore = false)
	{
		if (base.owner.GetEntityData() == null)
		{
			return;
		}
		BattleData battleData = base.owner.GetEntityData().battleData;
		if (battleData == null)
		{
			return;
		}
		if (this._meiyingValue <= 0)
		{
			return;
		}
		if (isRestore)
		{
			this.RemoveAddDamage(battleData.reduceMeiyingDamagePercent, this._attackType, this._meiyingValue);
		}
		else
		{
			battleData.reduceMeiyingDamagePercent.Add(new AddDamageInfo(this._meiyingValue, (int)this._attackType));
		}
	}

	// Token: 0x06017A5E RID: 96862 RVA: 0x007496F4 File Offset: 0x00747AF4
	private void RemoveAddDamage(List<AddDamageInfo> list, AttackType type, int value)
	{
		int num = -1;
		for (int i = 0; i < list.Count; i++)
		{
			AddDamageInfo addDamageInfo = list[i];
			if (addDamageInfo.value == value)
			{
				if (addDamageInfo.attackType == type)
				{
					num = i;
					break;
				}
			}
		}
		if (num >= 0)
		{
			list.RemoveAt(num);
		}
	}

	// Token: 0x06017A5F RID: 96863 RVA: 0x00749760 File Offset: 0x00747B60
	private void _ChangeGeDangData(bool isRestore = false)
	{
		if (base.owner.GetEntityData() == null)
		{
			return;
		}
		BattleData battleData = base.owner.GetEntityData().battleData;
		if (battleData == null)
		{
			return;
		}
		if (this._geDangValue <= 0)
		{
			return;
		}
		if (isRestore)
		{
			this.RemoveAddDamage(battleData.reduceGeDangDamagePercent, this._attackType, this._geDangValue);
		}
		else
		{
			battleData.reduceGeDangDamagePercent.Add(new AddDamageInfo(this._geDangValue, (int)this._attackType));
		}
	}

	// Token: 0x04010FE4 RID: 69604
	private int _meiyingValue;

	// Token: 0x04010FE5 RID: 69605
	private int _geDangValue;

	// Token: 0x04010FE6 RID: 69606
	private AttackType _attackType;
}
