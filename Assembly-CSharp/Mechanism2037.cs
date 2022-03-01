using System;
using UnityEngine;

// Token: 0x0200435C RID: 17244
public class Mechanism2037 : BeMechanism
{
	// Token: 0x06017E09 RID: 97801 RVA: 0x00762181 File Offset: 0x00760581
	public Mechanism2037(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017E0A RID: 97802 RVA: 0x0076219C File Offset: 0x0076059C
	public override void OnInit()
	{
		base.OnInit();
		this.buffIDs = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.buffIDs.Length; i++)
		{
			this.buffIDs[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.defenceValue = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) / 1000;
		this._defenceCanLessZero = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) == 0);
		if (this.data.ValueC.Length > 1)
		{
			this._ingoreLessZero = (TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true) == 0);
		}
	}

	// Token: 0x06017E0B RID: 97803 RVA: 0x007622B9 File Offset: 0x007606B9
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.OnChangeAttributeDefence, delegate(object[] args)
		{
			int[] array = args[0] as int[];
			if (this.HaveAllBuff())
			{
				if (this._ingoreLessZero && array != null && array.Length > 0 && array[0] <= 0)
				{
					return;
				}
				int num = array[0] - this.defenceValue;
				if (!this._defenceCanLessZero)
				{
					num = Mathf.Max(num, 0);
				}
				array[0] = num;
			}
		});
	}

	// Token: 0x06017E0C RID: 97804 RVA: 0x007622E0 File Offset: 0x007606E0
	private bool HaveAllBuff()
	{
		for (int i = 0; i < this.buffIDs.Length; i++)
		{
			if (base.owner.buffController.HasBuffByID(this.buffIDs[i]) == null)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x040112F2 RID: 70386
	private int[] buffIDs;

	// Token: 0x040112F3 RID: 70387
	private int defenceValue;

	// Token: 0x040112F4 RID: 70388
	private bool _defenceCanLessZero = true;

	// Token: 0x040112F5 RID: 70389
	private bool _ingoreLessZero = true;
}
