using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x020043AA RID: 17322
public class Mechanism2112 : BeMechanism
{
	// Token: 0x0601805F RID: 98399 RVA: 0x007742D3 File Offset: 0x007726D3
	public Mechanism2112(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018060 RID: 98400 RVA: 0x007742F4 File Offset: 0x007726F4
	public override void OnInit()
	{
		this.mBuffInfo = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mMonsterIDWhenBuffDisppear = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mMonsterIDWhenDead = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(this.mBuffInfo, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.mBuffID = tableItem.BuffID;
		}
	}

	// Token: 0x06018061 RID: 98401 RVA: 0x007743A8 File Offset: 0x007727A8
	public override void OnStart()
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
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			if (!playerActor.isSpecialMonster)
			{
				if (playerActor.IsDead())
				{
					base.owner.CurrentBeScene.SummonMonster(this.mMonsterIDWhenDead + this.level * 100, playerActor.GetPosition(), base.owner.GetCamp(), base.owner, false, 0, true, 0, false, false);
				}
				else
				{
					this.mHandleList.Add(playerActor.RegisterEvent(BeEventType.onBuffFinish, new BeEventHandle.Del(this._onFinishBuff)));
					this.mHandleList.Add(playerActor.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this._onDead)));
					this.mHandleList.Add(playerActor.RegisterEvent(BeEventType.onMagicGirlMonsterChange, new BeEventHandle.Del(this.onChangeMonster)));
					playerActor.buffController.TryAddBuff(this.mBuffInfo, null, false, null, 0);
				}
			}
		}
	}

	// Token: 0x06018062 RID: 98402 RVA: 0x007744F8 File Offset: 0x007728F8
	public override void OnFinish()
	{
		for (int i = 0; i < this.mHandleList.Count; i++)
		{
			if (this.mHandleList[i] != null)
			{
				this.mHandleList[i].Remove();
			}
		}
		this.mHandleList.Clear();
		this.mPlayerBuffInfo.Clear();
	}

	// Token: 0x06018063 RID: 98403 RVA: 0x0077455C File Offset: 0x0077295C
	public override void OnUpdate(int deltaTime)
	{
		for (int i = this.mPlayerBuffInfo.Count - 1; i >= 0; i--)
		{
			Mechanism2112.ActorBuffInfo actorBuffInfo = this.mPlayerBuffInfo[i];
			if (actorBuffInfo != null)
			{
				actorBuffInfo.leftTime -= deltaTime;
				if (actorBuffInfo.leftTime <= 0)
				{
					if (actorBuffInfo.monster != null)
					{
						base.owner.CurrentBeScene.SummonMonster(this.mMonsterIDWhenBuffDisppear + this.level * 100, actorBuffInfo.monster.GetPosition(), base.owner.GetCamp(), base.owner, false, 0, true, 0, false, false);
					}
					this.mPlayerBuffInfo.RemoveAt(i);
				}
			}
		}
	}

	// Token: 0x06018064 RID: 98404 RVA: 0x00774614 File Offset: 0x00772A14
	private void onChangeMonster(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		BeActor beActor2 = args[1] as BeActor;
		if (beActor == null || beActor2 == null)
		{
			return;
		}
		BeBuff beBuff = beActor2.buffController.HasBuffByID(this.mBuffID);
		if (beBuff != null)
		{
			beActor2.buffController.RemoveBuff(this.mBuffID, 0, 0);
			this.mPlayerBuffInfo.Add(new Mechanism2112.ActorBuffInfo
			{
				actor = beActor2,
				monster = beActor,
				leftTime = beBuff.duration - beBuff.runTime
			});
		}
		this.mHandleList.Add(beActor.RegisterEvent(BeEventType.onMagicGirlMonsterRestore, new BeEventHandle.Del(this.onMagicGirlRestore)));
	}

	// Token: 0x06018065 RID: 98405 RVA: 0x007746C8 File Offset: 0x00772AC8
	private void onMagicGirlRestore(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		BeEntity beEntity = args[1] as BeEntity;
		if (beEntity == null || beActor == null)
		{
			return;
		}
		for (int i = 0; i < this.mPlayerBuffInfo.Count; i++)
		{
			Mechanism2112.ActorBuffInfo actorBuffInfo = this.mPlayerBuffInfo[i];
			if (actorBuffInfo != null && actorBuffInfo.actor != null && actorBuffInfo.monster != null && actorBuffInfo.actor.GetPID() == beActor.GetPID() && actorBuffInfo.monster.GetPID() == beEntity.GetPID())
			{
				beActor.buffController.TryAddBuff(this.mBuffID, actorBuffInfo.leftTime, 1);
				this.mPlayerBuffInfo.RemoveAt(i);
			}
		}
	}

	// Token: 0x06018066 RID: 98406 RVA: 0x0077478C File Offset: 0x00772B8C
	private void _onFinishBuff(object[] args)
	{
		int num = (int)args[0];
		BeActor beActor = args[1] as BeActor;
		if (this.mBuffID == num && beActor != null && !beActor.IsDead())
		{
			base.owner.CurrentBeScene.SummonMonster(this.mMonsterIDWhenBuffDisppear + this.level * 100, beActor.GetPosition(), base.owner.GetCamp(), base.owner, false, 0, true, 0, false, false);
		}
	}

	// Token: 0x06018067 RID: 98407 RVA: 0x0077480C File Offset: 0x00772C0C
	private void _onDead(object[] args)
	{
		if (args.Length < 3)
		{
			return;
		}
		BeActor beActor = args[2] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (beActor.buffController.HasBuffByID(this.mBuffID) != null)
		{
			base.owner.CurrentBeScene.SummonMonster(this.mMonsterIDWhenDead + this.level * 100, beActor.GetPosition(), base.owner.GetCamp(), base.owner, false, 0, true, 0, false, false);
		}
	}

	// Token: 0x040114EB RID: 70891
	private int mBuffInfo;

	// Token: 0x040114EC RID: 70892
	private int mMonsterIDWhenBuffDisppear;

	// Token: 0x040114ED RID: 70893
	private int mMonsterIDWhenDead;

	// Token: 0x040114EE RID: 70894
	private int mBuffID;

	// Token: 0x040114EF RID: 70895
	private List<BeEventHandle> mHandleList = new List<BeEventHandle>();

	// Token: 0x040114F0 RID: 70896
	private List<Mechanism2112.ActorBuffInfo> mPlayerBuffInfo = new List<Mechanism2112.ActorBuffInfo>();

	// Token: 0x020043AB RID: 17323
	private class ActorBuffInfo
	{
		// Token: 0x040114F1 RID: 70897
		public BeActor actor;

		// Token: 0x040114F2 RID: 70898
		public BeActor monster;

		// Token: 0x040114F3 RID: 70899
		public int leftTime;
	}
}
