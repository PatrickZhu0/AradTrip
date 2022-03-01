using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;

// Token: 0x020044E3 RID: 17635
public class Skill5568 : BeSkill
{
	// Token: 0x060188B2 RID: 100530 RVA: 0x007A9E3A File Offset: 0x007A823A
	public Skill5568(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060188B3 RID: 100531 RVA: 0x007A9E5C File Offset: 0x007A825C
	public override void OnInit()
	{
		this.m_HurtPlayerData = Singleton<TableManager>.instance.GetTableItem<BuffInfoTable>(this.m_HurtPlayerBuffId, string.Empty, string.Empty);
		this.m_HurtSummonData = Singleton<TableManager>.instance.GetTableItem<BuffInfoTable>(this.m_HurtSummonBuffId, string.Empty, string.Empty);
	}

	// Token: 0x060188B4 RID: 100532 RVA: 0x007A9EA9 File Offset: 0x007A82A9
	public override void OnStart()
	{
		this._AddBuffToPlayer();
		this._AddBuffToSummon();
	}

	// Token: 0x060188B5 RID: 100533 RVA: 0x007A9EB7 File Offset: 0x007A82B7
	public override void OnFinish()
	{
	}

	// Token: 0x060188B6 RID: 100534 RVA: 0x007A9EBC File Offset: 0x007A82BC
	protected void _AddBuffToPlayer()
	{
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			playerActor.delayCaller.DelayCall(this.m_HurtPlayerData.BuffDelay, delegate
			{
				playerActor.buffController.TryAddBuff(this.m_HurtPlayerBuffId, null, false, null, 0);
			}, 0, 0, false);
		}
	}

	// Token: 0x060188B7 RID: 100535 RVA: 0x007A9F40 File Offset: 0x007A8340
	protected void _AddBuffToSummon()
	{
		List<BeActor> list = this._GetAllAliveSummon();
		if (list.Count > 0)
		{
			for (int i = 0; i < list.Count; i++)
			{
				int num = (int)base.FrameRandom.Range100();
				if (num <= 50)
				{
					BeActor summon = list[i];
					summon.delayCaller.DelayCall(this.m_HurtSummonData.BuffDelay, delegate
					{
						if (!summon.IsDead())
						{
							summon.buffController.TryAddBuff(this.m_HurtSummonBuffId, null, false, null, 0);
						}
					}, 0, 0, false);
				}
			}
		}
	}

	// Token: 0x060188B8 RID: 100536 RVA: 0x007A9FD0 File Offset: 0x007A83D0
	protected void _GetSummonsByPlayer(List<BeActor> summonsAlive, BeActor Player)
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.GetSummonBySummoner(list, Player, false, false);
		for (int i = 0; i < list.Count; i++)
		{
			if (!list[i].IsDead())
			{
				summonsAlive.Add(list[i]);
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x060188B9 RID: 100537 RVA: 0x007AA034 File Offset: 0x007A8434
	protected List<BeActor> _GetAllAliveSummon()
	{
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		List<BeActor> list = ListPool<BeActor>.Get();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			this._GetSummonsByPlayer(list, allPlayers[i].playerActor);
		}
		ListPool<BeActor>.Release(list);
		return list;
	}

	// Token: 0x04011B58 RID: 72536
	protected int m_HurtPlayerBuffId = 547708;

	// Token: 0x04011B59 RID: 72537
	protected int m_HurtSummonBuffId = 547709;

	// Token: 0x04011B5A RID: 72538
	private BuffInfoTable m_HurtPlayerData;

	// Token: 0x04011B5B RID: 72539
	private BuffInfoTable m_HurtSummonData;
}
