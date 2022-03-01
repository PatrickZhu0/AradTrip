using System;
using System.Collections.Generic;

// Token: 0x02004270 RID: 17008
public class Mechanism1038 : BeMechanism
{
	// Token: 0x0601789D RID: 96413 RVA: 0x0073E107 File Offset: 0x0073C507
	public Mechanism1038(int id, int level) : base(id, level)
	{
	}

	// Token: 0x0601789E RID: 96414 RVA: 0x0073E11C File Offset: 0x0073C51C
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			Mechanism1038.AddBuffInfoData item = default(Mechanism1038.AddBuffInfoData);
			item.buffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			item.addRate = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			item.priorityLevel = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
			this.buffInfoList.Add(item);
		}
	}

	// Token: 0x0601789F RID: 96415 RVA: 0x0073E1DF File Offset: 0x0073C5DF
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitCriticalBeforDamage, delegate(object[] args)
		{
			this.AddBuffInfo();
		});
	}

	// Token: 0x060178A0 RID: 96416 RVA: 0x0073E208 File Offset: 0x0073C608
	private void AddBuffInfo()
	{
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < this.buffInfoList.Count; i++)
		{
			Mechanism1038.AddBuffInfoData addBuffInfoData = this.buffInfoList[i];
			int num3 = (int)base.FrameRandom.Random((uint)GlobalLogic.VALUE_1000);
			if (addBuffInfoData.addRate >= num3 && addBuffInfoData.priorityLevel > num2)
			{
				num = addBuffInfoData.buffInfoId;
				num2 = addBuffInfoData.priorityLevel;
			}
		}
		if (num != 0)
		{
			base.owner.buffController.TryAddBuffInfo(num, base.owner, this.level);
		}
	}

	// Token: 0x04010E9F RID: 69279
	private List<Mechanism1038.AddBuffInfoData> buffInfoList = new List<Mechanism1038.AddBuffInfoData>();

	// Token: 0x02004271 RID: 17009
	public struct AddBuffInfoData
	{
		// Token: 0x04010EA0 RID: 69280
		public int buffInfoId;

		// Token: 0x04010EA1 RID: 69281
		public int addRate;

		// Token: 0x04010EA2 RID: 69282
		public int priorityLevel;
	}
}
