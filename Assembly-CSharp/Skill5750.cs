using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;

// Token: 0x020044F8 RID: 17656
internal class Skill5750 : BeSkill
{
	// Token: 0x06018921 RID: 100641 RVA: 0x007AC956 File Offset: 0x007AAD56
	public Skill5750(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018922 RID: 100642 RVA: 0x007AC981 File Offset: 0x007AAD81
	public override void OnEnterPhase(int phase)
	{
		if (phase == 2)
		{
			this._findAltarPositions();
			this._summonHoods();
		}
	}

	// Token: 0x06018923 RID: 100643 RVA: 0x007AC998 File Offset: 0x007AAD98
	private void _findAltarPositions()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMonsterByID(list, this.altarId, true);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] != null)
			{
				this.positionList.Add(list[i].GetPosition());
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06018924 RID: 100644 RVA: 0x007ACA04 File Offset: 0x007AAE04
	private void _summonHoods()
	{
		int num = 0;
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i].playerActor != null && !allPlayers[i].playerActor.IsDead())
			{
				num++;
			}
		}
		if (this.positionList.Count < num)
		{
			return;
		}
		int num2 = (int)base.owner.FrameRandom.Random((uint)this.positionList.Count);
		object[] array = new object[1];
		for (int j = 0; j < num; j++)
		{
			int index = (j + num2) % this.positionList.Count;
			if (base.owner.DoSummon(this.hoodId, base.level, EffectTable.eSummonPosType.ORIGIN, null, 1, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, array, true) && array[0] != null)
			{
				BeActor beActor = (BeActor)array[0];
				beActor.SetPosition(this.positionList[index], false, true, false);
			}
		}
	}

	// Token: 0x06018925 RID: 100645 RVA: 0x007ACB1F File Offset: 0x007AAF1F
	public override void OnCancel()
	{
		this._release();
	}

	// Token: 0x06018926 RID: 100646 RVA: 0x007ACB27 File Offset: 0x007AAF27
	public override void OnFinish()
	{
		this._release();
	}

	// Token: 0x06018927 RID: 100647 RVA: 0x007ACB2F File Offset: 0x007AAF2F
	private void _release()
	{
		this.positionList.Clear();
	}

	// Token: 0x04011BA4 RID: 72612
	private int hoodId = 30180011;

	// Token: 0x04011BA5 RID: 72613
	private int altarId = 30190011;

	// Token: 0x04011BA6 RID: 72614
	private List<VInt3> positionList = new List<VInt3>();
}
