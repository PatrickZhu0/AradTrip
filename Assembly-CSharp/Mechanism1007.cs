using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x0200424E RID: 16974
public class Mechanism1007 : BeMechanism
{
	// Token: 0x060177C3 RID: 96195 RVA: 0x00738F04 File Offset: 0x00737304
	public Mechanism1007(int id, int lv) : base(id, lv)
	{
	}

	// Token: 0x060177C4 RID: 96196 RVA: 0x00738F1C File Offset: 0x0073731C
	public override void OnInit()
	{
		this.magicElementType = (MagicElementType)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.effectList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
	}

	// Token: 0x060177C5 RID: 96197 RVA: 0x00738F9F File Offset: 0x0073739F
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeMagicElement, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			int num = array[0];
			int num2 = array[1];
			EffectTable tableItem = Singleton<TableManager>.instance.GetTableItem<EffectTable>(num2, string.Empty, string.Empty);
			if (tableItem == null || tableItem.DamageDistanceType != EffectTable.eDamageDistanceType.NEAR)
			{
				return;
			}
			if (!this.effectList.Contains(num2))
			{
				return;
			}
			array[0] = (int)this.magicElementType;
		});
	}

	// Token: 0x04010E06 RID: 69126
	protected MagicElementType magicElementType;

	// Token: 0x04010E07 RID: 69127
	protected List<int> effectList = new List<int>();
}
