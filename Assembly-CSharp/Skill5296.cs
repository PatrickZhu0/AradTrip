using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x020044DE RID: 17630
public class Skill5296 : BeSkill
{
	// Token: 0x0601889D RID: 100509 RVA: 0x007A9440 File Offset: 0x007A7840
	public Skill5296(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601889E RID: 100510 RVA: 0x007A9494 File Offset: 0x007A7894
	public override void OnInit()
	{
		this.thunderID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.pillarID = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.pillarSelectRangeRadius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true), 1000);
		this.maxPillarNum = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
		this.interval = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true);
	}

	// Token: 0x0601889F RID: 100511 RVA: 0x007A955C File Offset: 0x007A795C
	public override void OnStart()
	{
		BeEntity owner = base.owner.GetOwner();
		if (owner != null && !owner.IsDeadOrRemoved())
		{
			VInt3 position = owner.GetPosition();
			position.z = 0;
			base.owner.AddEntity(this.thunderID, position, 1, 0);
		}
		if (base.FrameRandom.Range100() > 30)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindActorInRange(list, base.owner.GetPosition(), this.pillarSelectRangeRadius, base.owner.GetCamp(), this.pillarID);
			if (list.Count > 0)
			{
				int num = base.FrameRandom.InRange(1, list.Count + 1);
				num = Mathf.Min(num, this.maxPillarNum);
				for (int i = 0; i < num; i++)
				{
					BeActor actor = list[i];
					base.owner.delayCaller.DelayCall(this.delay + (i + 1) * this.interval, delegate
					{
						this.owner.AddEntity(this.thunderID, actor.GetPosition(), 1, 0);
					}, 0, 0, false);
				}
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x04011B3E RID: 72510
	private int thunderID = 60107;

	// Token: 0x04011B3F RID: 72511
	private int pillarID = 1780011;

	// Token: 0x04011B40 RID: 72512
	private VInt pillarSelectRangeRadius = VInt.one.i * 3;

	// Token: 0x04011B41 RID: 72513
	private int delay;

	// Token: 0x04011B42 RID: 72514
	private int interval = 100;

	// Token: 0x04011B43 RID: 72515
	private int maxPillarNum = 6;
}
