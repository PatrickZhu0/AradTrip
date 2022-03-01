using System;
using System.Collections.Generic;

// Token: 0x02004402 RID: 17410
public class Mechanism66 : BeMechanism
{
	// Token: 0x060182CD RID: 99021 RVA: 0x00785BAE File Offset: 0x00783FAE
	public Mechanism66(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060182CE RID: 99022 RVA: 0x00785BC4 File Offset: 0x00783FC4
	public override void OnInit()
	{
		this.m_OriginalPhaseId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueB.Count > 0)
		{
			this.m_ReplacePhaseId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		if (this.data.ValueC.Count > 0)
		{
			for (int i = 0; i < this.data.ValueC.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
				this.m_ReplacePhaseIdList.Add(valueFromUnionCell);
			}
		}
	}

	// Token: 0x060182CF RID: 99023 RVA: 0x00785C9D File Offset: 0x0078409D
	public override void OnStart()
	{
		this.RemoveHandle();
		this.m_ReplacePhaseHandle = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			if (array[0] == this.m_OriginalPhaseId)
			{
				if (this.m_ReplacePhaseId != 0)
				{
					array[0] = this.m_ReplacePhaseId;
				}
				if (this.m_ReplacePhaseIdList.Count > 0)
				{
					int[] array2 = new int[this.m_ReplacePhaseIdList.Count];
					for (int i = 0; i < this.m_ReplacePhaseIdList.Count; i++)
					{
						array2[i] = this.m_ReplacePhaseIdList[i];
					}
					base.owner.SetCurrSkillPhase(array2);
				}
			}
		});
	}

	// Token: 0x060182D0 RID: 99024 RVA: 0x00785CC4 File Offset: 0x007840C4
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x060182D1 RID: 99025 RVA: 0x00785CCC File Offset: 0x007840CC
	protected void RemoveHandle()
	{
		if (this.m_ReplacePhaseHandle != null)
		{
			this.m_ReplacePhaseHandle.Remove();
			this.m_ReplacePhaseHandle = null;
		}
	}

	// Token: 0x0401171B RID: 71451
	protected int m_OriginalPhaseId;

	// Token: 0x0401171C RID: 71452
	protected int m_ReplacePhaseId;

	// Token: 0x0401171D RID: 71453
	protected List<int> m_ReplacePhaseIdList = new List<int>();

	// Token: 0x0401171E RID: 71454
	protected BeEventHandle m_ReplacePhaseHandle;
}
