using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x0200426C RID: 17004
public class Mechanism1034 : BeMechanism
{
	// Token: 0x06017885 RID: 96389 RVA: 0x0073D908 File Offset: 0x0073BD08
	public Mechanism1034(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017886 RID: 96390 RVA: 0x0073D914 File Offset: 0x0073BD14
	public override void OnInit()
	{
		this.monsterId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.summonRate = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.summonNumLimit = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017887 RID: 96391 RVA: 0x0073D999 File Offset: 0x0073BD99
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, new BeEventHandle.Del(this.HitOther));
	}

	// Token: 0x06017888 RID: 96392 RVA: 0x0073D9C0 File Offset: 0x0073BDC0
	private void HitOther(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		int num = (int)base.FrameRandom.Random((uint)GlobalLogic.VALUE_1000);
		if (this.summonRate < num)
		{
			return;
		}
		int monsterID = base.owner.GenNewMonsterID(this.monsterId, this.level);
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorById2(list, monsterID, false);
		int count = list.Count;
		ListPool<BeActor>.Release(list);
		if (this.summonNumLimit != 0 && count >= this.summonNumLimit)
		{
			return;
		}
		base.owner.CurrentBeScene.SummonMonster(monsterID, beActor.GetPosition(), base.owner.m_iCamp, null, false, 0, true, 0, false, false);
	}

	// Token: 0x04010E8D RID: 69261
	private int monsterId;

	// Token: 0x04010E8E RID: 69262
	private int summonRate;

	// Token: 0x04010E8F RID: 69263
	private int summonNumLimit;
}
