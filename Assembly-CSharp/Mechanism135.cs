using System;
using System.Collections.Generic;

// Token: 0x0200430D RID: 17165
internal class Mechanism135 : BeMechanism
{
	// Token: 0x06017BFD RID: 97277 RVA: 0x0075384B File Offset: 0x00751C4B
	public Mechanism135(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BFE RID: 97278 RVA: 0x00753860 File Offset: 0x00751C60
	public override void OnInit()
	{
		this.originalPhaseId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		int[] array = new int[this.data.ValueB.Length];
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			array[i] = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
		}
		this.replacePhaseIdList.Add(array);
		int[] array2 = new int[this.data.ValueC.Length];
		for (int j = 0; j < this.data.ValueC.Count; j++)
		{
			array2[j] = TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true);
		}
		this.replacePhaseIdList.Add(array2);
		int[] array3 = new int[this.data.ValueD.Length];
		for (int k = 0; k < this.data.ValueD.Count; k++)
		{
			array3[k] = TableManager.GetValueFromUnionCell(this.data.ValueD[k], this.level, true);
		}
		this.replacePhaseIdList.Add(array3);
		int[] array4 = new int[this.data.ValueE.Length];
		for (int l = 0; l < this.data.ValueE.Count; l++)
		{
			array4[l] = TableManager.GetValueFromUnionCell(this.data.ValueE[l], this.level, true);
		}
		this.replacePhaseIdList.Add(array4);
		int[] array5 = new int[this.data.ValueF.Length];
		for (int m = 0; m < this.data.ValueF.Count; m++)
		{
			array5[m] = TableManager.GetValueFromUnionCell(this.data.ValueF[m], this.level, true);
		}
		this.replacePhaseIdList.Add(array5);
	}

	// Token: 0x06017BFF RID: 97279 RVA: 0x00753AB8 File Offset: 0x00751EB8
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			if (array[0] == this.originalPhaseId)
			{
				for (int i = 0; i < this.replacePhaseIdList.Count; i++)
				{
					if (this.replacePhaseIdList[i][0] == base.owner.GetWeaponType())
					{
						int[] array2 = new int[this.replacePhaseIdList[i].Length - 1];
						for (int j = 1; j < this.replacePhaseIdList[i].Length; j++)
						{
							array2[j - 1] = this.replacePhaseIdList[i][j];
						}
						base.owner.SetCurrSkillPhase(array2);
					}
				}
			}
		});
	}

	// Token: 0x0401113A RID: 69946
	private int originalPhaseId;

	// Token: 0x0401113B RID: 69947
	private List<int[]> replacePhaseIdList = new List<int[]>();
}
