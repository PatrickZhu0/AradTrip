using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;

// Token: 0x020043D0 RID: 17360
public class Mechanism23 : BeMechanism
{
	// Token: 0x06018160 RID: 98656 RVA: 0x0077B244 File Offset: 0x00779644
	public Mechanism23(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018161 RID: 98657 RVA: 0x0077B2B8 File Offset: 0x007796B8
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
			this.friendBuffID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.enemyBuffID = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
		if (this.data.ValueE.Count > 0)
		{
			this.hurtCheckInterval = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
		if (this.data.ValueF.Count > 0)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
			if (valueFromUnionCell > 0)
			{
				this.normalHit = true;
			}
		}
		if (this.data.ValueG.Count > 1)
		{
			this.minPos = VInt.Float2VIntValue((float)TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true) / 1000f);
			this.maxPos = VInt.Float2VIntValue((float)TableManager.GetValueFromUnionCell(this.data.ValueG[1], this.level, true) / 1000f);
		}
		if (this.data.ValueH.Count > 0)
		{
			this.onlyHurtOnce = (TableManager.GetValueFromUnionCell(this.data.ValueH[0], this.level, true) == 1);
		}
	}

	// Token: 0x06018162 RID: 98658 RVA: 0x0077B54C File Offset: 0x0077994C
	public override void OnStart()
	{
		this.attackActorList.Clear();
		int num = GlobalLogic.VALUE_1000;
		int num2 = GlobalLogic.VALUE_1000;
		int num3 = GlobalLogic.VALUE_1000;
		for (int i = 0; i < base.owner.MechanismList.Count; i++)
		{
			Mechanism116 mechanism = base.owner.MechanismList[i] as Mechanism116;
			if (mechanism != null)
			{
				if (!mechanism.impactMechanismIdList.Contains(this.mechianismID))
				{
					num += mechanism.radiusRate;
					if (mechanism.isChangeEffectSize)
					{
						num2 += mechanism.radiusRate;
					}
					num3 += mechanism.intervalRate;
				}
			}
		}
		if (num == GlobalLogic.VALUE_1000 && num2 == GlobalLogic.VALUE_1000 && num3 == GlobalLogic.VALUE_1000)
		{
			BeActor beActor = base.owner.GetOwner() as BeActor;
			if (beActor != null)
			{
				for (int j = 0; j < beActor.MechanismList.Count; j++)
				{
					Mechanism116 mechanism2 = beActor.MechanismList[j] as Mechanism116;
					if (mechanism2 != null)
					{
						if (mechanism2.impactMechanismIdList.Contains(this.mechianismID))
						{
							num += mechanism2.radiusRate;
							if (mechanism2.isChangeEffectSize)
							{
								num2 += mechanism2.radiusRate;
							}
							num3 += mechanism2.intervalRate;
						}
					}
				}
			}
		}
		this.radius = this.radius.i * VFactor.NewVFactor(num, GlobalLogic.VALUE_1000);
		VInt vint = this.radius.i * VFactor.NewVFactor(num2, GlobalLogic.VALUE_1000);
		this.hurtCheckInterval *= VFactor.NewVFactor(num3, GlobalLogic.VALUE_1000);
		if (!string.IsNullOrEmpty(this.effectName) && this.data.ValueA[0].valueType != UnionCellType.union_fix)
		{
			GeEffectEx geEffectEx = base.owner.m_pkGeActor.FindEffect(this.effectName);
			if (geEffectEx != null)
			{
				float num4 = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], 1, true) / (float)GlobalLogic.VALUE_1000;
				float num5 = (vint.scalar - num4) / num4;
				geEffectEx.SetScale(1f + num5);
			}
		}
		this.CheckRange();
		this.CheckAttack();
	}

	// Token: 0x06018163 RID: 98659 RVA: 0x0077B7BE File Offset: 0x00779BBE
	public override void OnUpdate(int deltaTime)
	{
		if (this.hurtCheckInterval > 0)
		{
			this.UpdateCheckRange(deltaTime);
			this.UpdateCheckHurt(deltaTime);
		}
	}

	// Token: 0x06018164 RID: 98660 RVA: 0x0077B7DA File Offset: 0x00779BDA
	private void UpdateCheckHurt(int deltaTime)
	{
		this.timeAcc2 += deltaTime;
		if (this.timeAcc2 > this.hurtCheckInterval)
		{
			this.timeAcc2 -= this.hurtCheckInterval;
			this.CheckAttack();
		}
	}

	// Token: 0x06018165 RID: 98661 RVA: 0x0077B814 File Offset: 0x00779C14
	private void UpdateCheckRange(int deltaTime)
	{
		this.timeAcc += deltaTime;
		if (this.timeAcc > this.checkInterval)
		{
			this.timeAcc -= this.checkInterval;
			this.CheckRange();
		}
	}

	// Token: 0x06018166 RID: 98662 RVA: 0x0077B850 File Offset: 0x00779C50
	protected void CheckAttack()
	{
		for (int i = 0; i < this.inRangers.Count; i++)
		{
			BeActor actor = this.inRangers[i];
			this.DoAttack(actor);
		}
	}

	// Token: 0x06018167 RID: 98663 RVA: 0x0077B890 File Offset: 0x00779C90
	private void CheckRange()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		VInt3 position = base.owner.GetPosition();
		position.z = 0;
		base.owner.CurrentBeScene.FindActorInRange(list, position, this.radius, -1, 0);
		this.FilterHeight(list);
		for (int i = 0; i < this.inRangers.Count; i++)
		{
			if (!list.Contains(this.inRangers[i]))
			{
				this.OutRange(this.inRangers[i]);
				this.inRangers.RemoveAt(i);
				i--;
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (!this.inRangers.Contains(list[j]))
			{
				this.inRangers.Add(list[j]);
				this.InRange(list[j]);
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06018168 RID: 98664 RVA: 0x0077B992 File Offset: 0x00779D92
	private void FilterHeight(List<BeActor> list)
	{
		if (this.minPos == 0 || this.maxPos == 0)
		{
			return;
		}
		list.RemoveAll(delegate(BeActor x)
		{
			if (x.m_cpkCurEntityActionFrameData == null || x.m_cpkCurEntityActionFrameData.pDefenseData == null || x.m_cpkCurEntityActionFrameData.pDefenseData.vBox.Count <= 0)
			{
				return true;
			}
			VInt a = x.m_cpkCurEntityActionFrameData.pDefenseData.vBox[0].vBox._max.y + x.GetPosition().z;
			VInt a2 = x.m_cpkCurEntityActionFrameData.pDefenseData.vBox[0].vBox._min.y + x.GetPosition().z;
			return !(a2 <= this.maxPos) || !(a >= this.minPos);
		});
	}

	// Token: 0x06018169 RID: 98665 RVA: 0x0077B9CC File Offset: 0x00779DCC
	public void SetAttackTimeAcc(VFactor rate)
	{
		VFactor a = new VFactor(rate.den, rate.nom);
		this.hurtCheckInterval = (a * (long)this.hurtCheckInterval).integer;
	}

	// Token: 0x0601816A RID: 98666 RVA: 0x0077BA0C File Offset: 0x00779E0C
	protected void DoAttack(BeActor actor)
	{
		if (this.onlyHurtOnce)
		{
			if (this.attackActorList.Contains(actor))
			{
				return;
			}
			this.attackActorList.Add(actor);
		}
		if (!actor.IsDead() && actor.GetCamp() != base.owner.GetCamp() && actor.GetLifeState() == 2)
		{
			BeEntity owner = base.owner.GetOwner();
			if (actor.stateController.CanBeHit())
			{
				bool triggerFlashHurt = this.normalHit;
				AttackResult attackResult = owner.DoAttackTo(actor, this.hurtID, triggerFlashHurt, false);
				if (this.normalHit && attackResult != AttackResult.MISS && attackResult != AttackResult.IGNORE)
				{
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
						BeEntityData entityData = owner.GetEntityData();
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
	}

	// Token: 0x0601816B RID: 98667 RVA: 0x0077BB70 File Offset: 0x00779F70
	public override void OnFinish()
	{
		for (int i = 0; i < this.inRangers.Count; i++)
		{
			this.OutRange(this.inRangers[i]);
		}
		this.inRangers.Clear();
	}

	// Token: 0x0601816C RID: 98668 RVA: 0x0077BBB8 File Offset: 0x00779FB8
	private void InRange(BeActor actor)
	{
		if (actor.GetCamp() == base.owner.GetCamp())
		{
			if (this.friendBuffID != 0)
			{
				actor.buffController.TryAddBuff(this.friendBuffID, int.MaxValue, this.level);
			}
		}
		else if (this.enemyBuffID != 0)
		{
			actor.buffController.TryAddBuff(this.enemyBuffID, int.MaxValue, this.level);
		}
	}

	// Token: 0x0601816D RID: 98669 RVA: 0x0077BC3C File Offset: 0x0077A03C
	private void OutRange(BeActor actor)
	{
		if (actor.GetCamp() == base.owner.GetCamp())
		{
			actor.buffController.RemoveBuff(this.friendBuffID, 0, 0);
		}
		else
		{
			actor.buffController.RemoveBuff(this.enemyBuffID, 0, 0);
		}
	}

	// Token: 0x040115B7 RID: 71095
	protected string effectName = string.Empty;

	// Token: 0x040115B8 RID: 71096
	private VInt radius = VInt.one.i * 2;

	// Token: 0x040115B9 RID: 71097
	protected int hurtID;

	// Token: 0x040115BA RID: 71098
	protected int friendBuffID;

	// Token: 0x040115BB RID: 71099
	protected int enemyBuffID;

	// Token: 0x040115BC RID: 71100
	protected int hurtCheckInterval;

	// Token: 0x040115BD RID: 71101
	protected bool normalHit;

	// Token: 0x040115BE RID: 71102
	protected VInt minPos = 0;

	// Token: 0x040115BF RID: 71103
	protected VInt maxPos = 0;

	// Token: 0x040115C0 RID: 71104
	private int timeAcc;

	// Token: 0x040115C1 RID: 71105
	private int checkInterval = 200;

	// Token: 0x040115C2 RID: 71106
	private int timeAcc2;

	// Token: 0x040115C3 RID: 71107
	private bool onlyHurtOnce;

	// Token: 0x040115C4 RID: 71108
	private List<BeActor> attackActorList = new List<BeActor>();

	// Token: 0x040115C5 RID: 71109
	protected List<BeActor> inRangers = new List<BeActor>();
}
