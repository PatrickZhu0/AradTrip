using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004280 RID: 17024
public class Mechanism1054 : BeMechanism
{
	// Token: 0x060178E2 RID: 96482 RVA: 0x0073FC86 File Offset: 0x0073E086
	public Mechanism1054(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060178E3 RID: 96483 RVA: 0x0073FCB4 File Offset: 0x0073E0B4
	public override void OnInit()
	{
		this.monsterId.Clear();
		this.targetMonsterId.Clear();
		if (this.data.ValueA.Count > 0)
		{
			for (int i = 0; i < this.data.ValueA.Length; i++)
			{
				this.monsterId.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
			}
		}
		this.targetType = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.buffInfo = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		if (this.data.ValueD.Count > 0)
		{
			for (int j = 0; j < this.data.ValueD.Length; j++)
			{
				this.targetMonsterId.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[j], this.level, true));
			}
		}
		this.buffId = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
	}

	// Token: 0x060178E4 RID: 96484 RVA: 0x0073FE17 File Offset: 0x0073E217
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onSummon, new BeEventHandle.Del(this.onSummonMonster));
	}

	// Token: 0x060178E5 RID: 96485 RVA: 0x0073FE44 File Offset: 0x0073E244
	public override void OnFinish()
	{
		List<BeEventHandle>.Enumerator enumerator = this.summonMonsterHandles.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current != null)
			{
				enumerator.Current.Remove();
			}
		}
		this.summonMonsterHandles.Clear();
	}

	// Token: 0x060178E6 RID: 96486 RVA: 0x0073FE94 File Offset: 0x0073E294
	private void onMonsterDead(object[] args)
	{
		if (base.owner == null || base.owner.CurrentBeBattle == null)
		{
			return;
		}
		if (args.Length != 3)
		{
			return;
		}
		BeActor beActor = args[2] as BeActor;
		if (beActor == null)
		{
			return;
		}
		BeEntity topOwner = beActor.GetTopOwner(beActor);
		if (topOwner != null && topOwner.GetPID() == base.owner.GetPID())
		{
			if (this.targetType == 0)
			{
				if (base.owner == null || base.owner.buffController == null)
				{
					return;
				}
				base.owner.buffController.RemoveBuff(this.buffId, 0, 0);
			}
			else if (this.targetType == 1)
			{
				List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
				if (allPlayers.Count >= 2)
				{
					foreach (BattlePlayer battlePlayer in allPlayers)
					{
						if (battlePlayer != null && battlePlayer.playerActor != null && battlePlayer.playerActor.buffController != null)
						{
							battlePlayer.playerActor.buffController.RemoveBuff(this.buffId, 0, 0);
						}
					}
				}
			}
			else if (this.targetType == 3)
			{
				BeSummonMonsterIdFilter beSummonMonsterIdFilter = new BeSummonMonsterIdFilter();
				beSummonMonsterIdFilter.ownerId = base.owner.GetPID();
				beSummonMonsterIdFilter.summonMonsterId = this.targetMonsterId;
				List<BeActor> list = ListPool<BeActor>.Get();
				base.owner.CurrentBeScene.FindTargets(list, base.owner, true, beSummonMonsterIdFilter);
				foreach (BeActor beActor2 in list)
				{
					if (beActor2 != null && beActor2.buffController != null)
					{
						beActor2.buffController.RemoveBuff(this.buffId, 0, 0);
					}
				}
				ListPool<BeActor>.Release(list);
			}
		}
	}

	// Token: 0x060178E7 RID: 96487 RVA: 0x00740078 File Offset: 0x0073E478
	private void onSummonMonster(object[] args)
	{
		if (base.owner == null || base.owner.CurrentBeBattle == null)
		{
			return;
		}
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < this.monsterId.Count; i++)
		{
			if (beActor.GetEntityData().MonsterIDEqual(this.monsterId[i]))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		BeEventHandle item = beActor.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.onMonsterDead));
		this.summonMonsterHandles.Add(item);
		if (this.targetType == 0)
		{
			if (base.owner == null || base.owner.buffController == null)
			{
				return;
			}
			base.owner.buffController.TryAddBuff(this.buffInfo, null, false, null, 0);
		}
		else if (this.targetType == 1)
		{
			List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			if (allPlayers.Count >= 2)
			{
				foreach (BattlePlayer battlePlayer in allPlayers)
				{
					if (battlePlayer != null && battlePlayer.playerActor != null && battlePlayer.playerActor.buffController != null)
					{
						battlePlayer.playerActor.buffController.TryAddBuff(this.buffInfo, null, false, null, 0);
					}
				}
			}
		}
		else if (this.targetType == 2)
		{
			BeSummonMonsterIdFilter beSummonMonsterIdFilter = new BeSummonMonsterIdFilter();
			beSummonMonsterIdFilter.ownerId = base.owner.GetPID();
			beSummonMonsterIdFilter.summonMonsterId = this.targetMonsterId;
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindTargets(list, base.owner, true, beSummonMonsterIdFilter);
			foreach (BeActor beActor2 in list)
			{
				if (beActor2 != null && beActor2.buffController != null)
				{
					beActor2.buffController.TryAddBuff(this.buffInfo, null, false, null, 0);
				}
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x04010ED0 RID: 69328
	private List<int> monsterId = new List<int>();

	// Token: 0x04010ED1 RID: 69329
	private int targetType;

	// Token: 0x04010ED2 RID: 69330
	private int buffInfo;

	// Token: 0x04010ED3 RID: 69331
	private List<int> targetMonsterId = new List<int>();

	// Token: 0x04010ED4 RID: 69332
	private List<BeEventHandle> summonMonsterHandles = new List<BeEventHandle>();

	// Token: 0x04010ED5 RID: 69333
	private int buffId;
}
