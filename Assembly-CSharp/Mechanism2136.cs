using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020043C5 RID: 17349
public class Mechanism2136 : BeMechanism
{
	// Token: 0x0601810E RID: 98574 RVA: 0x0077967E File Offset: 0x00777A7E
	public Mechanism2136(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601810F RID: 98575 RVA: 0x007796AC File Offset: 0x00777AAC
	public override void OnInit()
	{
		base.OnInit();
		this._registerRemoveBuffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._ignoreDamageBuffId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this._removeBuffIdList.Clear();
		for (int i = 0; i < this.data.ValueC.Count; i++)
		{
			this._removeBuffIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true));
		}
		this._addBuffDataList.Clear();
		for (int j = 0; j < this.data.ValueD.Count; j++)
		{
			Mechanism2136.AddBuffData item = default(Mechanism2136.AddBuffData);
			item.BuffId = TableManager.GetValueFromUnionCell(this.data.ValueD[j], this.level, true);
			item.BuffCount = TableManager.GetValueFromUnionCell(this.data.ValueE[j], this.level, true);
			item.BuffTime = TableManager.GetValueFromUnionCell(this.data.ValueF[j], this.level, true);
			this._addBuffDataList.Add(item);
		}
		this._absorbDamageMaxPercent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06018110 RID: 98576 RVA: 0x00779855 File Offset: 0x00777C55
	public override void OnStart()
	{
		base.OnStart();
		this._AddBuffList();
		this._RegisterEvent();
		this._InitData();
	}

	// Token: 0x06018111 RID: 98577 RVA: 0x0077986F File Offset: 0x00777C6F
	private void _InitData()
	{
		if (base.owner.attribute == null)
		{
			return;
		}
		this._absorbDamageMaxValue = base.owner.attribute.GetMaxHP() * this._absorbDamageMaxPercent;
	}

	// Token: 0x06018112 RID: 98578 RVA: 0x007798A4 File Offset: 0x00777CA4
	private void _AddBuffList()
	{
		for (int i = 0; i < this._addBuffDataList.Count; i++)
		{
			Mechanism2136.AddBuffData addBuffData = this._addBuffDataList[i];
			for (int j = 0; j < addBuffData.BuffCount; j++)
			{
				base.owner.buffController.TryAddBuff(addBuffData.BuffId, addBuffData.BuffTime, this.level);
			}
		}
	}

	// Token: 0x06018113 RID: 98579 RVA: 0x0077991C File Offset: 0x00777D1C
	private void _RegisterEvent()
	{
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onShengguangshouhuAbsorbDamage, new BeEvent.BeEventHandleNew.Function(this._OnShengguangshouhuAbsorbDamage));
		this.handleA = base.owner.RegisterEvent(BeEventType.onBuffCancel, new BeEventHandle.Del(this._OnBuffCancel));
	}

	// Token: 0x06018114 RID: 98580 RVA: 0x00779970 File Offset: 0x00777D70
	private void _OnShengguangshouhuAbsorbDamage(BeEvent.BeEventParam param)
	{
		if (this._ignoreDamageBuffId <= 0)
		{
			return;
		}
		if (base.owner.buffController.GetBuffCountByID(this._ignoreDamageBuffId) <= 0)
		{
			return;
		}
		if (param.m_Int >= this._absorbDamageMaxValue)
		{
			param.m_Int -= this._absorbDamageMaxValue;
			param.m_Bool = false;
		}
		else
		{
			param.m_Bool = true;
		}
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle != null)
		{
			clientSystemBattle.comShowHit.ShowBuffText("物理免疫", base.owner.m_iID, base.owner.GetGePosition(PositionType.OVERHEAD), base.owner);
		}
		base.owner.buffController.RemoveBuff(this._ignoreDamageBuffId, 1, 0);
	}

	// Token: 0x06018115 RID: 98581 RVA: 0x00779A3C File Offset: 0x00777E3C
	private void _OnBuffCancel(object[] args)
	{
		int num = (int)args[0];
		if (num != this._registerRemoveBuffId)
		{
			return;
		}
		for (int i = 0; i < this._removeBuffIdList.Count; i++)
		{
			base.owner.buffController.RemoveBuff(this._removeBuffIdList[i], 0, 0);
		}
	}

	// Token: 0x04011577 RID: 71031
	private int _registerRemoveBuffId;

	// Token: 0x04011578 RID: 71032
	private int _ignoreDamageBuffId;

	// Token: 0x04011579 RID: 71033
	private List<int> _removeBuffIdList = new List<int>();

	// Token: 0x0401157A RID: 71034
	private List<Mechanism2136.AddBuffData> _addBuffDataList = new List<Mechanism2136.AddBuffData>();

	// Token: 0x0401157B RID: 71035
	private VFactor _absorbDamageMaxPercent = VFactor.zero;

	// Token: 0x0401157C RID: 71036
	private int _absorbDamageMaxValue;

	// Token: 0x020043C6 RID: 17350
	private struct AddBuffData
	{
		// Token: 0x0401157D RID: 71037
		public int BuffId;

		// Token: 0x0401157E RID: 71038
		public int BuffCount;

		// Token: 0x0401157F RID: 71039
		public int BuffTime;
	}
}
