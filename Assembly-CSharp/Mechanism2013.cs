using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004343 RID: 17219
public class Mechanism2013 : BeMechanism
{
	// Token: 0x06017D58 RID: 97624 RVA: 0x0075D484 File Offset: 0x0075B884
	public Mechanism2013(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D59 RID: 97625 RVA: 0x0075D504 File Offset: 0x0075B904
	public override void OnInit()
	{
		base.OnInit();
		this.dis = new VInt((float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f);
		this.totalTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017D5A RID: 97626 RVA: 0x0075D574 File Offset: 0x0075B974
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = args[0] as BeBuff;
			if (beBuff.buffID == this.positiveBuffID)
			{
				this.selfFlag = 1;
			}
			if (beBuff.buffID == this.negativeBuffID)
			{
				this.selfFlag = -1;
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.positiveBuffID || num == this.negativeBuffID)
			{
				this.selfFlag = 0;
			}
		});
	}

	// Token: 0x06017D5B RID: 97627 RVA: 0x0075D5C8 File Offset: 0x0075B9C8
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (base.owner == null || base.owner.IsDead())
		{
			return;
		}
		this.damageTimer += deltaTime;
		if (this.damageTimer <= 100)
		{
			return;
		}
		this.damageTimer = 0;
		this.CalcHp();
	}

	// Token: 0x06017D5C RID: 97628 RVA: 0x0075D624 File Offset: 0x0075BA24
	private void CalcHp()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMainActorInRange(list, base.owner.GetPosition(), this.dis);
		if (list.Count < 2)
		{
			base.owner.StopSpellBar(eDungeonCharactorBar.Progress, true);
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] != base.owner)
			{
				BeBuff beBuff = list[i].buffController.HasBuffByID(this.positiveBuffID);
				BeBuff beBuff2 = list[i].buffController.HasBuffByID(this.negativeBuffID);
				VInt3 vint;
				base.owner.GetPosition().z = vint.z + VInt.one.i;
				if (this.selfFlag == 0)
				{
					if (beBuff != null || beBuff2 != null)
					{
						this.OnHurtEntity(this.hurtID);
					}
				}
				else if (this.selfFlag == 1)
				{
					if (beBuff != null)
					{
						this.OnHurtEntity(this.hurtID1);
					}
					else if (beBuff2 != null)
					{
						this.SetSpellBar(list[i]);
					}
					else if (beBuff2 == null)
					{
						base.owner.StopSpellBar(eDungeonCharactorBar.Progress, true);
					}
				}
				else if (this.selfFlag == -1)
				{
					if (beBuff2 != null)
					{
						this.OnHurtEntity(this.hurtID1);
					}
					else if (beBuff != null)
					{
						this.SetSpellBar(list[i]);
					}
					else if (beBuff == null)
					{
						base.owner.StopSpellBar(eDungeonCharactorBar.Progress, true);
					}
				}
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017D5D RID: 97629 RVA: 0x0075D7CC File Offset: 0x0075BBCC
	private void OnHurtEntity(int hurtID)
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMonsterByID(list, this.bossID, true);
		if (list.Count > 0)
		{
			VInt3 position = base.owner.GetPosition();
			position.z += VInt.one.i;
			list[0]._onHurtEntity(base.owner, position, hurtID);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017D5E RID: 97630 RVA: 0x0075D848 File Offset: 0x0075BC48
	private void SetSpellBar(BeActor actor)
	{
		int spellBarDuration = base.owner.GetSpellBarDuration(eDungeonCharactorBar.Progress);
		if (spellBarDuration <= 0)
		{
			SpellBar spellBar = base.owner.StartSpellBar(eDungeonCharactorBar.Progress, this.totalTime, true, string.Empty, false);
		}
		if (this.totalTime - 100 <= spellBarDuration)
		{
			base.owner.buffController.RemoveBuff((this.selfFlag != 1) ? this.negativeBuffID : this.positiveBuffID, 0, 0);
			base.owner.buffController.TryAddBuff(this.effectBuffInfoID, null, false, null, 0);
			actor.buffController.RemoveBuff(this.positiveBuffID, 0, 0);
			actor.buffController.RemoveBuff(this.negativeBuffID, 0, 0);
			actor.buffController.TryAddBuff(this.effectBuffInfoID, null, false, null, 0);
		}
	}

	// Token: 0x04011270 RID: 70256
	private int positiveBuffID = 558929;

	// Token: 0x04011271 RID: 70257
	private int negativeBuffID = 558930;

	// Token: 0x04011272 RID: 70258
	private int hurtID = 202022;

	// Token: 0x04011273 RID: 70259
	private int hurtID1 = 202021;

	// Token: 0x04011274 RID: 70260
	private VInt dis = new VInt(2.5f);

	// Token: 0x04011275 RID: 70261
	private int effectBuffInfoID = 568933;

	// Token: 0x04011276 RID: 70262
	private int selfFlag;

	// Token: 0x04011277 RID: 70263
	private int totalTime = 20000;

	// Token: 0x04011278 RID: 70264
	private int bossID = 50800031;

	// Token: 0x04011279 RID: 70265
	private List<BeActor> list = new List<BeActor>();

	// Token: 0x0401127A RID: 70266
	private int damageTimer;
}
