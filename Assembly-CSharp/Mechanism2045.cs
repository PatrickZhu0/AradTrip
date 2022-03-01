using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004364 RID: 17252
public class Mechanism2045 : BeMechanism
{
	// Token: 0x06017E45 RID: 97861 RVA: 0x00763EEF File Offset: 0x007622EF
	public Mechanism2045(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017E46 RID: 97862 RVA: 0x00763EFC File Offset: 0x007622FC
	public override void OnInit()
	{
		base.OnInit();
		this.monsterId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.skillId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017E47 RID: 97863 RVA: 0x00763F60 File Offset: 0x00762360
	public override void OnStart()
	{
		base.OnStart();
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorById2(list, this.monsterId, false);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i];
			if (beActor != null && !beActor.IsDead() && beActor.GetPID() != base.owner.GetPID() && beActor.CanUseSkill(this.skillId))
			{
				beActor.UseSkill(this.skillId, false);
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x04011319 RID: 70425
	private int monsterId;

	// Token: 0x0401131A RID: 70426
	private int skillId;
}
