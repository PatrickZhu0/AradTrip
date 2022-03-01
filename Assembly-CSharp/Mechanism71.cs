using System;
using System.Collections.Generic;

// Token: 0x02004409 RID: 17417
public class Mechanism71 : BeMechanism
{
	// Token: 0x060182FE RID: 99070 RVA: 0x00787404 File Offset: 0x00785804
	public Mechanism71(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060182FF RID: 99071 RVA: 0x00787420 File Offset: 0x00785820
	public override void OnInit()
	{
		if (this.data.ValueA.Count > 0)
		{
			for (int i = 0; i < this.data.ValueA.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
				this.m_EntityIdList.Add(valueFromUnionCell);
			}
		}
		if (this.data.ValueB.Count > 0)
		{
			this.m_DelayTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		if (this.data.ValueC.Count > 0)
		{
			this.m_CopyNum = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
	}

	// Token: 0x06018300 RID: 99072 RVA: 0x0078750F File Offset: 0x0078590F
	public override void OnStart()
	{
		this.RemoveHandle();
		this.m_CopyEntity = base.owner.RegisterEvent(BeEventType.onChangeLaunchProNum, delegate(object[] args)
		{
			int item = (int)args[0];
			if (this.m_EntityIdList.Count > 0 && this.m_EntityIdList.Contains(item))
			{
				int[] array = (int[])args[1];
				int[] array2 = (int[])args[2];
				array[0] = this.m_DelayTime;
				array2[0] = this.m_CopyNum;
			}
		});
	}

	// Token: 0x06018301 RID: 99073 RVA: 0x00787536 File Offset: 0x00785936
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x06018302 RID: 99074 RVA: 0x0078753E File Offset: 0x0078593E
	protected void RemoveHandle()
	{
		if (this.m_CopyEntity != null)
		{
			this.m_CopyEntity.Remove();
			this.m_CopyEntity = null;
		}
	}

	// Token: 0x0401174C RID: 71500
	protected List<int> m_EntityIdList = new List<int>();

	// Token: 0x0401174D RID: 71501
	protected int m_DelayTime;

	// Token: 0x0401174E RID: 71502
	protected int m_CopyNum = 1;

	// Token: 0x0401174F RID: 71503
	protected BeEventHandle m_CopyEntity;
}
