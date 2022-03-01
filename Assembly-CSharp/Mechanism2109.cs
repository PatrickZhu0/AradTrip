using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x020043A5 RID: 17317
public class Mechanism2109 : BeMechanism
{
	// Token: 0x06018035 RID: 98357 RVA: 0x00772679 File Offset: 0x00770A79
	public Mechanism2109(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06018036 RID: 98358 RVA: 0x007726B4 File Offset: 0x00770AB4
	public override void OnInit()
	{
		this.mChainEffectPath = this.data.StringValueA[0];
		this.mDamageRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mOnHitBuffInfo = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mFinishBuff = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mBreakBuffInfo = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06018037 RID: 98359 RVA: 0x00772778 File Offset: 0x00770B78
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this._InitTargetsChain();
		this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, new BeEventHandle.Del(this._OnOwnerAddBuff));
	}

	// Token: 0x06018038 RID: 98360 RVA: 0x007727AB File Offset: 0x00770BAB
	public override void OnFinish()
	{
		this.RemoveAllHandleUnit();
	}

	// Token: 0x06018039 RID: 98361 RVA: 0x007727B4 File Offset: 0x00770BB4
	private void _InitTargetsChain()
	{
		if (base.owner != null && base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonPlayerManager != null)
		{
			List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			if (allPlayers.Count < 2)
			{
				base.Finish();
				return;
			}
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i].playerActor != null && !allPlayers[i].playerActor.IsDead())
				{
					Mechanism2109.ChainUnit item = default(Mechanism2109.ChainUnit);
					this._InitChainUnit(ref item, allPlayers[i].playerActor);
					this.mPlayerList.Add(item);
					if (this.mPlayerList.Count > 1)
					{
						this.CreateChainEffect(this.mPlayerList[this.mPlayerList.Count - 1].Actor, this.mPlayerList[this.mPlayerList.Count - 2].Actor);
					}
				}
			}
		}
	}

	// Token: 0x0601803A RID: 98362 RVA: 0x007728D8 File Offset: 0x00770CD8
	private void _InitChainUnit(ref Mechanism2109.ChainUnit unit, BeActor entity)
	{
		unit.Actor = entity;
		if (entity.isSpecialMonster)
		{
			BeEntity owner = entity.GetOwner();
			unit.OnChangeToMonster = entity.RegisterEvent(BeEventType.onMagicGirlMonsterRestore, new BeEventHandle.Del(this._OnChangeToMonster));
			unit.OnDead = owner.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this._OnActorDead));
			unit.OnFakerReborn = owner.RegisterEvent(BeEventType.OnFakeReborn, new BeEventHandle.Del(this._OnFakeReborn));
		}
		else
		{
			unit.OnChangeToMonster = entity.RegisterEvent(BeEventType.onMagicGirlMonsterChange, new BeEventHandle.Del(this._OnChangeToMonster));
			unit.OnDead = entity.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this._OnActorDead));
			unit.OnFakerReborn = entity.RegisterEvent(BeEventType.OnFakeReborn, new BeEventHandle.Del(this._OnFakeReborn));
		}
		unit.OnBeHurt = entity.RegisterEvent(BeEventType.onHit, new BeEventHandle.Del(this._OnBeHit));
		unit.OnBeBuffDamage = entity.RegisterEventNew(BeEventType.OnBuffDoHurt, new BeEvent.BeEventHandleNew.Function(this._OnBeBuffBuffDamage));
		unit.OnBuffDamage1 = entity.RegisterEvent(BeEventType.OnBuffDamage, new BeEventHandle.Del(this._OnBebuffDatage));
		if (entity != null && entity.buffController != null)
		{
			entity.buffController.TryAddBuff(this.mOnHitBuffInfo, null, false, base.owner, this.level);
		}
	}

	// Token: 0x0601803B RID: 98363 RVA: 0x00772A30 File Offset: 0x00770E30
	private void _ChangeActorEvent(ref Mechanism2109.ChainUnit unit, BeActor to)
	{
		unit.OnChangeToMonster.Remove();
		if (to != null && to.isSpecialMonster)
		{
			unit.OnChangeToMonster = to.RegisterEvent(BeEventType.onMagicGirlMonsterRestore, new BeEventHandle.Del(this._OnChangeToMonster));
		}
		else
		{
			unit.OnChangeToMonster = to.RegisterEvent(BeEventType.onMagicGirlMonsterChange, new BeEventHandle.Del(this._OnChangeToMonster));
		}
		unit.OnBeHurt.Remove();
		unit.OnBeHurt = to.RegisterEvent(BeEventType.onHit, new BeEventHandle.Del(this._OnBeHit));
		unit.OnBeBuffDamage.Remove();
		unit.OnBeBuffDamage = to.RegisterEventNew(BeEventType.OnBuffDoHurt, new BeEvent.BeEventHandleNew.Function(this._OnBeBuffBuffDamage));
		unit.OnBuffDamage1.Remove();
		unit.OnBuffDamage1 = to.RegisterEvent(BeEventType.OnBuffDamage, new BeEventHandle.Del(this._OnBebuffDatage));
	}

	// Token: 0x0601803C RID: 98364 RVA: 0x00772B10 File Offset: 0x00770F10
	private void _OnOwnerAddBuff(object[] args)
	{
		if (args.Length < 1)
		{
			return;
		}
		BeBuff beBuff = args[0] as BeBuff;
		if (beBuff != null && beBuff.buffID == this.mFinishBuff)
		{
			base.Finish();
		}
	}

	// Token: 0x0601803D RID: 98365 RVA: 0x00772B50 File Offset: 0x00770F50
	private void _OnBeHit(object[] args)
	{
		if (args.Length < 9)
		{
			return;
		}
		int num = (int)args[0];
		int num2 = (int)args[4];
		BeEntity beEntity = args[2] as BeEntity;
		if (beEntity != null)
		{
			BeEntity topOwner = beEntity.GetTopOwner(beEntity);
			if (topOwner != null && beEntity.GetPID() != base.owner.GetPID() && topOwner.GetPID() != base.owner.GetPID())
			{
				return;
			}
		}
		bool flag = (bool)args[5];
		this.magicElementTypeList.Clear();
		List<int> list = args[6] as List<int>;
		if (list != null)
		{
			this.magicElementTypeList.AddRange(list);
		}
		BeEntity beEntity2 = args[8] as BeEntity;
		int num3 = num * this.mDamageRate / 1000;
		for (int i = 0; i < this.mPlayerList.Count; i++)
		{
			BeActor actor = this.mPlayerList[i].Actor;
			if (actor != null && beEntity2 != null && actor.GetPID() != beEntity2.GetPID() && actor.stateController != null && !actor.stateController.HasBuffState(BeBuffStateType.INVINCIBLE))
			{
				this.absorbDamage[0] = false;
				this.vals[0] = num3;
				BeEntity beEntity3 = actor;
				BeEventType type = BeEventType.onBeHitAfterFinalDamage;
				object[] array = new object[8];
				array[0] = this.vals;
				array[1] = num2;
				array[2] = this.absorbDamage;
				array[3] = base.owner;
				array[4] = flag;
				array[5] = actor.GetPosition();
				array[6] = this.magicElementTypeList;
				beEntity3.TriggerEvent(type, array);
				if (!this.absorbDamage[0])
				{
					actor.DoHurt(this.vals[0], null, HitTextType.NORMAL, base.owner, HitTextType.NORMAL, false);
				}
			}
		}
	}

	// Token: 0x0601803E RID: 98366 RVA: 0x00772D18 File Offset: 0x00771118
	private void _OnBeBuffBuffDamage(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		BeEntity beEntity = param.m_Obj as BeEntity;
		int value = @int * this.mDamageRate / 1000;
		for (int i = 0; i < this.mPlayerList.Count; i++)
		{
			BeActor actor = this.mPlayerList[i].Actor;
			if (actor != null && beEntity != null && actor.GetPID() != beEntity.GetPID() && actor.stateController != null && !actor.stateController.HasBuffState(BeBuffStateType.INVINCIBLE))
			{
				actor.DoHurt(value, null, HitTextType.NORMAL, base.owner, HitTextType.NORMAL, false);
			}
		}
	}

	// Token: 0x0601803F RID: 98367 RVA: 0x00772DCC File Offset: 0x007711CC
	private void _OnBebuffDatage(object[] args)
	{
		if (args.Length < 3)
		{
			return;
		}
		int num = (int)args[0];
		BeEntity beEntity = args[2] as BeEntity;
		int value = num * this.mDamageRate / 1000;
		for (int i = 0; i < this.mPlayerList.Count; i++)
		{
			BeActor actor = this.mPlayerList[i].Actor;
			if (actor != null && beEntity != null && actor.GetPID() != beEntity.GetPID() && actor.stateController != null && !actor.stateController.HasBuffState(BeBuffStateType.INVINCIBLE))
			{
				actor.DoHurt(value, null, HitTextType.NORMAL, base.owner, HitTextType.NORMAL, false);
			}
		}
	}

	// Token: 0x06018040 RID: 98368 RVA: 0x00772E88 File Offset: 0x00771288
	private void _OnChangeToMonster(object[] args)
	{
		if (args.Length < 2)
		{
			return;
		}
		BeActor to = args[0] as BeActor;
		BeActor from = args[1] as BeActor;
		this.SwitchActor(from, to);
	}

	// Token: 0x06018041 RID: 98369 RVA: 0x00772EBC File Offset: 0x007712BC
	private void _OnFakeReborn(object[] args)
	{
		if (args.Length > 0)
		{
			BeEntity entity = args[0] as BeEntity;
			this.RemoveUnit(entity);
		}
	}

	// Token: 0x06018042 RID: 98370 RVA: 0x00772EE4 File Offset: 0x007712E4
	private void SwitchActor(BeActor from, BeActor to)
	{
		if (from == null || to == null)
		{
			return;
		}
		for (int i = 0; i < this.mPlayerList.Count; i++)
		{
			BeActor actor = this.mPlayerList[i].Actor;
			Mechanism2109.ChainUnit chainUnit = this.mPlayerList[i];
			if (actor != null && actor.GetPID() == from.GetPID())
			{
				this._ChangeActorEvent(ref chainUnit, to);
				this.ClearChainEffect(actor);
				chainUnit.Actor = to;
				if (i > 0)
				{
					this.CreateChainEffect(this.mPlayerList[i].Actor, this.mPlayerList[i - 1].Actor);
				}
				break;
			}
		}
	}

	// Token: 0x06018043 RID: 98371 RVA: 0x00772FAC File Offset: 0x007713AC
	private void _OnActorDead(object[] args)
	{
		if (args.Length < 3)
		{
			return;
		}
		BeEntity entity = args[2] as BeEntity;
		this.RemoveUnit(entity);
	}

	// Token: 0x06018044 RID: 98372 RVA: 0x00772FD4 File Offset: 0x007713D4
	private void RemoveAllHandleUnit()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		VFactor vfactor = VFactor.one;
		for (int i = 0; i < this.mPlayerList.Count; i++)
		{
			Mechanism2109.ChainUnit chainUnit = this.mPlayerList[i];
			BeActor actor = this.mPlayerList[i].Actor;
			if (actor != null && actor.stateController != null)
			{
				actor.buffController.TryAddBuff(this.mBreakBuffInfo, null, false, base.owner, this.level);
				list.Add(actor);
				if (actor.GetEntityData() != null)
				{
					VFactor hprate = actor.GetEntityData().GetHPRate();
					vfactor = ((!(vfactor > hprate)) ? vfactor : hprate);
				}
			}
			this.ClearChainEffect(actor);
			this.ReleaseUnit(ref chainUnit);
		}
		this.mPlayerList.Clear();
		if (list.Count > 1)
		{
			VFactor vfactor2 = new VFactor(1L, 100L);
			vfactor = ((!(vfactor > vfactor2)) ? vfactor2 : vfactor);
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].stateController != null && list[j].GetEntityData() != null && !list[j].stateController.HasBuffState(BeBuffStateType.INVINCIBLE))
				{
					int num = list[j].GetEntityData().GetMaxHP() * (list[j].GetEntityData().GetHPRate() - vfactor);
					if (num != 0)
					{
						list[j].DoHurt(num, null, HitTextType.NORMAL, base.owner, HitTextType.NORMAL, false);
					}
				}
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06018045 RID: 98373 RVA: 0x00773198 File Offset: 0x00771598
	private void RemoveUnit(BeEntity entity)
	{
		if (entity == null)
		{
			return;
		}
		for (int i = 0; i < this.mPlayerList.Count; i++)
		{
			BeActor actor = this.mPlayerList[i].Actor;
			if (actor != null)
			{
				Mechanism2109.ChainUnit chainUnit = this.mPlayerList[i];
				if (actor.GetPID() == entity.GetPID())
				{
					this.ClearChainEffect(actor);
					if (i > 0 && i + 1 < this.mPlayerList.Count)
					{
						this.ClearChainEffect(this.mPlayerList[i + 1].Actor);
						this.CreateChainEffect(this.mPlayerList[i + 1].Actor, this.mPlayerList[i - 1].Actor);
					}
					else if (i + 1 < this.mPlayerList.Count)
					{
						this.ClearChainEffect(this.mPlayerList[i + 1].Actor);
					}
					this.ReleaseUnit(ref chainUnit);
					this.mPlayerList.RemoveAt(i);
					break;
				}
			}
		}
		if (this.mPlayerList.Count < 2)
		{
			base.Finish();
		}
	}

	// Token: 0x06018046 RID: 98374 RVA: 0x007732E0 File Offset: 0x007716E0
	private void ReleaseUnit(ref Mechanism2109.ChainUnit unit)
	{
		unit.Actor = null;
		if (unit.OnDead != null)
		{
			unit.OnDead.Remove();
			unit.OnDead = null;
		}
		if (unit.OnChangeToMonster != null)
		{
			unit.OnChangeToMonster.Remove();
			unit.OnChangeToMonster = null;
		}
		if (unit.OnBeBuffDamage != null)
		{
			unit.OnBeBuffDamage.Remove();
			unit.OnBeBuffDamage = null;
		}
		if (unit.OnBeHurt != null)
		{
			unit.OnBeHurt.Remove();
			unit.OnBeHurt = null;
		}
		if (unit.OnFakerReborn != null)
		{
			unit.OnFakerReborn.Remove();
			unit.OnFakerReborn = null;
		}
		if (unit.OnBuffDamage1 != null)
		{
			unit.OnBuffDamage1.Remove();
			unit.OnBuffDamage1 = null;
		}
	}

	// Token: 0x06018047 RID: 98375 RVA: 0x007733A2 File Offset: 0x007717A2
	private void CreateChainEffect(BeActor fromActor, BeActor toActor)
	{
		if (fromActor == null || toActor == null || fromActor.m_pkGeActor == null)
		{
			return;
		}
		fromActor.m_pkGeActor.CreateChainEffect(toActor, this.mChainEffectPath, EffectTimeType.BUFF, true);
	}

	// Token: 0x06018048 RID: 98376 RVA: 0x007733D0 File Offset: 0x007717D0
	private void ClearChainEffect(BeActor actor)
	{
		if (actor == null || actor.m_pkGeActor == null)
		{
			return;
		}
		actor.m_pkGeActor.ClearChainEffect();
	}

	// Token: 0x040114C6 RID: 70854
	protected int mDamageRate;

	// Token: 0x040114C7 RID: 70855
	protected string mChainEffectPath;

	// Token: 0x040114C8 RID: 70856
	protected int mOnHitBuffInfo;

	// Token: 0x040114C9 RID: 70857
	protected int mFinishBuff;

	// Token: 0x040114CA RID: 70858
	protected int mBreakBuffInfo;

	// Token: 0x040114CB RID: 70859
	private List<Mechanism2109.ChainUnit> mPlayerList = new List<Mechanism2109.ChainUnit>();

	// Token: 0x040114CC RID: 70860
	private bool[] absorbDamage = new bool[1];

	// Token: 0x040114CD RID: 70861
	private int[] vals = new int[1];

	// Token: 0x040114CE RID: 70862
	private List<int> magicElementTypeList = new List<int>();

	// Token: 0x020043A6 RID: 17318
	protected struct ChainUnit
	{
		// Token: 0x040114CF RID: 70863
		public BeActor Actor;

		// Token: 0x040114D0 RID: 70864
		public BeEventHandle OnDead;

		// Token: 0x040114D1 RID: 70865
		public BeEventHandle OnChangeToMonster;

		// Token: 0x040114D2 RID: 70866
		public BeEventHandle OnBeHurt;

		// Token: 0x040114D3 RID: 70867
		public BeEvent.BeEventHandleNew OnBeBuffDamage;

		// Token: 0x040114D4 RID: 70868
		public BeEventHandle OnFakerReborn;

		// Token: 0x040114D5 RID: 70869
		public BeEventHandle OnBuffDamage1;
	}
}
