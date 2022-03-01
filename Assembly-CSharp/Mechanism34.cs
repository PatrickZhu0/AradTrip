using System;
using System.Collections.Generic;

// Token: 0x020043E0 RID: 17376
public class Mechanism34 : BeMechanism
{
	// Token: 0x060181C2 RID: 98754 RVA: 0x0077E8BC File Offset: 0x0077CCBC
	public Mechanism34(int mid, int lv) : base(mid, lv)
	{
		this.m_MonsterId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_CallNameBuffId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		for (int i = 0; i < this.data.ValueC.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
			if (!this.m_BuffInfoList.Contains(valueFromUnionCell))
			{
				this.m_BuffInfoList.Add(valueFromUnionCell);
			}
		}
		this.m_ForcusFireTime = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		for (int j = 0; j < this.data.ValueE.Count; j++)
		{
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.data.ValueE[j], this.level, true);
			if (!this.m_RemoveBuffIdList.Contains(valueFromUnionCell2))
			{
				this.m_RemoveBuffIdList.Add(valueFromUnionCell2);
			}
		}
		this.m_FocusFireNum = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
	}

	// Token: 0x060181C3 RID: 98755 RVA: 0x0077EA54 File Offset: 0x0077CE54
	public override void OnUpdate(int deltaTime)
	{
		if (this.m_ListenCurrent >= this.m_ListenInterval)
		{
			this.m_ListenCurrent = 0;
			if (this.CheckFocusFire() && !this.m_IsFocusFire)
			{
				this.m_IsFocusFire = true;
				this.StartFocusFire();
			}
		}
		else
		{
			this.m_ListenCurrent += deltaTime;
		}
	}

	// Token: 0x060181C4 RID: 98756 RVA: 0x0077EAB0 File Offset: 0x0077CEB0
	protected bool CheckFocusFire()
	{
		List<BeActor> list = new List<BeActor>();
		list = this.GetCallNamePlayer();
		return list.Count >= this.m_FocusFireNum;
	}

	// Token: 0x060181C5 RID: 98757 RVA: 0x0077EADB File Offset: 0x0077CEDB
	protected void StartFocusFire()
	{
		this.SetMonsterTarget();
		base.owner.delayCaller.DelayCall(this.m_ForcusFireTime, delegate
		{
			this.m_IsFocusFire = false;
			this.RemoveTarget();
			this.RemoveBuff();
		}, 0, 0, false);
	}

	// Token: 0x060181C6 RID: 98758 RVA: 0x0077EB0C File Offset: 0x0077CF0C
	protected void SetMonsterTarget()
	{
		List<BeActor> playerList = new List<BeActor>();
		playerList = this.GetCallNamePlayer();
		List<BeActor> list = new List<BeActor>();
		base.owner.CurrentBeScene.FindActorById(list, this.m_MonsterId);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i];
			this.AddBuffInfoToMonster(beActor);
			beActor.aiManager.SetTarget(this.GetDistance(playerList, beActor), true);
		}
	}

	// Token: 0x060181C7 RID: 98759 RVA: 0x0077EB80 File Offset: 0x0077CF80
	protected void AddBuffInfoToMonster(BeActor actor)
	{
		for (int i = 0; i < this.m_BuffInfoList.Count; i++)
		{
			actor.buffController.TryAddBuff(this.m_BuffInfoList[i], null, false, null, 0);
		}
	}

	// Token: 0x060181C8 RID: 98760 RVA: 0x0077EBC8 File Offset: 0x0077CFC8
	protected void RemoveTarget()
	{
		List<BeActor> list = new List<BeActor>();
		base.owner.CurrentBeScene.FindActorById(list, this.m_MonsterId);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i];
			beActor.aiManager.SetTarget(null, false);
		}
	}

	// Token: 0x060181C9 RID: 98761 RVA: 0x0077EC20 File Offset: 0x0077D020
	protected void RemoveBuff()
	{
		List<BeActor> list = new List<BeActor>();
		base.owner.CurrentBeScene.FindActorById(list, this.m_MonsterId);
		for (int i = 0; i < list.Count; i++)
		{
			for (int j = 0; j < this.m_RemoveBuffIdList.Count; j++)
			{
				if (list[i].buffController.HasBuffByID(this.m_RemoveBuffIdList[j]) != null)
				{
					list[i].buffController.RemoveBuff(this.m_RemoveBuffIdList[j], 0, 0);
				}
			}
		}
		List<BeActor> callNamePlayer = this.GetCallNamePlayer();
		for (int k = 0; k < callNamePlayer.Count; k++)
		{
			BeActor beActor = callNamePlayer[k];
			if (beActor.buffController.HasBuffByID(this.m_CallNameBuffId) != null)
			{
				beActor.buffController.RemoveBuff(this.m_CallNameBuffId, 0, 0);
			}
		}
	}

	// Token: 0x060181CA RID: 98762 RVA: 0x0077ED18 File Offset: 0x0077D118
	protected BeActor GetDistance(List<BeActor> playerList, BeActor attack)
	{
		int num = 0;
		BeActor result = null;
		for (int i = 0; i < playerList.Count; i++)
		{
			BeActor beActor = playerList[i];
			VInt3 position = beActor.GetPosition();
			VInt3 position2 = attack.GetPosition();
			int magnitude = (position - position2).magnitude;
			if (i == 0)
			{
				num = magnitude;
			}
			if (magnitude <= num)
			{
				num = magnitude;
				result = beActor;
			}
		}
		return result;
	}

	// Token: 0x060181CB RID: 98763 RVA: 0x0077ED84 File Offset: 0x0077D184
	protected List<BeActor> GetCallNamePlayer()
	{
		List<BattlePlayer> list = new List<BattlePlayer>();
		list = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		List<BeActor> list2 = new List<BeActor>();
		for (int i = 0; i < list.Count; i++)
		{
			BeActor playerActor = list[i].playerActor;
			if (playerActor.buffController.HasBuffByID(this.m_CallNameBuffId) != null && !list2.Contains(playerActor))
			{
				list2.Add(playerActor);
			}
		}
		return list2;
	}

	// Token: 0x04011624 RID: 71204
	protected int m_MonsterId;

	// Token: 0x04011625 RID: 71205
	protected int m_CallNameBuffId;

	// Token: 0x04011626 RID: 71206
	protected List<int> m_BuffInfoList = new List<int>();

	// Token: 0x04011627 RID: 71207
	protected int m_ForcusFireTime;

	// Token: 0x04011628 RID: 71208
	protected List<int> m_RemoveBuffIdList = new List<int>();

	// Token: 0x04011629 RID: 71209
	protected int m_FocusFireNum;

	// Token: 0x0401162A RID: 71210
	protected int m_ListenCurrent;

	// Token: 0x0401162B RID: 71211
	protected int m_ListenInterval = 100;

	// Token: 0x0401162C RID: 71212
	protected bool m_IsFocusFire;
}
