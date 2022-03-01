using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004422 RID: 17442
public class Mechanism97 : BeMechanism
{
	// Token: 0x0601839F RID: 99231 RVA: 0x0078B648 File Offset: 0x00789A48
	public Mechanism97(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060183A0 RID: 99232 RVA: 0x0078B660 File Offset: 0x00789A60
	public override void OnInit()
	{
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.cnt = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x060183A1 RID: 99233 RVA: 0x0078B6E5 File Offset: 0x00789AE5
	public override void OnPostInit()
	{
		base.OnPostInit();
	}

	// Token: 0x060183A2 RID: 99234 RVA: 0x0078B6F0 File Offset: 0x00789AF0
	public override void OnStart()
	{
		base.OnStart();
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMonsterByID(list, this.monsterID, true);
		this.UseSkill(list, 1);
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x060183A3 RID: 99235 RVA: 0x0078B730 File Offset: 0x00789B30
	private void UseSkill(List<BeActor> list, int index)
	{
		if (index > this.cnt || list.Count == 0)
		{
			return;
		}
		BeActor beActor = list[base.FrameRandom.InRange(0, list.Count - 1)];
		List<BeActor> list2 = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMonsterByID(list2, this.protectID, true);
		if (list2.Count > 0)
		{
			ListPool<BeActor>.Release(list2);
			return;
		}
		beActor.UseSkill(this.skillID, false);
		ListPool<BeActor>.Release(list2);
		list.Remove(beActor);
		index++;
		this.UseSkill(list, index);
	}

	// Token: 0x060183A4 RID: 99236 RVA: 0x0078B7CB File Offset: 0x00789BCB
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
	}

	// Token: 0x060183A5 RID: 99237 RVA: 0x0078B7D4 File Offset: 0x00789BD4
	public override void OnFinish()
	{
		base.OnFinish();
	}

	// Token: 0x040117CE RID: 71630
	private int protectID = 30230011;

	// Token: 0x040117CF RID: 71631
	private int monsterID;

	// Token: 0x040117D0 RID: 71632
	private int skillID;

	// Token: 0x040117D1 RID: 71633
	private int cnt;
}
