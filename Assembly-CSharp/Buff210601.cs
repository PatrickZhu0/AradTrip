using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004223 RID: 16931
public class Buff210601 : BeBuff
{
	// Token: 0x0601770A RID: 96010 RVA: 0x007339B0 File Offset: 0x00731DB0
	public Buff210601(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x0601770B RID: 96011 RVA: 0x007339CC File Offset: 0x00731DCC
	public override void OnInit()
	{
		this.targetEffectRange = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.buffData.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.attachAttackPercent = new VFactor((long)TableManager.GetValueFromUnionCell(this.buffData.ValueB[0], this.level, true), (long)GlobalLogic.VALUE_100);
		this.summonBuffID = TableManager.GetValueFromUnionCell(this.buffData.ValueC[0], this.level, true);
	}

	// Token: 0x0601770C RID: 96012 RVA: 0x00733A68 File Offset: 0x00731E68
	public override void OnStart()
	{
		if (this.staticOwner != null && !this.staticOwner.IsDead() && this.staticOwner != base.owner)
		{
			this.staticOwner.buffController.RemoveBuff(this.buffID, 0, 0);
		}
		this.staticOwner = base.owner;
	}

	// Token: 0x0601770D RID: 96013 RVA: 0x00733AC5 File Offset: 0x00731EC5
	public override void OnUpdate(int delta)
	{
		this.checkTimeAcc += delta;
		if (this.checkTimeAcc > this.checkInterval)
		{
			this.checkTimeAcc -= this.checkInterval;
			this.DoBuffWork();
		}
	}

	// Token: 0x0601770E RID: 96014 RVA: 0x00733B00 File Offset: 0x00731F00
	private void DoBuffWork()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorInRange(list, base.owner.GetPosition(), this.targetEffectRange, (base.owner.m_iCamp != 0) ? 0 : 1, 0);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor actor = list[i];
			if (actor.GetEntityData().isSummonMonster && actor.buffController.HasBuffByID(this.summonBuffID) == null)
			{
				BeBuff beBuff = actor.buffController.TryAddBuff(this.summonBuffID, this.duration, this.level);
				if (beBuff != null)
				{
					if (actor.aiManager != null)
					{
						actor.aiManager.SetTarget(base.owner, true);
						actor.aiManager.ResetAction();
						actor.aiManager.ResetDestinationSelect();
					}
					beBuff.RegisterEvent(BeEventType.onBuffFinish, delegate(object[] args)
					{
						if (actor.aiManager != null)
						{
							actor.aiManager.targetUnchange = false;
						}
					});
				}
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x0601770F RID: 96015 RVA: 0x00733C40 File Offset: 0x00732040
	public override void OnFinish()
	{
		this.staticOwner = null;
	}

	// Token: 0x04010D42 RID: 68930
	private VInt targetEffectRange;

	// Token: 0x04010D43 RID: 68931
	private VFactor attachAttackPercent;

	// Token: 0x04010D44 RID: 68932
	private int summonBuffID;

	// Token: 0x04010D45 RID: 68933
	private int checkInterval = GlobalLogic.VALUE_1000;

	// Token: 0x04010D46 RID: 68934
	private int checkTimeAcc;

	// Token: 0x04010D47 RID: 68935
	private BeActor staticOwner;
}
