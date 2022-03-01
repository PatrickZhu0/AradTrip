using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x020043A7 RID: 17319
public class Mechanism2110 : BeMechanism
{
	// Token: 0x06018049 RID: 98377 RVA: 0x007733F0 File Offset: 0x007717F0
	public Mechanism2110(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601804A RID: 98378 RVA: 0x00773480 File Offset: 0x00771880
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			this.mBuffInfoSets.Add(valueFromUnionCell);
			BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(valueFromUnionCell, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.mBuffSets.Add(tableItem.BuffID);
			}
			else
			{
				this.mBuffSets.Add(0);
			}
		}
		for (int j = 0; j < this.data.ValueB.Count; j++)
		{
			this.mMonsterSets.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
		}
		this.mNaiBaBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		BuffInfoTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(this.mNaiBaBuffInfoID, string.Empty, string.Empty);
		if (tableItem2 != null)
		{
			this.mNaiBaBuffID = tableItem2.BuffID;
		}
		for (int k = 0; k < this.data.ValueD.Count; k++)
		{
			this.mMonsterBuffInfoSets.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[k], this.level, true));
		}
	}

	// Token: 0x0601804B RID: 98379 RVA: 0x00773614 File Offset: 0x00771A14
	private bool IsNaiBa(BeActor target)
	{
		return target != null && target.isMainActor && base.owner.GetEntityData() != null && target.GetEntityData().professtion == 62;
	}

	// Token: 0x0601804C RID: 98380 RVA: 0x00773648 File Offset: 0x00771A48
	public override void OnStart()
	{
		if (base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return;
		}
		this.mRandBuffLib.Clear();
		this.mActorBuff.Clear();
		this.mRandMosnterLib.Clear();
		this.mRandBuffInfoLib.Clear();
		this.mRandMonsterBuffInfoLib.Clear();
		this.mRandBuffLib.AddRange(this.mBuffSets);
		this.mRandBuffInfoLib.AddRange(this.mBuffInfoSets);
		this.mRandMosnterLib.AddRange(this.mMonsterSets);
		this.mRandMonsterBuffInfoLib.AddRange(this.mMonsterBuffInfoSets);
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers == null)
		{
			return;
		}
		this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onHurtEntity, new BeEvent.BeEventHandleNew.Function(this._onHurtEntity));
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			int num = base.FrameRandom.InRange(0, this.mRandBuffInfoLib.Count);
			if (num >= this.mRandBuffInfoLib.Count)
			{
				Logger.LogErrorFormat("Nothing Can Allocate to player", new object[0]);
				return;
			}
			playerActor.buffController.TryAddBuff(this.mRandBuffInfoLib[num], null, false, null, 0);
			if (this.IsNaiBa(playerActor))
			{
				playerActor.buffController.TryAddBuff(this.mNaiBaBuffInfoID, null, false, null, 0);
			}
			this.mActorBuff.Add(new Mechanism2110.ActorBuffInfo
			{
				buffID = this.mRandBuffLib[num],
				actor = ((!playerActor.isSpecialMonster) ? playerActor : null),
				monster = ((!playerActor.isSpecialMonster) ? null : playerActor)
			});
			this.mRandBuffInfoLib.RemoveAt(num);
			this.mRandBuffLib.RemoveAt(num);
			this.mHandleListNew.Add(playerActor.RegisterEventNew(BeEventType.OnDoAttckResult, new BeEvent.BeEventHandleNew.Function(this._onDoAttackTo)));
			this.mHandList.Add(playerActor.RegisterEvent(BeEventType.onMagicGirlMonsterChange, new BeEventHandle.Del(this.onChangeMonster)));
			this.mHandList.Add(playerActor.RegisterEvent(BeEventType.onMagicGirlMonsterRestore, new BeEventHandle.Del(this.onMagicGirlRestore)));
			if (this.mRandMosnterLib.Count > num)
			{
				int num2 = this.mRandMosnterLib[num];
				VInt3 sceneCenterPosition = base.owner.CurrentBeScene.GetSceneCenterPosition();
				VInt3 pos = BeAIManager.FindStandPositionNew(sceneCenterPosition, base.owner.CurrentBeScene, false, false, 30);
				BeActor beActor = base.owner.CurrentBeScene.SummonMonster(num2 + this.level * 100, pos, base.owner.GetCamp(), base.owner, false, 0, true, 0, false, false);
				if (beActor != null && beActor.buffController != null && this.mRandMonsterBuffInfoLib.Count > num)
				{
					int buffInfoID = this.mRandMonsterBuffInfoLib[num];
					BeBuff beBuff = beActor.buffController.TryAddBuff(buffInfoID, null, false, null, 0);
					if (!playerActor.isLocalActor && beBuff != null)
					{
						beBuff.HideEffect();
					}
					this.mRandMonsterBuffInfoLib.RemoveAt(num);
				}
				this.mRandMosnterLib.RemoveAt(num);
			}
		}
	}

	// Token: 0x0601804D RID: 98381 RVA: 0x007739A4 File Offset: 0x00771DA4
	private void _checkAttackStatus(BeEvent.BeEventParam param, int status)
	{
		BeEntity beEntity = param.m_Obj as BeEntity;
		if (beEntity != null)
		{
			beEntity = beEntity.GetTopOwner(beEntity);
		}
		BeActor beActor = param.m_Obj2 as BeActor;
		if (beEntity == null || beActor == null)
		{
			return;
		}
		for (int i = 0; i < this.mActorBuff.Count; i++)
		{
			Mechanism2110.ActorBuffInfo actorBuffInfo = this.mActorBuff[i];
			if (actorBuffInfo != null && actorBuffInfo.IsActor(beEntity.GetPID()))
			{
				if (actorBuffInfo.HasBuff())
				{
					bool flag = false;
					bool flag2 = false;
					for (int j = 0; j < this.mBuffSets.Count; j++)
					{
						if (beActor.buffController.HasBuffByID(this.mBuffSets[j]) != null)
						{
							flag2 = true;
							if (this.mBuffSets[j] == actorBuffInfo.buffID)
							{
								flag = true;
								break;
							}
						}
					}
					if (flag2 && !flag)
					{
						param.m_Int = status;
					}
				}
			}
		}
	}

	// Token: 0x0601804E RID: 98382 RVA: 0x00773AAF File Offset: 0x00771EAF
	private void _onDoAttackTo(BeEvent.BeEventParam param)
	{
		this._checkAttackStatus(param, 3);
	}

	// Token: 0x0601804F RID: 98383 RVA: 0x00773AB9 File Offset: 0x00771EB9
	private void _onHurtEntity(BeEvent.BeEventParam param)
	{
		this._checkAttackStatus(param, 0);
	}

	// Token: 0x06018050 RID: 98384 RVA: 0x00773AC4 File Offset: 0x00771EC4
	private void onChangeMonster(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		BeActor beActor2 = args[1] as BeActor;
		if (beActor == null || beActor2 == null)
		{
			return;
		}
		for (int i = 0; i < this.mActorBuff.Count; i++)
		{
			if (this.mActorBuff[i].actor != null && this.mActorBuff[i].actor.GetPID() == beActor2.GetPID())
			{
				beActor.buffController.TryAddBuff(this.mActorBuff[i].buffID, null, false, null, 0);
				this.mActorBuff[i].monster = beActor;
			}
		}
	}

	// Token: 0x06018051 RID: 98385 RVA: 0x00773B78 File Offset: 0x00771F78
	private void onMagicGirlRestore(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		BeEntity beEntity = args[1] as BeEntity;
		if (beEntity == null || beActor == null)
		{
			return;
		}
		for (int i = 0; i < this.mActorBuff.Count; i++)
		{
			if (this.mActorBuff[i].monster != null && this.mActorBuff[i].monster.GetPID() == beEntity.GetPID())
			{
				beActor.buffController.TryAddBuff(this.mActorBuff[i].buffID, null, false, null, 0);
			}
		}
	}

	// Token: 0x06018052 RID: 98386 RVA: 0x00773C18 File Offset: 0x00772018
	public override void OnFinish()
	{
		for (int i = 0; i < this.mHandList.Count; i++)
		{
			if (this.mHandList[i] != null)
			{
				this.mHandList[i].Remove();
			}
		}
		this.mHandList.Clear();
		for (int j = 0; j < this.mHandleListNew.Count; j++)
		{
			if (this.mHandleListNew[j] != null)
			{
				this.mHandleListNew[j].Remove();
			}
		}
		this.mHandleListNew.Clear();
		if (base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int k = 0; k < allPlayers.Count; k++)
		{
			BeActor playerActor = allPlayers[k].playerActor;
			for (int l = 0; l < this.mActorBuff.Count; l++)
			{
				Mechanism2110.ActorBuffInfo actorBuffInfo = this.mActorBuff[l];
				if (this.IsNaiBa(playerActor))
				{
					playerActor.buffController.RemoveBuff(this.mNaiBaBuffID, 0, 0);
				}
				if ((actorBuffInfo.actor != null && actorBuffInfo.actor.GetPID() == playerActor.GetPID()) || (actorBuffInfo.monster != null && actorBuffInfo.monster.GetPID() == playerActor.GetPID()))
				{
					playerActor.buffController.RemoveBuff(actorBuffInfo.buffID, 0, 0);
				}
				List<BeEntity> saveTempList = base.owner.CurrentBeScene.GetSaveTempList();
				if (saveTempList != null)
				{
					for (int m = 0; m < saveTempList.Count; m++)
					{
						BeActor beActor = saveTempList[m] as BeActor;
						if (beActor != null)
						{
							if ((actorBuffInfo.actor != null && actorBuffInfo.actor.GetPID() == beActor.GetPID()) || (actorBuffInfo.monster != null && actorBuffInfo.monster.GetPID() == beActor.GetPID()))
							{
								beActor.buffController.RemoveBuff(actorBuffInfo.buffID, 0, 0);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x040114D6 RID: 70870
	private List<int> mBuffInfoSets = new List<int>();

	// Token: 0x040114D7 RID: 70871
	private List<int> mBuffSets = new List<int>();

	// Token: 0x040114D8 RID: 70872
	private List<int> mMonsterSets = new List<int>();

	// Token: 0x040114D9 RID: 70873
	private List<int> mRandBuffInfoLib = new List<int>();

	// Token: 0x040114DA RID: 70874
	private List<int> mRandBuffLib = new List<int>();

	// Token: 0x040114DB RID: 70875
	private List<int> mRandMosnterLib = new List<int>();

	// Token: 0x040114DC RID: 70876
	private List<Mechanism2110.ActorBuffInfo> mActorBuff = new List<Mechanism2110.ActorBuffInfo>();

	// Token: 0x040114DD RID: 70877
	private List<BeEventHandle> mHandList = new List<BeEventHandle>();

	// Token: 0x040114DE RID: 70878
	private List<BeEvent.BeEventHandleNew> mHandleListNew = new List<BeEvent.BeEventHandleNew>();

	// Token: 0x040114DF RID: 70879
	private int mNaiBaBuffInfoID;

	// Token: 0x040114E0 RID: 70880
	private int mNaiBaBuffID;

	// Token: 0x040114E1 RID: 70881
	private List<int> mMonsterBuffInfoSets = new List<int>();

	// Token: 0x040114E2 RID: 70882
	private List<int> mRandMonsterBuffInfoLib = new List<int>();

	// Token: 0x020043A8 RID: 17320
	private class ActorBuffInfo
	{
		// Token: 0x06018054 RID: 98388 RVA: 0x00773E8A File Offset: 0x0077228A
		public bool IsActor(int pid)
		{
			return (this.actor != null && this.actor.GetPID() == pid) || (this.monster != null && this.monster.GetPID() == pid);
		}

		// Token: 0x06018055 RID: 98389 RVA: 0x00773EC8 File Offset: 0x007722C8
		public bool HasBuff()
		{
			if (this.actor != null)
			{
				return this.actor.buffController.HasBuffByID(this.buffID) != null;
			}
			return this.monster != null && this.monster.buffController.HasBuffByID(this.buffID) != null;
		}

		// Token: 0x040114E3 RID: 70883
		public int buffID;

		// Token: 0x040114E4 RID: 70884
		public BeActor actor;

		// Token: 0x040114E5 RID: 70885
		public BeActor monster;
	}
}
