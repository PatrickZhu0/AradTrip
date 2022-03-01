using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x0200432B RID: 17195
public class Mechanism162 : BeMechanism
{
	// Token: 0x06017CA3 RID: 97443 RVA: 0x0075878E File Offset: 0x00756B8E
	public Mechanism162(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CA4 RID: 97444 RVA: 0x007587A4 File Offset: 0x00756BA4
	public override void OnInit()
	{
		this.InitData();
	}

	// Token: 0x06017CA5 RID: 97445 RVA: 0x007587AC File Offset: 0x00756BAC
	public override void OnPostInit()
	{
		this.InitData();
	}

	// Token: 0x06017CA6 RID: 97446 RVA: 0x007587B4 File Offset: 0x00756BB4
	protected void InitData()
	{
		this.m_AddDamageTypeList.Clear();
		this.addDamageRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.addDamageFixedRate = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		for (int i = 0; i < this.data.ValueC.Count; i++)
		{
			this.m_AddDamageTypeList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true));
		}
	}

	// Token: 0x06017CA7 RID: 97447 RVA: 0x0075886A File Offset: 0x00756C6A
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onBeHitChangeDamage, new BeEventHandle.Del(this.OnBeHitChangeDamage));
	}

	// Token: 0x06017CA8 RID: 97448 RVA: 0x00758890 File Offset: 0x00756C90
	protected void OnBeHitChangeDamage(object[] args)
	{
		EffectTable effectTableData = args[2] as EffectTable;
		if (!this.CheckCondition(effectTableData))
		{
			return;
		}
		int[] array = (int[])args[1];
		array[0] += this.addDamageRate;
		array[1] += this.addDamageFixedRate;
	}

	// Token: 0x06017CA9 RID: 97449 RVA: 0x007588E0 File Offset: 0x00756CE0
	protected bool CheckCondition(EffectTable m_EffectTableData)
	{
		if (this.m_AddDamageTypeList == null || this.m_AddDamageTypeList.Count == 0)
		{
			return true;
		}
		if (m_EffectTableData == null)
		{
			return true;
		}
		for (int i = 0; i < this.m_AddDamageTypeList.Count; i++)
		{
			switch (this.m_AddDamageTypeList[i])
			{
			case 1:
				if (m_EffectTableData.DamageType != EffectTable.eDamageType.PHYSIC)
				{
					return false;
				}
				break;
			case 2:
				if (m_EffectTableData.DamageType != EffectTable.eDamageType.MAGIC)
				{
					return false;
				}
				break;
			case 3:
				if (m_EffectTableData.DamageDistanceType != EffectTable.eDamageDistanceType.NEAR)
				{
					return false;
				}
				break;
			case 4:
				if (m_EffectTableData.DamageDistanceType != EffectTable.eDamageDistanceType.FAR)
				{
					return false;
				}
				break;
			}
		}
		return true;
	}

	// Token: 0x040111D3 RID: 70099
	private int addDamageRate;

	// Token: 0x040111D4 RID: 70100
	private int addDamageFixedRate;

	// Token: 0x040111D5 RID: 70101
	protected List<int> m_AddDamageTypeList = new List<int>(5);

	// Token: 0x0200432C RID: 17196
	public enum AddDamageType
	{
		// Token: 0x040111D7 RID: 70103
		NONE,
		// Token: 0x040111D8 RID: 70104
		PHYSIC,
		// Token: 0x040111D9 RID: 70105
		MAGIC,
		// Token: 0x040111DA RID: 70106
		NEAR,
		// Token: 0x040111DB RID: 70107
		FAR
	}
}
