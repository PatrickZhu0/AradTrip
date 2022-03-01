using System;
using System.Collections.Generic;

// Token: 0x02004351 RID: 17233
public class Mechanism2027 : BeMechanism
{
	// Token: 0x06017DB0 RID: 97712 RVA: 0x0075F8DE File Offset: 0x0075DCDE
	public Mechanism2027(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017DB1 RID: 97713 RVA: 0x0075F8F4 File Offset: 0x0075DCF4
	public override void OnInit()
	{
		base.OnInit();
		this.InitData();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			int num = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true) - 1;
			this.addValueArr[num] = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			this.addRateArr[num] = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
			this.selfExtraAddRateArr[num] = TableManager.GetValueFromUnionCell(this.data.ValueD[i], this.level, true);
			this.coefficientArr[num] = TableManager.GetValueFromUnionCell(this.data.ValueE[i], this.level, true);
		}
		for (int j = 0; j < this.data.ValueF.Count; j++)
		{
			this.skillList.Add(TableManager.GetValueFromUnionCell(this.data.ValueF[j], this.level, true));
		}
	}

	// Token: 0x06017DB2 RID: 97714 RVA: 0x0075FA49 File Offset: 0x0075DE49
	public bool IsContainSkillID(int skillid)
	{
		return this.skillList.Contains(skillid);
	}

	// Token: 0x06017DB3 RID: 97715 RVA: 0x0075FA58 File Offset: 0x0075DE58
	private void InitData()
	{
		this.typeCount = 12;
		this.addValueArr = new int[this.typeCount];
		this.addRateArr = new int[this.typeCount];
		this.selfExtraAddRateArr = new int[this.typeCount];
		this.coefficientArr = new int[this.typeCount];
	}

	// Token: 0x040112A7 RID: 70311
	private int typeCount;

	// Token: 0x040112A8 RID: 70312
	public int[] addValueArr;

	// Token: 0x040112A9 RID: 70313
	public int[] addRateArr;

	// Token: 0x040112AA RID: 70314
	public int[] selfExtraAddRateArr;

	// Token: 0x040112AB RID: 70315
	public int[] coefficientArr;

	// Token: 0x040112AC RID: 70316
	public List<int> skillList = new List<int>();
}
