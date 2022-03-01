using System;
using System.Collections.Generic;

// Token: 0x020043F7 RID: 17399
public class Mechanism56 : BeMechanism
{
	// Token: 0x0601826B RID: 98923 RVA: 0x007833A4 File Offset: 0x007817A4
	public Mechanism56(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601826C RID: 98924 RVA: 0x007833B9 File Offset: 0x007817B9
	public override void OnInit()
	{
		this.mDamageAddRate = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x0601826D RID: 98925 RVA: 0x007833ED File Offset: 0x007817ED
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onBeHitAfterFinalDamage, new BeEventHandle.Del(this.RegisterBeHit));
	}

	// Token: 0x0601826E RID: 98926 RVA: 0x00783410 File Offset: 0x00781810
	protected void RegisterBeHit(object[] args)
	{
		List<int> list = args[6] as List<int>;
		if (list.Contains(2))
		{
			int[] array = args[0] as int[];
			int num = array[0];
			List<int> list2 = args[7] as List<int>;
			if (list2 != null)
			{
				for (int i = 0; i < list2.Count; i++)
				{
					num -= list2[i];
				}
			}
			int num2 = num * this.mDamageAddRate;
			array[0] += num2;
		}
	}

	// Token: 0x040116C1 RID: 71361
	protected VFactor mDamageAddRate = VFactor.zero;
}
