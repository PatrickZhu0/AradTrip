using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020044E2 RID: 17634
public class Skill5521 : BeSkill
{
	// Token: 0x060188AF RID: 100527 RVA: 0x007A9D00 File Offset: 0x007A8100
	public Skill5521(int sid, int skillLevel) : base(sid, skillLevel)
	{
		this.buffInfoID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.pillarID = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
	}

	// Token: 0x060188B0 RID: 100528 RVA: 0x007A9D74 File Offset: 0x007A8174
	public override void OnStart()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorInRange(list, base.owner.GetPosition(), int.MaxValue, base.owner.GetCamp(), this.pillarID);
		if (list != null && list.Count > 0)
		{
			int index = base.FrameRandom.InRange(0, list.Count);
			list[index].buffController.AddTriggerBuff(this.buffInfoID, 0);
			this.pillarSelected = list[index];
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x060188B1 RID: 100529 RVA: 0x007A9E10 File Offset: 0x007A8210
	public override void OnFinish()
	{
		if (this.pillarSelected != null)
		{
			this.pillarSelected.buffController.RemoveTriggerBuff(this.buffInfoID);
			this.pillarSelected = null;
		}
	}

	// Token: 0x04011B55 RID: 72533
	private int buffInfoID = 2020030;

	// Token: 0x04011B56 RID: 72534
	private int pillarID = 572;

	// Token: 0x04011B57 RID: 72535
	private BeActor pillarSelected;
}
