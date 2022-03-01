using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;

// Token: 0x020043AC RID: 17324
public class Mechanism2113 : BeMechanism
{
	// Token: 0x06018069 RID: 98409 RVA: 0x00774894 File Offset: 0x00772C94
	public Mechanism2113(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601806A RID: 98410 RVA: 0x007748B4 File Offset: 0x00772CB4
	public override void OnInit()
	{
		this.mDistance = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.mBuffInfoIDInThreesome = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mBuffInfoIDInTwosome = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(this.mBuffInfoIDInThreesome, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.mBuffIDInThreesome = tableItem.BuffID;
		}
		tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(this.mBuffInfoIDInTwosome, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.mBuffIDInTwosome = tableItem.BuffID;
		}
	}

	// Token: 0x0601806B RID: 98411 RVA: 0x007749A0 File Offset: 0x00772DA0
	public override void OnFinish()
	{
		base.OnFinish();
		for (int i = 0; i < this.mHandList.Count; i++)
		{
			if (this.mHandList[i] != null)
			{
				this.mHandList[i].Remove();
			}
		}
		this.mHandList.Clear();
		this._ClearAllBuffs();
	}

	// Token: 0x0601806C RID: 98412 RVA: 0x00774A04 File Offset: 0x00772E04
	private void onChangeMonster(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		BeActor beActor2 = args[1] as BeActor;
		if (beActor == null || beActor2 == null)
		{
			return;
		}
		beActor2.buffController.RemoveBuff(this.mBuffIDInTwosome, 0, 0);
		beActor2.buffController.RemoveBuff(this.mBuffIDInThreesome, 0, 0);
	}

	// Token: 0x0601806D RID: 98413 RVA: 0x00774A56 File Offset: 0x00772E56
	public override void OnUpdate(int deltaTime)
	{
		this.mElapseTime += deltaTime;
		if (this.mElapseTime < 100)
		{
			return;
		}
		this.mElapseTime -= 100;
		this._onCheckPlayer();
	}

	// Token: 0x0601806E RID: 98414 RVA: 0x00774A8C File Offset: 0x00772E8C
	private void _ClearAllBuffs()
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
			BattlePlayer battlePlayer = allPlayers[i];
			if (battlePlayer != null && battlePlayer.playerActor != null)
			{
				battlePlayer.playerActor.buffController.RemoveBuff(this.mBuffIDInTwosome, 0, 0);
				battlePlayer.playerActor.buffController.RemoveBuff(this.mBuffIDInThreesome, 0, 0);
			}
		}
	}

	// Token: 0x0601806F RID: 98415 RVA: 0x00774B44 File Offset: 0x00772F44
	private bool _isStickTogether(List<BeActor> players)
	{
		if (players.Count <= 1)
		{
			return false;
		}
		int distance = players[0].GetDistance(players[1]);
		bool flag = distance <= this.mDistance;
		if (players.Count == 2)
		{
			return flag;
		}
		if (players.Count == 3)
		{
			int distance2 = players[0].GetDistance(players[2]);
			int distance3 = players[1].GetDistance(players[2]);
			return flag && distance2 <= this.mDistance && distance3 <= this.mDistance;
		}
		return false;
	}

	// Token: 0x06018070 RID: 98416 RVA: 0x00774BFC File Offset: 0x00772FFC
	private void _DoAddBuff(List<BeActor> players)
	{
		if (players.Count == 2)
		{
			players[0].buffController.RemoveBuff(this.mBuffIDInThreesome, 0, 0);
			players[1].buffController.RemoveBuff(this.mBuffIDInThreesome, 0, 0);
			players[0].buffController.TryAddBuff(this.mBuffInfoIDInTwosome, null, false, null, 0);
			players[1].buffController.TryAddBuff(this.mBuffInfoIDInTwosome, null, false, null, 0);
		}
		else if (players.Count == 3)
		{
			players[0].buffController.RemoveBuff(this.mBuffIDInTwosome, 0, 0);
			players[1].buffController.RemoveBuff(this.mBuffIDInTwosome, 0, 0);
			players[2].buffController.RemoveBuff(this.mBuffIDInTwosome, 0, 0);
			players[0].buffController.TryAddBuff(this.mBuffInfoIDInThreesome, null, false, null, 0);
			players[1].buffController.TryAddBuff(this.mBuffInfoIDInThreesome, null, false, null, 0);
			players[2].buffController.TryAddBuff(this.mBuffInfoIDInThreesome, null, false, null, 0);
		}
	}

	// Token: 0x06018071 RID: 98417 RVA: 0x00774D30 File Offset: 0x00773130
	public void _onCheckPlayer()
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
		int num = 0;
		List<BeActor> list = ListPool<BeActor>.Get();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BattlePlayer battlePlayer = allPlayers[i];
			if (battlePlayer != null && battlePlayer.playerActor != null && !battlePlayer.playerActor.IsDead())
			{
				num++;
				list.Add(battlePlayer.playerActor);
			}
		}
		if (this._isStickTogether(list))
		{
			this._DoAddBuff(list);
		}
		else
		{
			this._ClearAllBuffs();
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06018072 RID: 98418 RVA: 0x00774E08 File Offset: 0x00773208
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
			BattlePlayer battlePlayer = allPlayers[i];
			if (battlePlayer != null && battlePlayer.playerActor != null)
			{
				this.mHandList.Add(battlePlayer.playerActor.RegisterEvent(BeEventType.onMagicGirlMonsterChange, new BeEventHandle.Del(this.onChangeMonster)));
			}
		}
		this._onCheckPlayer();
	}

	// Token: 0x040114F4 RID: 70900
	private VInt mDistance = VInt.zero;

	// Token: 0x040114F5 RID: 70901
	private int mBuffInfoIDInThreesome;

	// Token: 0x040114F6 RID: 70902
	private int mBuffIDInThreesome;

	// Token: 0x040114F7 RID: 70903
	private int mBuffInfoIDInTwosome;

	// Token: 0x040114F8 RID: 70904
	private int mBuffIDInTwosome;

	// Token: 0x040114F9 RID: 70905
	private List<BeEventHandle> mHandList = new List<BeEventHandle>();

	// Token: 0x040114FA RID: 70906
	private int mElapseTime;
}
