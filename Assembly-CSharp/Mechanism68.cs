using System;
using System.Collections.Generic;

// Token: 0x02004404 RID: 17412
public class Mechanism68 : BeMechanism
{
	// Token: 0x060182DA RID: 99034 RVA: 0x00786187 File Offset: 0x00784587
	public Mechanism68(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060182DB RID: 99035 RVA: 0x007861B0 File Offset: 0x007845B0
	public override void OnInit()
	{
		if (this.data.ValueA.Count > 0)
		{
			for (int i = 0; i < this.data.ValueA.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
				this.m_HurtIdList.Add(valueFromUnionCell);
			}
		}
		if (this.data.ValueB.Count > 0)
		{
			this.m_AddHitThroughRateValue = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		if (this.data.ValueC.Count > 0)
		{
			this.m_AddHardValue = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.m_AddHardValueRate = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
		if (this.data.ValueE.Count > 0)
		{
			this.m_ScreenShakeID = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
	}

	// Token: 0x060182DC RID: 99036 RVA: 0x00786320 File Offset: 0x00784720
	public override void OnStart()
	{
		this.RemoveHandle();
		this.m_ChangeHitThrough = base.owner.RegisterEvent(BeEventType.onChangeHitThrough, delegate(object[] args)
		{
			int item = (int)args[0];
			if (this.m_HurtIdList.Count > 0 && this.m_HurtIdList.Contains(item) && this.m_AddHitThroughRateValue != 0)
			{
				VRate[] rateArray = (VRate[])args[1];
				this.ChangeHitThrough(rateArray);
			}
		});
		this.m_ChangeHardValue = base.owner.RegisterEvent(BeEventType.onChangeHardValue, delegate(object[] args)
		{
			int item = (int)args[0];
			if (this.m_HurtIdList.Count > 0 && this.m_HurtIdList.Contains(item) && (this.m_AddHardValue != 0 || this.m_AddHardValueRate != 0))
			{
				int[] hardValueArray = (int[])args[1];
				this.ChangeHardValue(hardValueArray);
			}
		});
		if (this.m_ScreenShakeID != -1)
		{
			this.m_ChangeScreenShakeID = base.owner.RegisterEvent(BeEventType.onChangeScreenShakeID, delegate(object[] args)
			{
				int item = (int)args[0];
				if (this.m_HurtIdList.Count > 0 && this.m_HurtIdList.Contains(item))
				{
					int[] array = (int[])args[1];
					array[0] = this.m_ScreenShakeID;
				}
			});
		}
	}

	// Token: 0x060182DD RID: 99037 RVA: 0x007863A8 File Offset: 0x007847A8
	protected void ChangeHitThrough(VRate[] rateArray)
	{
		VRate vrate = rateArray[0];
		rateArray[0] += this.m_AddHitThroughRateValue;
	}

	// Token: 0x060182DE RID: 99038 RVA: 0x007863E0 File Offset: 0x007847E0
	protected void ChangeHardValue(int[] hardValueArray)
	{
		if (this.m_AddHardValue != 0)
		{
			hardValueArray[0] += this.m_AddHardValue;
		}
		if (this.m_AddHardValueRate != 0)
		{
			hardValueArray[0] *= VFactor.one + new VFactor((long)this.m_AddHardValueRate, (long)GlobalLogic.VALUE_1000);
		}
	}

	// Token: 0x060182DF RID: 99039 RVA: 0x0078643F File Offset: 0x0078483F
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x060182E0 RID: 99040 RVA: 0x00786448 File Offset: 0x00784848
	protected void RemoveHandle()
	{
		if (this.m_ChangeHitThrough != null)
		{
			this.m_ChangeHitThrough.Remove();
			this.m_ChangeHitThrough = null;
		}
		if (this.m_ChangeHardValue != null)
		{
			this.m_ChangeHardValue.Remove();
			this.m_ChangeHardValue = null;
		}
		if (this.m_ChangeScreenShakeID != null)
		{
			this.m_ChangeScreenShakeID.Remove();
			this.m_ChangeScreenShakeID = null;
		}
	}

	// Token: 0x04011724 RID: 71460
	protected List<int> m_HurtIdList = new List<int>();

	// Token: 0x04011725 RID: 71461
	protected VRate m_AddHitThroughRateValue = 0;

	// Token: 0x04011726 RID: 71462
	protected int m_AddHardValue;

	// Token: 0x04011727 RID: 71463
	protected int m_AddHardValueRate;

	// Token: 0x04011728 RID: 71464
	protected int m_ScreenShakeID = -1;

	// Token: 0x04011729 RID: 71465
	protected BeEventHandle m_ChangeHitThrough;

	// Token: 0x0401172A RID: 71466
	protected BeEventHandle m_ChangeHardValue;

	// Token: 0x0401172B RID: 71467
	protected BeEventHandle m_ChangeScreenShakeID;
}
