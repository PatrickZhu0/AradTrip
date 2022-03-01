using System;
using System.Collections.Generic;

// Token: 0x0200435E RID: 17246
public class Mechanism2039 : BeMechanism
{
	// Token: 0x06017E15 RID: 97813 RVA: 0x007626F4 File Offset: 0x00760AF4
	public Mechanism2039(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017E16 RID: 97814 RVA: 0x00762754 File Offset: 0x00760B54
	public override void OnInit()
	{
		this.chainEffect = this.data.StringValueA[0];
		this.chainMaxDistance = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.buffDuration = TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true);
		this.breakTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017E17 RID: 97815 RVA: 0x00762824 File Offset: 0x00760C24
	public override void OnStart()
	{
		this.Clear();
		this.allTeamPlayersList.Clear();
		this.chainTimes = 3;
		if (base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonPlayerManager != null)
		{
			List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			if (allPlayers == null)
			{
				return;
			}
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers == null || allPlayers[i].playerActor == null)
				{
					return;
				}
				if (base.owner.GetPID() != allPlayers[i].playerActor.GetPID())
				{
					this.allTeamPlayersList.Add(allPlayers[i].playerActor);
				}
			}
		}
		BeActor playerInDistance = this.GetPlayerInDistance(base.owner);
		BeActor beActor = null;
		if (playerInDistance != null)
		{
			this.CreateChainEffect(base.owner, playerInDistance);
			this.bossDeadHandle = base.owner.RegisterEvent(BeEventType.onDead, delegate(object[] args)
			{
				this.ClearChainEffect(base.owner);
				this.ClearNewHandle();
			});
			this.firstDeadHandle = playerInDistance.RegisterEvent(BeEventType.onDead, delegate(object[] args)
			{
				this.ClearChainEffect(base.owner);
				this.ClearNewHandle();
			});
			base.owner.delayCaller.DelayCall(this.breakTime, delegate
			{
				this.ClearChainEffect(base.owner);
				this.ClearNewHandle();
			}, 0, 0, false);
			beActor = this.GetPlayerInDistance(playerInDistance);
		}
		if (playerInDistance != null && beActor != null)
		{
			this.chainTimes--;
			this.AddChain(playerInDistance, beActor);
			this.ChainNext();
		}
	}

	// Token: 0x06017E18 RID: 97816 RVA: 0x007629A3 File Offset: 0x00760DA3
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateActorDistance();
	}

	// Token: 0x06017E19 RID: 97817 RVA: 0x007629AC File Offset: 0x00760DAC
	private void AddChain(BeActor fromActor, BeActor toActor)
	{
		this.CreateChainEffect(fromActor, toActor);
		Mechanism2039.ChainUnit unitInChain = this.getUnitInChain(fromActor);
		Mechanism2039.ChainUnit unitInChain2 = this.getUnitInChain(toActor);
		this.AddUnitEventHandle(unitInChain);
		this.AddUnitEventHandle(unitInChain2);
		this.AddDeBuff(unitInChain);
		this.AddDeBuff(unitInChain2);
	}

	// Token: 0x06017E1A RID: 97818 RVA: 0x007629F0 File Offset: 0x00760DF0
	private void ChainNext()
	{
		if (this.chainList.Count < 1 || this.chainTimes <= 0)
		{
			return;
		}
		BeActor playerInDistance = this.GetPlayerInDistance(this.chainList[this.chainList.Count - 1].self);
		if (playerInDistance != null)
		{
			this.chainTimes--;
			this.AddChain(this.chainList[this.chainList.Count - 1].self, playerInDistance);
			this.ChainNext();
		}
	}

	// Token: 0x06017E1B RID: 97819 RVA: 0x00762A7D File Offset: 0x00760E7D
	public override void OnFinish()
	{
		this.chainTimes = 3;
		this.Clear();
		this.allTeamPlayersList.Clear();
	}

	// Token: 0x06017E1C RID: 97820 RVA: 0x00762A98 File Offset: 0x00760E98
	private BeActor GetPlayerInDistance(BeActor baseActor)
	{
		for (int i = 0; i < this.allTeamPlayersList.Count; i++)
		{
			if (this.IsInRange(baseActor, this.allTeamPlayersList[i]))
			{
				BeActor beActor = this.allTeamPlayersList[i];
				if (beActor.stateController.CanBeHit() && !beActor.IsDead())
				{
					this.allTeamPlayersList.Remove(this.allTeamPlayersList[i]);
					return beActor;
				}
			}
		}
		return null;
	}

	// Token: 0x06017E1D RID: 97821 RVA: 0x00762B24 File Offset: 0x00760F24
	private void AddDeBuff(Mechanism2039.ChainUnit unit)
	{
		if (unit.self != null && (int)unit.chainNum == 0)
		{
			unit.self.buffController.TryAddBuff(this.buffID, this.buffDuration, 1);
		}
		unit.chainNum = (sbyte)((int)unit.chainNum + 1);
	}

	// Token: 0x06017E1E RID: 97822 RVA: 0x00762B78 File Offset: 0x00760F78
	private void RemoveDeBuff(Mechanism2039.ChainUnit unit, bool bForce = false)
	{
		if (unit.self != null)
		{
			unit.chainNum = (sbyte)((int)unit.chainNum - 1);
			if (bForce || (int)unit.chainNum <= 0)
			{
				unit.self.buffController.RemoveBuff(this.buffID, 0, 0);
				this.ClearUnitEventHandle(unit);
				this.chainList.Remove(unit);
			}
		}
	}

	// Token: 0x06017E1F RID: 97823 RVA: 0x00762BE0 File Offset: 0x00760FE0
	private Mechanism2039.ChainUnit getUnitInChain(BeActor target)
	{
		for (int i = 0; i < this.chainList.Count; i++)
		{
			if (this.chainList[i].self.GetPID() == target.GetPID())
			{
				return this.chainList[i];
			}
		}
		Mechanism2039.ChainUnit chainUnit = new Mechanism2039.ChainUnit();
		chainUnit.self = target;
		this.chainList.Add(chainUnit);
		return chainUnit;
	}

	// Token: 0x06017E20 RID: 97824 RVA: 0x00762C54 File Offset: 0x00761054
	private void RemoveUnitInChain(Mechanism2039.ChainUnit unit, bool removeBuff = true)
	{
		if (unit == null)
		{
			return;
		}
		int num = this.chainList.IndexOf(unit);
		if (num < 0 || num >= this.chainList.Count)
		{
			return;
		}
		Mechanism2039.ChainUnit chainUnit = this.chainList[num];
		if (num == 0)
		{
			if (num + 1 < this.chainList.Count && num + 1 >= 0)
			{
				Mechanism2039.ChainUnit unit2 = this.chainList[num + 1];
				this.ClearChainEffect(chainUnit.self);
				if (removeBuff)
				{
					this.RemoveDeBuff(unit2, false);
				}
			}
		}
		else if (num == this.chainList.Count - 1)
		{
			if (num - 1 < this.chainList.Count && num - 1 >= 0)
			{
				Mechanism2039.ChainUnit chainUnit2 = this.chainList[num - 1];
				this.ClearChainEffect(chainUnit2.self);
				if (removeBuff)
				{
					this.RemoveDeBuff(chainUnit2, false);
				}
			}
		}
		else if (num != -1)
		{
			if (num - 1 >= 0 && num - 1 < this.chainList.Count)
			{
				Mechanism2039.ChainUnit chainUnit2 = this.chainList[num - 1];
				this.ClearChainEffect(chainUnit2.self);
				if (removeBuff)
				{
					this.RemoveDeBuff(chainUnit2, false);
				}
			}
			if (num + 1 >= 0 && num + 1 < this.chainList.Count)
			{
				Mechanism2039.ChainUnit unit2 = this.chainList[num + 1];
				this.ClearChainEffect(chainUnit.self);
				if (removeBuff)
				{
					this.RemoveDeBuff(unit2, false);
				}
			}
		}
		if (removeBuff)
		{
			this.RemoveDeBuff(chainUnit, true);
		}
	}

	// Token: 0x06017E21 RID: 97825 RVA: 0x00762DE8 File Offset: 0x007611E8
	private void ReplaceActorInUnit(Mechanism2039.ChainUnit unit, BeActor toActor)
	{
		this.ClearUnitEventHandle(unit);
		if (unit.self != null)
		{
			unit.self.buffController.RemoveBuff(this.buffID, 0, 0);
		}
		unit.self = toActor;
		if (unit.self != null)
		{
			unit.self.buffController.TryAddBuff(this.buffID, this.buffDuration, 1);
		}
		this.AddUnitEventHandle(unit);
		if (unit == null)
		{
			return;
		}
		int num = this.chainList.IndexOf(unit);
		if (num < 0 || num >= this.chainList.Count)
		{
			return;
		}
		Mechanism2039.ChainUnit chainUnit = this.chainList[num];
		if (num == 0)
		{
			if (num + 1 < this.chainList.Count && num + 1 >= 0)
			{
				Mechanism2039.ChainUnit chainUnit2 = this.chainList[num + 1];
				this.CreateChainEffect(chainUnit.self, chainUnit2.self);
			}
		}
		else if (num == this.chainList.Count - 1)
		{
			if (num - 1 >= 0 && num - 1 < this.chainList.Count)
			{
				Mechanism2039.ChainUnit chainUnit3 = this.chainList[num - 1];
				this.CreateChainEffect(chainUnit3.self, chainUnit.self);
			}
		}
		else if (num != -1)
		{
			if (num + 1 < this.chainList.Count && num + 1 >= 0)
			{
				Mechanism2039.ChainUnit chainUnit2 = this.chainList[num + 1];
				this.CreateChainEffect(chainUnit.self, chainUnit2.self);
			}
			if (num - 1 >= 0 && num - 1 < this.chainList.Count)
			{
				Mechanism2039.ChainUnit chainUnit3 = this.chainList[num - 1];
				this.CreateChainEffect(chainUnit3.self, chainUnit.self);
			}
		}
	}

	// Token: 0x06017E22 RID: 97826 RVA: 0x00762FB0 File Offset: 0x007613B0
	private void ClearUnitEventHandle(Mechanism2039.ChainUnit unit)
	{
		if (unit != null)
		{
			if (unit.handle != null)
			{
				unit.handle.Remove();
				unit.handle = null;
			}
			if (unit.monsterChangeHandle != null)
			{
				unit.monsterChangeHandle.Remove();
				unit.monsterChangeHandle = null;
			}
			if (unit.monsterRestoreHandle != null)
			{
				unit.monsterRestoreHandle.Remove();
				unit.monsterRestoreHandle = null;
			}
			if (unit.fakeRebornHandle != null)
			{
				unit.fakeRebornHandle.Remove();
				unit.fakeRebornHandle = null;
			}
		}
	}

	// Token: 0x06017E23 RID: 97827 RVA: 0x00763038 File Offset: 0x00761438
	private Mechanism2039.ChainUnit OnlyGetUnitByActor(BeEntity entity)
	{
		if (this.chainList == null)
		{
			return null;
		}
		for (int i = 0; i < this.chainList.Count; i++)
		{
			if (this.chainList[i].self.GetPID() == entity.GetPID())
			{
				return this.chainList[i];
			}
		}
		return null;
	}

	// Token: 0x06017E24 RID: 97828 RVA: 0x007630A0 File Offset: 0x007614A0
	private void AddUnitEventHandle(Mechanism2039.ChainUnit unit)
	{
		if (unit != null)
		{
			if (unit.handle == null)
			{
				unit.handle = unit.self.RegisterEvent(BeEventType.onDead, delegate(object[] args)
				{
					if (args != null && args.Length == 3)
					{
						BeEntity beEntity = args[2] as BeEntity;
						if (beEntity != null)
						{
							Mechanism2039.ChainUnit unit2 = this.OnlyGetUnitByActor(beEntity);
							this.RemoveUnitInChain(unit2, true);
						}
					}
				});
			}
			if (unit.monsterChangeHandle == null)
			{
				unit.monsterChangeHandle = unit.self.RegisterEvent(BeEventType.onMagicGirlMonsterChange, delegate(object[] args)
				{
					BeActor beActor = args[0] as BeActor;
					BeEntity entity = args[1] as BeEntity;
					Mechanism2039.ChainUnit chainUnit = this.OnlyGetUnitByActor(entity);
					if (beActor != null && chainUnit != null)
					{
						this.RemoveUnitInChain(chainUnit, false);
						this.ReplaceActorInUnit(chainUnit, beActor);
					}
				});
			}
			if (unit.monsterRestoreHandle == null)
			{
				unit.monsterRestoreHandle = unit.self.RegisterEvent(BeEventType.onMagicGirlMonsterRestore, delegate(object[] args)
				{
					BeActor beActor = args[0] as BeActor;
					BeEntity entity = args[1] as BeEntity;
					Mechanism2039.ChainUnit chainUnit = this.OnlyGetUnitByActor(entity);
					if (beActor != null && chainUnit != null)
					{
						this.RemoveUnitInChain(chainUnit, false);
						this.ReplaceActorInUnit(chainUnit, beActor);
					}
				});
			}
			if (unit.fakeRebornHandle == null)
			{
				unit.fakeRebornHandle = unit.self.RegisterEvent(BeEventType.OnFakeReborn, delegate(object[] args)
				{
					BeEntity beEntity = args[0] as BeEntity;
					if (beEntity != null)
					{
						Mechanism2039.ChainUnit unit2 = this.OnlyGetUnitByActor(beEntity);
						this.RemoveUnitInChain(unit2, true);
					}
				});
			}
		}
	}

	// Token: 0x06017E25 RID: 97829 RVA: 0x00763164 File Offset: 0x00761564
	private void Clear()
	{
		List<Mechanism2039.ChainUnit> list = new List<Mechanism2039.ChainUnit>();
		list.AddRange(this.chainList);
		for (int i = 0; i < list.Count; i++)
		{
			this.ClearChainEffect(list[i].self);
			this.ClearUnitEventHandle(list[i]);
			if (i != list.Count - 1)
			{
				this.RemoveDeBuff(list[i + 1], false);
			}
			this.RemoveDeBuff(list[i], false);
		}
		if (base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonPlayerManager != null)
		{
			List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			if (allPlayers != null)
			{
				for (int j = 0; j < allPlayers.Count; j++)
				{
					if (allPlayers[j].playerActor != null)
					{
						allPlayers[j].playerActor.buffController.RemoveBuff(this.buffID, 0, 0);
					}
				}
			}
		}
		this.chainList.Clear();
		this.ClearNewHandle();
	}

	// Token: 0x06017E26 RID: 97830 RVA: 0x0076327D File Offset: 0x0076167D
	private void ClearNewHandle()
	{
		if (this.bossDeadHandle != null)
		{
			this.bossDeadHandle.Remove();
			this.bossDeadHandle = null;
		}
		if (this.firstDeadHandle != null)
		{
			this.firstDeadHandle.Remove();
			this.firstDeadHandle = null;
		}
	}

	// Token: 0x06017E27 RID: 97831 RVA: 0x007632BC File Offset: 0x007616BC
	private void UpdateActorDistance()
	{
		for (int i = 0; i < this.chainList.Count - 1; i++)
		{
			if (this.chainList.Count == 0 || i <= -1 || i >= this.chainList.Count - 1)
			{
				return;
			}
			if (!this.IsInRange(this.chainList[i].self, this.chainList[i + 1].self))
			{
				this.ClearChainEffect(this.chainList[i].self);
				Mechanism2039.ChainUnit chainUnit = this.chainList[i];
				Mechanism2039.ChainUnit chainUnit2 = this.chainList[i + 1];
				this.RemoveDeBuff(chainUnit, false);
				this.RemoveDeBuff(chainUnit2, false);
				if ((int)chainUnit.chainNum == 0)
				{
					i--;
				}
				if ((int)chainUnit2.chainNum == 0)
				{
					i--;
				}
			}
		}
	}

	// Token: 0x06017E28 RID: 97832 RVA: 0x007633A4 File Offset: 0x007617A4
	private bool IsInRange(BeActor player1, BeActor player2)
	{
		return !(player1.GetDistance(player2) > this.chainMaxDistance);
	}

	// Token: 0x06017E29 RID: 97833 RVA: 0x007633C5 File Offset: 0x007617C5
	private void CreateChainEffect(BeActor fromActor, BeActor toActor)
	{
		if (fromActor == null || toActor == null || fromActor.m_pkGeActor == null)
		{
			return;
		}
		fromActor.m_pkGeActor.CreateChainEffect(toActor, this.chainEffect, EffectTimeType.SYNC_ANIMATION, false);
	}

	// Token: 0x06017E2A RID: 97834 RVA: 0x007633F3 File Offset: 0x007617F3
	private void ClearChainEffect(BeActor actor)
	{
		if (actor == null || actor.m_pkGeActor == null)
		{
			return;
		}
		actor.m_pkGeActor.ClearChainEffect();
	}

	// Token: 0x040112FB RID: 70395
	private int buffDuration = -1;

	// Token: 0x040112FC RID: 70396
	private string chainEffect = string.Empty;

	// Token: 0x040112FD RID: 70397
	private VInt chainMaxDistance = VInt.one.i * 5;

	// Token: 0x040112FE RID: 70398
	private int buffID;

	// Token: 0x040112FF RID: 70399
	private int breakTime;

	// Token: 0x04011300 RID: 70400
	private BeEventHandle bossDeadHandle;

	// Token: 0x04011301 RID: 70401
	private BeEventHandle firstDeadHandle;

	// Token: 0x04011302 RID: 70402
	private int chainTimes = 3;

	// Token: 0x04011303 RID: 70403
	private List<Mechanism2039.ChainUnit> chainList = new List<Mechanism2039.ChainUnit>();

	// Token: 0x04011304 RID: 70404
	private List<BeActor> allTeamPlayersList = new List<BeActor>();

	// Token: 0x0200435F RID: 17247
	private class ChainUnit
	{
		// Token: 0x04011305 RID: 70405
		public BeActor self;

		// Token: 0x04011306 RID: 70406
		public BeEventHandle handle;

		// Token: 0x04011307 RID: 70407
		public BeEventHandle monsterChangeHandle;

		// Token: 0x04011308 RID: 70408
		public BeEventHandle monsterRestoreHandle;

		// Token: 0x04011309 RID: 70409
		public BeEventHandle fakeRebornHandle;

		// Token: 0x0401130A RID: 70410
		public sbyte chainNum;
	}
}
