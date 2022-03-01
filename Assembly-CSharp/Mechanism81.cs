using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x02004414 RID: 17428
public class Mechanism81 : BeMechanism
{
	// Token: 0x0601833B RID: 99131 RVA: 0x00788AF8 File Offset: 0x00786EF8
	public Mechanism81(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601833C RID: 99132 RVA: 0x00788B34 File Offset: 0x00786F34
	public override void OnInit()
	{
		this.pveBuffList.Clear();
		this.pvpBuffList.Clear();
		this.changeWeaponCD = new VRate((float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			if (valueFromUnionCell != 0)
			{
				this.pveBuffList.Add(valueFromUnionCell);
			}
		}
		for (int j = 0; j < this.data.ValueC.Count; j++)
		{
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true);
			if (valueFromUnionCell2 != 0)
			{
				this.pvpBuffList.Add(valueFromUnionCell2);
			}
		}
	}

	// Token: 0x0601833D RID: 99133 RVA: 0x00788C37 File Offset: 0x00787037
	public override void OnStart()
	{
		this.changeWeaponHandle = base.owner.RegisterEvent(BeEventType.OnChangeWeapon, delegate(object[] args)
		{
			if (args.Length != 2)
			{
				return;
			}
			ItemTable itemTable = args[0] as ItemTable;
			ItemTable itemTable2 = args[1] as ItemTable;
			if (itemTable == null || itemTable2 == null)
			{
				return;
			}
			if (itemTable.ThirdType != itemTable2.ThirdType)
			{
				List<int> list = (!BattleMain.IsModePvP(base.battleType)) ? this.pveBuffList : this.pvpBuffList;
				for (int i = 0; i < list.Count; i++)
				{
					BuffInfoData info = new BuffInfoData(this.pvpBuffList[i], this.level, 0);
					base.owner.buffController.TryAddBuff(info, null, false, default(VRate), null);
				}
			}
		});
	}

	// Token: 0x0601833E RID: 99134 RVA: 0x00788C58 File Offset: 0x00787058
	public override void OnFinish()
	{
		base.OnFinish();
		if (this.changeWeaponHandle != null)
		{
			this.changeWeaponHandle.Remove();
			this.changeWeaponHandle = null;
		}
	}

	// Token: 0x0401177C RID: 71548
	private List<int> pveBuffList = new List<int>();

	// Token: 0x0401177D RID: 71549
	private List<int> pvpBuffList = new List<int>();

	// Token: 0x0401177E RID: 71550
	private BeEventHandle changeWeaponHandle;

	// Token: 0x0401177F RID: 71551
	public VRate changeWeaponCD = default(VRate);
}
