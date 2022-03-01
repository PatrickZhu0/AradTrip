using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x0200427D RID: 17021
public class Mechanism1051 : BeMechanism
{
	// Token: 0x060178D5 RID: 96469 RVA: 0x0073F735 File Offset: 0x0073DB35
	public Mechanism1051(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060178D6 RID: 96470 RVA: 0x0073F754 File Offset: 0x0073DB54
	public override void OnInit()
	{
		this.range = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.stateId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.buffId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.isSelf = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) != 0);
		this.maxBuffCount = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.stateFileter = new BeBuffStatIDFilter();
		this.stateFileter.statId = 1 << this.stateId;
	}

	// Token: 0x060178D7 RID: 96471 RVA: 0x0073F860 File Offset: 0x0073DC60
	public override void OnStart()
	{
		this.isStart = true;
	}

	// Token: 0x060178D8 RID: 96472 RVA: 0x0073F86C File Offset: 0x0073DC6C
	public override void OnUpdate(int delta)
	{
		if (!this.isStart)
		{
			return;
		}
		if (base.owner == null || this.stateFileter == null || base.owner.IsDead())
		{
			return;
		}
		this.durTime += delta;
		if (this.durTime < 200)
		{
			return;
		}
		this.durTime -= 200;
		this.DoCheckBuff();
	}

	// Token: 0x060178D9 RID: 96473 RVA: 0x0073F8E4 File Offset: 0x0073DCE4
	private void DoBuff(BeActor actor, int targetCount)
	{
		int buffCountByID = actor.buffController.GetBuffCountByID(this.buffId);
		if (targetCount >= buffCountByID)
		{
			int num = targetCount - buffCountByID;
			for (int i = 0; i < num; i++)
			{
				actor.buffController.TryAddBuff(this.buffId, -1, 1);
			}
		}
		else
		{
			int num2 = buffCountByID - targetCount;
			actor.buffController.RemoveBuff(this.buffId, num2, 0);
		}
	}

	// Token: 0x060178DA RID: 96474 RVA: 0x0073F950 File Offset: 0x0073DD50
	private void DoCheckBuff()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindTargets(list, base.owner, this.range, false, this.stateFileter);
		int count = list.Count;
		ListPool<BeActor>.Release(list);
		if (count > this.maxBuffCount)
		{
			count = this.maxBuffCount;
		}
		if (this.isSelf)
		{
			this.DoBuff(base.owner, count);
		}
		else
		{
			if (base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null)
			{
				return;
			}
			List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			if (allPlayers == null)
			{
				return;
			}
			List<BattlePlayer>.Enumerator enumerator = allPlayers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current != null)
				{
					BeActor playerActor = enumerator.Current.playerActor;
					if (playerActor != null && playerActor.buffController != null)
					{
						this.DoBuff(playerActor, count);
					}
				}
			}
		}
	}

	// Token: 0x04010EC4 RID: 69316
	private VInt range = VInt.zero;

	// Token: 0x04010EC5 RID: 69317
	private int stateId = -2;

	// Token: 0x04010EC6 RID: 69318
	private bool isSelf;

	// Token: 0x04010EC7 RID: 69319
	private bool isStart;

	// Token: 0x04010EC8 RID: 69320
	private int durTime;

	// Token: 0x04010EC9 RID: 69321
	private int maxBuffCount;

	// Token: 0x04010ECA RID: 69322
	private int buffId;

	// Token: 0x04010ECB RID: 69323
	private BeBuffStatIDFilter stateFileter;
}
