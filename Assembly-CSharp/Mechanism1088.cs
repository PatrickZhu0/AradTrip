using System;
using System.Collections.Generic;

// Token: 0x0200429E RID: 17054
public class Mechanism1088 : BeMechanism
{
	// Token: 0x06017983 RID: 96643 RVA: 0x00744805 File Offset: 0x00742C05
	public Mechanism1088(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017984 RID: 96644 RVA: 0x0074481C File Offset: 0x00742C1C
	public override void OnInit()
	{
		this.interruptSkillIds.Clear();
		this.castSkillId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.interruptSkillIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
	}

	// Token: 0x06017985 RID: 96645 RVA: 0x007448AA File Offset: 0x00742CAA
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onSkillCanBeInterrupt, new BeEventHandle.Del(this.onSkillCanBeInterrupt));
	}

	// Token: 0x06017986 RID: 96646 RVA: 0x007448D0 File Offset: 0x00742CD0
	private void onSkillCanBeInterrupt(object[] args)
	{
		BeSkill beSkill = args[0] as BeSkill;
		if (beSkill == null)
		{
			return;
		}
		if (beSkill.skillID != this.castSkillId)
		{
			return;
		}
		int[] array = args[1] as int[];
		int item = array[0];
		if (this.interruptSkillIds.Contains(item))
		{
			array[1] = 1;
		}
	}

	// Token: 0x04010F49 RID: 69449
	private int castSkillId;

	// Token: 0x04010F4A RID: 69450
	private List<int> interruptSkillIds = new List<int>();
}
