using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x02004301 RID: 17153
public class Mechanism125 : BeMechanism
{
	// Token: 0x06017BB3 RID: 97203 RVA: 0x00751488 File Offset: 0x0074F888
	public Mechanism125(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BB4 RID: 97204 RVA: 0x007514EC File Offset: 0x0074F8EC
	public override void OnInit()
	{
		if (this.data.StringValueA.Count > 0)
		{
			this.effectName = this.data.StringValueA[0];
		}
		if (this.data.ValueA.Count > 0)
		{
			this.radius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		}
		if (this.data.ValueB.Count > 0)
		{
			this.hurtID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		if (this.data.ValueC.Count > 0)
		{
			this.hurtCheckInterval = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.buffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
		if (this.data.ValueE.Count > 0)
		{
			this.magicHurtID = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
		if (this.data.ValueF.Count > 0)
		{
			this.delayTime = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		}
	}

	// Token: 0x06017BB5 RID: 97205 RVA: 0x007516A4 File Offset: 0x0074FAA4
	public override void OnStart()
	{
		this.cnt = 0;
		this.time = 0;
		this.flag = false;
		this.isPVP = BattleMain.IsModePvP(base.owner.battleType);
		if (!string.IsNullOrEmpty(this.effectName) && this.data.ValueA[0].valueType != UnionCellType.union_fix)
		{
			GeEffectEx geEffectEx = base.owner.m_pkGeActor.FindEffect(this.effectName);
			if (geEffectEx != null)
			{
				float num = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], 1, true) / (float)GlobalLogic.VALUE_1000;
				float num2 = (this.radius.scalar - num) / num;
				geEffectEx.SetScale(1f + num2);
			}
		}
		this.CheckRange();
		this.CheckAttack(true);
	}

	// Token: 0x06017BB6 RID: 97206 RVA: 0x00751770 File Offset: 0x0074FB70
	public override void OnUpdate(int deltaTime)
	{
		if (this.hurtCheckInterval > 0)
		{
			this.UpdateCheckHurt(deltaTime);
		}
		if (!this.flag)
		{
			this.time += deltaTime;
			if (this.time >= this.delayTime)
			{
				this.OnHurtEntity();
				this.flag = true;
			}
		}
	}

	// Token: 0x06017BB7 RID: 97207 RVA: 0x007517C8 File Offset: 0x0074FBC8
	private void OnHurtEntity()
	{
		for (int i = 0; i < this.inRangers.Count; i++)
		{
			BeActor beActor = this.inRangers[i];
			VInt3 position = beActor.GetPosition();
			position.z += VInt.one.i;
			if (!beActor.IsDead() && beActor.GetCamp() != base.owner.GetCamp() && beActor.GetLifeState() == 2)
			{
				beActor.buffController.RemoveBuff((!this.isPVP) ? 170421 : 170422, 0, 0);
				BeEntity owner = base.owner.GetOwner();
				if (owner != null)
				{
					owner._onHurtEntity(beActor, position, this.magicHurtID);
				}
			}
		}
	}

	// Token: 0x06017BB8 RID: 97208 RVA: 0x00751897 File Offset: 0x0074FC97
	private void UpdateCheckHurt(int deltaTime)
	{
		this.timeAcc2 += deltaTime;
		if (this.timeAcc2 > this.hurtCheckInterval)
		{
			this.timeAcc2 -= this.hurtCheckInterval;
			this.CheckAttack(false);
		}
	}

	// Token: 0x06017BB9 RID: 97209 RVA: 0x007518D4 File Offset: 0x0074FCD4
	protected void CheckAttack(bool showEffect = false)
	{
		for (int i = 0; i < this.inRangers.Count; i++)
		{
			BeActor actor = this.inRangers[i];
			this.DoAttack(actor, showEffect);
		}
	}

	// Token: 0x06017BBA RID: 97210 RVA: 0x00751914 File Offset: 0x0074FD14
	private void CheckRange()
	{
		VInt3 position = base.owner.GetPosition();
		position.z = 0;
		base.owner.CurrentBeScene.FindActorInRange(this.inRangers, position, this.radius, -1, 0);
		this.inRangers.RemoveAll((BeActor x) => !x.stateController.CanBeHit() || !x.stateController.CanBeTargeted());
	}

	// Token: 0x06017BBB RID: 97211 RVA: 0x00751980 File Offset: 0x0074FD80
	protected void DoAttack(BeActor actor, bool showEffect = false)
	{
		if (!actor.IsDead() && actor.GetCamp() != base.owner.GetCamp() && actor.GetLifeState() == 2)
		{
			if (showEffect)
			{
				if (this.cnt < this.maxEffectNum)
				{
					this.cnt++;
					actor.buffController.TryAddBuff((!this.isPVP) ? this.controlBuffInfoPVE : this.controlBuffInfoPVP, null, false, null, 0);
				}
				actor.buffController.TryAddBuff(this.buffInfoID, base.owner, false, null, 0);
			}
			BeEntity owner = base.owner.GetOwner();
			if (actor.stateController.CanBeHit())
			{
				owner.DoAttackTo(actor, this.hurtID, true, false);
				EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.hurtID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.HitGrab && !actor.IsGrabed())
					{
						return;
					}
					if (actor.OnDamage())
					{
						return;
					}
					if (tableItem.HasDamage == 0)
					{
						return;
					}
					int skillLevel = 1;
					BeEntityData entityData = base.owner.GetEntityData();
					if (entityData != null)
					{
						skillLevel = entityData.GetSkillLevel(tableItem.SkillID);
					}
					VInt3 position = actor.GetPosition();
					position.z += VInt.one.i;
					owner.DealHit(this.hurtID, actor, position, tableItem, skillLevel, false);
				}
			}
		}
	}

	// Token: 0x06017BBC RID: 97212 RVA: 0x00751AF9 File Offset: 0x0074FEF9
	public override void OnFinish()
	{
		this.inRangers.Clear();
	}

	// Token: 0x040110E5 RID: 69861
	protected string effectName = string.Empty;

	// Token: 0x040110E6 RID: 69862
	private VInt radius = VInt.one.i * 2;

	// Token: 0x040110E7 RID: 69863
	protected int hurtID;

	// Token: 0x040110E8 RID: 69864
	protected int hurtCheckInterval;

	// Token: 0x040110E9 RID: 69865
	private int timeAcc2;

	// Token: 0x040110EA RID: 69866
	protected List<BeActor> inRangers = new List<BeActor>();

	// Token: 0x040110EB RID: 69867
	private int buffInfoID;

	// Token: 0x040110EC RID: 69868
	private int magicHurtID;

	// Token: 0x040110ED RID: 69869
	private int delayTime;

	// Token: 0x040110EE RID: 69870
	private int maxEffectNum = 7;

	// Token: 0x040110EF RID: 69871
	private int controlBuffInfoPVE = 1704202;

	// Token: 0x040110F0 RID: 69872
	private int controlBuffInfoPVP = 1704203;

	// Token: 0x040110F1 RID: 69873
	private bool isPVP;

	// Token: 0x040110F2 RID: 69874
	private int time;

	// Token: 0x040110F3 RID: 69875
	private bool flag;

	// Token: 0x040110F4 RID: 69876
	private int cnt;
}
