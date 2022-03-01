using System;
using System.Collections.Generic;

// Token: 0x020043DB RID: 17371
public class Mechanism3 : BeMechanism
{
	// Token: 0x0601819C RID: 98716 RVA: 0x0077D910 File Offset: 0x0077BD10
	public Mechanism3(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601819D RID: 98717 RVA: 0x0077D934 File Offset: 0x0077BD34
	public override void OnInit()
	{
		this.summonLevelAdd = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			int num = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			num = BeUtility.GetOnlyMonsterID(num);
			if (num > 0)
			{
				this.specifyMonsterIDs.Add(num);
			}
		}
	}

	// Token: 0x0601819E RID: 98718 RVA: 0x0077D9CC File Offset: 0x0077BDCC
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeSummon, delegate(object[] args)
			{
				int m = (int)args[1];
				if (this.specifyMonsterIDs.Count <= 0 || this.specifyMonsterIDs.Contains(BeUtility.GetOnlyMonsterID(m)))
				{
					int[] array = (int[])args[0];
					array[0] += this.summonLevelAdd;
				}
			});
		}
	}

	// Token: 0x040115FE RID: 71166
	private CrypticInt32 summonLevelAdd = 0;

	// Token: 0x040115FF RID: 71167
	private List<int> specifyMonsterIDs = new List<int>();
}
