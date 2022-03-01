using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x02004413 RID: 17427
public class Mechanism80 : BeMechanism
{
	// Token: 0x06018331 RID: 99121 RVA: 0x00788796 File Offset: 0x00786B96
	public Mechanism80(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018332 RID: 99122 RVA: 0x007887AC File Offset: 0x00786BAC
	public override void OnInit()
	{
		this.jobID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.weaponType = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		for (int i = 0; i < this.data.ValueC.Count; i++)
		{
			this.buffInfoList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true));
		}
	}

	// Token: 0x06018333 RID: 99123 RVA: 0x00788857 File Offset: 0x00786C57
	public override void OnPostInit()
	{
		base.OnPostInit();
	}

	// Token: 0x06018334 RID: 99124 RVA: 0x00788860 File Offset: 0x00786C60
	public override void OnStart()
	{
		base.OnStart();
		this.handle = base.owner.RegisterEvent(BeEventType.OnChangeWeapon, new BeEventHandle.Del(this.OnChangeWeapon));
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onChangeEquipEnd, new BeEvent.BeEventHandleNew.Function(this.OnChangeEquip));
		this.SetTriggerBuff();
	}

	// Token: 0x06018335 RID: 99125 RVA: 0x007888B7 File Offset: 0x00786CB7
	protected void OnChangeWeapon(object[] args)
	{
		this.SetTriggerBuff();
	}

	// Token: 0x06018336 RID: 99126 RVA: 0x007888BF File Offset: 0x00786CBF
	protected void OnChangeEquip(BeEvent.BeEventParam param)
	{
		this.SetTriggerBuff();
	}

	// Token: 0x06018337 RID: 99127 RVA: 0x007888C8 File Offset: 0x00786CC8
	private void SetTriggerBuff()
	{
		this.RemoveTriggerBuff();
		int num = base.owner.GetWeaponType();
		int num2 = (num != 0) ? num : base.owner.GetDefaultWeaponType();
		if (base.owner.professionID != 0 && this.weaponType != 0)
		{
			if (base.owner.professionID == this.jobID && this.weaponType == num2)
			{
				this.AddTriggerBuff();
			}
		}
		else if (base.owner.professionID == 0 && this.weaponType != 0)
		{
			if (this.weaponType == num2)
			{
				this.AddTriggerBuff();
			}
		}
		else if (this.weaponType == 0 && base.owner.professionID != 0 && this.jobID == base.owner.professionID)
		{
			this.AddTriggerBuff();
		}
	}

	// Token: 0x06018338 RID: 99128 RVA: 0x007889B0 File Offset: 0x00786DB0
	public override void OnFinish()
	{
		base.OnFinish();
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x06018339 RID: 99129 RVA: 0x007889D8 File Offset: 0x00786DD8
	private void AddTriggerBuff()
	{
		for (int i = 0; i < this.buffInfoList.Count; i++)
		{
			BuffInfoData buffInfoData = new BuffInfoData(this.buffInfoList[i], this.level, 0);
			if (buffInfoData.condition <= BuffCondition.NONE)
			{
				base.owner.buffController.TryAddBuff(buffInfoData, null, false, default(VRate), null);
			}
			else
			{
				base.owner.buffController.AddTriggerBuff(buffInfoData);
			}
		}
	}

	// Token: 0x0601833A RID: 99130 RVA: 0x00788A60 File Offset: 0x00786E60
	private void RemoveTriggerBuff()
	{
		for (int i = 0; i < this.buffInfoList.Count; i++)
		{
			BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(this.buffInfoList[i], string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.BuffCondition <= 0)
				{
					base.owner.buffController.RemoveBuff(tableItem.BuffID, 0, 0);
				}
				else
				{
					base.owner.buffController.RemoveTriggerBuff(this.buffInfoList[i]);
				}
			}
		}
	}

	// Token: 0x04011778 RID: 71544
	private int jobID;

	// Token: 0x04011779 RID: 71545
	private int weaponType;

	// Token: 0x0401177A RID: 71546
	private List<int> buffInfoList = new List<int>();

	// Token: 0x0401177B RID: 71547
	private BeEventHandle handle;
}
