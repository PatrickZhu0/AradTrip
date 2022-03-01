using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02004405 RID: 17413
public class Mechanism69 : BeMechanism
{
	// Token: 0x060182E4 RID: 99044 RVA: 0x007865B2 File Offset: 0x007849B2
	public Mechanism69(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060182E5 RID: 99045 RVA: 0x007865C8 File Offset: 0x007849C8
	public override void OnInit()
	{
		if (this.data.ValueA.Count > 0)
		{
			this.m_ChangeBuffType = (Mechanism69.ChangeBuffType)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		}
		if (this.data.ValueB.Count > 0)
		{
			for (int i = 0; i < this.data.ValueB.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
				this.m_BuffIdList.Add(valueFromUnionCell);
			}
		}
		if (this.data.ValueC.Count > 0)
		{
			this.m_AddBuffTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.m_AddBuffTimeRate = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
		if (this.data.ValueE.Count > 0)
		{
			this.relateByLevel = (TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true) == 1);
		}
	}

	// Token: 0x060182E6 RID: 99046 RVA: 0x00786740 File Offset: 0x00784B40
	public override void OnStart()
	{
		if (this.m_ChangeBuffType == Mechanism69.ChangeBuffType.TRIGGER_CHANGE_BUFF)
		{
			this.RemoveHandle();
			this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
			{
				BeBuff beBuff2 = (BeBuff)args[0];
				if (this.m_BuffIdList.Count > 0 && this.m_BuffIdList.Contains(beBuff2.buffID))
				{
					this.ChangeBuffTime(beBuff2);
				}
			});
			this.handleB = base.owner.RegisterEvent(BeEventType.onBuffRefresh, delegate(object[] args)
			{
				int num = (int)args[0];
				int[] time = (int[])args[1];
				BeBuff beBuff2 = base.owner.buffController.HasBuffByID(num);
				if (this.m_BuffIdList.Count > 0 && this.m_BuffIdList.Contains(num))
				{
					this.RefreshBuffTime(time);
				}
			});
		}
		else if (this.m_ChangeBuffType == Mechanism69.ChangeBuffType.CHANGE_BUFF && this.m_BuffIdList.Count > 0)
		{
			for (int i = 0; i < this.m_BuffIdList.Count; i++)
			{
				BeBuff beBuff = base.owner.buffController.HasBuffByID(this.m_BuffIdList[i]);
				if (beBuff != null)
				{
					this.ChangeBuffTime(beBuff);
				}
			}
		}
	}

	// Token: 0x060182E7 RID: 99047 RVA: 0x00786808 File Offset: 0x00784C08
	protected void ChangeBuffTime(BeBuff buff)
	{
		if (this.m_AddBuffTime != 0)
		{
			buff.duration += ((!this.relateByLevel) ? this.m_AddBuffTime : (this.level * this.m_AddBuffTime));
		}
		if (this.m_AddBuffTimeRate != 0)
		{
			buff.duration *= VFactor.one + new VFactor((long)this.m_AddBuffTimeRate, (long)GlobalLogic.VALUE_1000);
		}
		buff.duration = Mathf.Max(buff.duration, 1);
	}

	// Token: 0x060182E8 RID: 99048 RVA: 0x007868C0 File Offset: 0x00784CC0
	protected void RefreshBuffTime(int[] time)
	{
		if (this.m_AddBuffTime != 0)
		{
			time[0] += ((!this.relateByLevel) ? this.m_AddBuffTime : (this.level * this.m_AddBuffTime));
		}
		if (this.m_AddBuffTimeRate != 0)
		{
			time[0] *= VFactor.one + new VFactor((long)this.m_AddBuffTimeRate, (long)GlobalLogic.VALUE_1000);
		}
		time[0] = Mathf.Max(time[0], 1);
	}

	// Token: 0x060182E9 RID: 99049 RVA: 0x0078694D File Offset: 0x00784D4D
	protected void RemoveHandle()
	{
		if (this.handleA != null)
		{
			this.handleA.Remove();
			this.handleA = null;
		}
		if (this.handleB != null)
		{
			this.handleB.Remove();
			this.handleB = null;
		}
	}

	// Token: 0x0401172C RID: 71468
	protected Mechanism69.ChangeBuffType m_ChangeBuffType;

	// Token: 0x0401172D RID: 71469
	protected List<int> m_BuffIdList = new List<int>();

	// Token: 0x0401172E RID: 71470
	protected int m_AddBuffTime;

	// Token: 0x0401172F RID: 71471
	protected int m_AddBuffTimeRate;

	// Token: 0x04011730 RID: 71472
	protected bool relateByLevel;

	// Token: 0x02004406 RID: 17414
	public enum ChangeBuffType
	{
		// Token: 0x04011732 RID: 71474
		CHANGE_BUFF,
		// Token: 0x04011733 RID: 71475
		TRIGGER_CHANGE_BUFF
	}
}
