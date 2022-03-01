using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020044E4 RID: 17636
public class Skill5569 : BeSkill
{
	// Token: 0x060188BA RID: 100538 RVA: 0x007AA0F4 File Offset: 0x007A84F4
	public Skill5569(int sid, int skillLevel) : base(sid, skillLevel)
	{
		this.buffInfoID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.pillarID = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
	}

	// Token: 0x060188BB RID: 100539 RVA: 0x007AA168 File Offset: 0x007A8568
	public override void OnStart()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorById(list, this.pillarID);
		if (list != null && list.Count > 0)
		{
			int index = base.FrameRandom.InRange(0, list.Count - 1);
			this.pillarSelected = list[index];
			this.pillarSelected.buffController.AddTriggerBuff(this.buffInfoID, 0);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x060188BC RID: 100540 RVA: 0x007AA1E5 File Offset: 0x007A85E5
	public override void OnCancel()
	{
		if (this.pillarSelected != null)
		{
			this.pillarSelected.buffController.RemoveTriggerBuff(this.buffInfoID);
			this.pillarSelected = null;
		}
	}

	// Token: 0x060188BD RID: 100541 RVA: 0x007AA20F File Offset: 0x007A860F
	public override void OnFinish()
	{
		if (this.pillarSelected != null)
		{
			this.pillarSelected.buffController.RemoveTriggerBuff(this.buffInfoID);
			this.pillarSelected = null;
		}
	}

	// Token: 0x04011B5C RID: 72540
	private int buffInfoID = 2020030;

	// Token: 0x04011B5D RID: 72541
	private int pillarID = 572;

	// Token: 0x04011B5E RID: 72542
	private BeActor pillarSelected;
}
