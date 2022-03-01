using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

// Token: 0x02004318 RID: 17176
public class Mechanism144 : BeMechanism
{
	// Token: 0x06017C52 RID: 97362 RVA: 0x007561B4 File Offset: 0x007545B4
	public Mechanism144(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C53 RID: 97363 RVA: 0x0075620C File Offset: 0x0075460C
	public override void OnInit()
	{
		if (this.data.StringValueA.Length > 0)
		{
			this.effectPath = this.data.StringValueA[0];
		}
		this.invisibleDistToPlayer = new VInt((float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f);
		for (int i = 0; i < this.data.ValueB.Length; i++)
		{
			this.buffIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueC.Length; j++)
		{
			this.buffTimes.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true));
		}
		this.visibleDistToPlayer = new VInt((float)TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) / 1000f);
		this.durTime = 0;
	}

	// Token: 0x06017C54 RID: 97364 RVA: 0x00756354 File Offset: 0x00754754
	public override void OnStart()
	{
		int num = 0;
		while (num < this.buffIds.Count && num < this.buffTimes.Count)
		{
			if (base.owner.buffController.HasBuffByID(this.buffIds[num]) == null)
			{
				base.owner.buffController.TryAddBuff(this.buffIds[num], this.buffTimes[num], 1);
			}
			num++;
		}
		base.owner.buffController.TryAddBuff(21, GlobalLogic.VALUE_100000 * 10, 1);
		this.durTime = 0;
		if (base.owner == null || base.owner.m_pkGeActor == null)
		{
			return;
		}
		this.effect = base.owner.m_pkGeActor.CreateEffect(this.effectPath, null, (float)(GlobalLogic.VALUE_100000 * 10), Vec3.zero, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		GameObject entityNode = base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
		if (this.effect != null && entityNode != null)
		{
			GeUtility.AttachTo(this.effect.GetRootNode(), entityNode, false);
		}
	}

	// Token: 0x06017C55 RID: 97365 RVA: 0x0075648C File Offset: 0x0075488C
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.durTime += deltaTime;
		if (this.durTime < this.interVal)
		{
			return;
		}
		this.durTime -= this.interVal;
		if (base.owner == null || base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return;
		}
		if (base.owner.IsDead())
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		Mechanism144.VISIBLE_STAT visible_STAT = Mechanism144.VISIBLE_STAT.NONE;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i] != null && allPlayers[i].playerActor != null && !allPlayers[i].playerActor.IsDead())
			{
				num2++;
				BeActor playerActor = allPlayers[i].playerActor;
				int distance = playerActor.GetDistance(base.owner);
				if (this.visibleDistToPlayer >= distance)
				{
					visible_STAT = Mechanism144.VISIBLE_STAT.VISABLE;
					break;
				}
				if (this.invisibleDistToPlayer <= distance)
				{
					num++;
				}
			}
		}
		if (num2 == num)
		{
			visible_STAT = Mechanism144.VISIBLE_STAT.INVISABLE;
		}
		if (this.mVisStat == visible_STAT)
		{
			return;
		}
		this.mVisStat = visible_STAT;
		if (this.mVisStat == Mechanism144.VISIBLE_STAT.VISABLE)
		{
			for (int j = 0; j < this.buffIds.Count; j++)
			{
				BeBuff beBuff = base.owner.buffController.HasBuffByID(this.buffIds[j]);
				if (beBuff != null)
				{
					base.owner.buffController.RemoveBuff(beBuff);
				}
			}
			BeBuff beBuff2 = base.owner.buffController.HasBuffByID(21);
			if (beBuff2 != null)
			{
				base.owner.buffController.RemoveBuff(beBuff2);
				if (base.owner.buffController.HasBuffByID(42) == null)
				{
					base.owner.buffController.TryAddBuff(42, GlobalLogic.VALUE_1500, 1);
				}
			}
			if (this.effect != null)
			{
				this.effect.SetVisible(false);
			}
		}
		else if (this.mVisStat == Mechanism144.VISIBLE_STAT.INVISABLE)
		{
			int num3 = 0;
			while (num3 < this.buffIds.Count && num3 < this.buffTimes.Count)
			{
				if (base.owner.buffController.HasBuffByID(this.buffIds[num3]) == null)
				{
					base.owner.buffController.TryAddBuff(this.buffIds[num3], this.buffTimes[num3], 1);
				}
				num3++;
			}
			BeBuff beBuff3 = base.owner.buffController.HasBuffByID(42);
			if (beBuff3 != null)
			{
				base.owner.buffController.RemoveBuff(beBuff3);
			}
			if (base.owner.buffController.HasBuffByID(21) == null)
			{
				base.owner.buffController.TryAddBuff(21, GlobalLogic.VALUE_100000 * 10, 1);
			}
			if (base.owner.m_pkGeActor == null)
			{
				return;
			}
			GameObject entityNode = base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
			if (this.effect != null && entityNode != null && this.effect.GetRootNode() != null && this.effect.GetRootNode().transform != null && this.effect.GetRootNode().transform.parent == null)
			{
				GeUtility.AttachTo(this.effect.GetRootNode(), entityNode, false);
			}
			if (this.effect != null)
			{
				this.effect.SetVisible(true);
			}
		}
	}

	// Token: 0x06017C56 RID: 97366 RVA: 0x0075687C File Offset: 0x00754C7C
	public override void OnFinish()
	{
		if (this.effect != null && base.owner != null && base.owner.m_pkGeActor != null)
		{
			base.owner.m_pkGeActor.DestroyEffect(this.effect);
			this.effect = null;
		}
	}

	// Token: 0x0401117C RID: 70012
	private string effectPath = string.Empty;

	// Token: 0x0401117D RID: 70013
	private VInt invisibleDistToPlayer = 0;

	// Token: 0x0401117E RID: 70014
	private VInt visibleDistToPlayer = 0;

	// Token: 0x0401117F RID: 70015
	private List<int> buffIds = new List<int>();

	// Token: 0x04011180 RID: 70016
	private List<int> buffTimes = new List<int>();

	// Token: 0x04011181 RID: 70017
	private int interVal = 100;

	// Token: 0x04011182 RID: 70018
	private int durTime;

	// Token: 0x04011183 RID: 70019
	private GeEffectEx effect;

	// Token: 0x04011184 RID: 70020
	private Mechanism144.VISIBLE_STAT mVisStat;

	// Token: 0x02004319 RID: 17177
	public enum VISIBLE_STAT
	{
		// Token: 0x04011186 RID: 70022
		INVISABLE,
		// Token: 0x04011187 RID: 70023
		VISABLE,
		// Token: 0x04011188 RID: 70024
		NONE
	}
}
