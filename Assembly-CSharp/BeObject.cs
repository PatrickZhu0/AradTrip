using System;
using ProtoTable;

// Token: 0x0200419C RID: 16796
public class BeObject : BeEntity
{
	// Token: 0x060170B0 RID: 94384 RVA: 0x007114D4 File Offset: 0x0070F8D4
	public BeObject(int resID, int camp, int id) : base(resID, camp, (long)id)
	{
		this.mDamageCount = 0;
		this.mCurrentDamageCount = 0;
		this.mCurrentStage = 0;
	}

	// Token: 0x17001F73 RID: 8051
	// (get) Token: 0x060170B1 RID: 94385 RVA: 0x0071150F File Offset: 0x0070F90F
	// (set) Token: 0x060170B2 RID: 94386 RVA: 0x00711517 File Offset: 0x0070F917
	public int currentStage
	{
		get
		{
			return this.mCurrentStage;
		}
		set
		{
			this.mCurrentStage = value;
		}
	}

	// Token: 0x060170B3 RID: 94387 RVA: 0x00711520 File Offset: 0x0070F920
	public void SetSplitCount(UnionCell split)
	{
		this.mSplit = split;
	}

	// Token: 0x060170B4 RID: 94388 RVA: 0x00711529 File Offset: 0x0070F929
	public void SetMaxStage(int stage)
	{
		this.mMaxStage = stage;
	}

	// Token: 0x060170B5 RID: 94389 RVA: 0x00711532 File Offset: 0x0070F932
	public void SetDeadEffect(string deadEffect)
	{
		if (deadEffect.Length != 0 && deadEffect != "-")
		{
			this.mDeadEffect = deadEffect;
		}
	}

	// Token: 0x060170B6 RID: 94390 RVA: 0x00711558 File Offset: 0x0070F958
	public virtual void Create(int dc = 1)
	{
		BeObjectStateGraph beObjectStateGraph = new BeObjectStateGraph();
		beObjectStateGraph.InitStatesGraph();
		beObjectStateGraph.logicObject = this;
		beObjectStateGraph.m_pkEntity = this;
		this.mDamageCount = dc;
		this.mCurrentStage = 0;
		base.Create(beObjectStateGraph, 0, true, false, false);
		this.DoInit();
	}

	// Token: 0x060170B7 RID: 94391 RVA: 0x0071159E File Offset: 0x0070F99E
	public void DoInit()
	{
		if (this.stateController != null)
		{
			this.stateController.SetAbilityEnable(BeAbilityType.BEGRAB, false);
		}
	}

	// Token: 0x060170B8 RID: 94392 RVA: 0x007115B8 File Offset: 0x0070F9B8
	public void PlayDeadEffect()
	{
		if (this.mDeadEffect.Length > 0)
		{
			this.m_pkGeActor.ChangeSurface(this.mDeadEffect, 0f, true, false);
		}
	}

	// Token: 0x060170B9 RID: 94393 RVA: 0x007115E4 File Offset: 0x0070F9E4
	public override bool OnDamage()
	{
		if (!this.canTakeDamage)
		{
			return true;
		}
		this.mCurrentDamageCount++;
		if (this.mCurrentDamageCount >= this.mDamageCount)
		{
			if (this.delayDead > 0 && !this.markDead)
			{
				this.markDead = true;
				this.delayCaller.DelayCall(this.delayDead, delegate
				{
					this.DoDead(false);
				}, 0, 0, false);
			}
		}
		else
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.mSplit, this.mCurrentStage + 1, true);
			if (this.mCurrentDamageCount >= valueFromUnionCell)
			{
				this.mCurrentStage++;
				if (this.mCurrentStage < this.mMaxStage)
				{
					base.sgSwitchStates(new BeStateData
					{
						_State = 0
					});
				}
			}
			base.TriggerEvent(BeEventType.onHit, null);
		}
		return true;
	}

	// Token: 0x060170BA RID: 94394 RVA: 0x007116C2 File Offset: 0x0070FAC2
	public void SetDamageCount(int count)
	{
		this.mDamageCount = count;
	}

	// Token: 0x060170BB RID: 94395 RVA: 0x007116CB File Offset: 0x0070FACB
	public override bool Update(int iDeltaTime)
	{
		base.Update(iDeltaTime);
		return true;
	}

	// Token: 0x060170BC RID: 94396 RVA: 0x007116D6 File Offset: 0x0070FAD6
	public void ForceDoDead()
	{
		base.TriggerEvent(BeEventType.onDead, null);
		base.sgSwitchStates(new BeStateData(16, 0));
	}

	// Token: 0x060170BD RID: 94397 RVA: 0x007116EF File Offset: 0x0070FAEF
	public override void DoDead(bool isForce = false)
	{
		if (base.HasAction(ActionType.ActionType_DEAD))
		{
			base.TriggerEvent(BeEventType.onDead, null);
			base.sgSwitchStates(new BeStateData(16, 0));
		}
	}

	// Token: 0x060170BE RID: 94398 RVA: 0x00711715 File Offset: 0x0070FB15
	public void SetCanBeBreak(bool flag)
	{
		this.canTakeDamage = flag;
	}

	// Token: 0x060170BF RID: 94399 RVA: 0x00711720 File Offset: 0x0070FB20
	public override void onHitEntity(BeEntity pkEntity, VInt3 pos, int hurtID = 0, AttackResult result = AttackResult.MISS, int finalDamage = 0)
	{
		if (this.hurtOtherCount >= 1)
		{
			return;
		}
		int num = 0;
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			num = tableItem.SkillID;
		}
		base.TriggerEvent(BeEventType.onHitOther, new object[]
		{
			pkEntity,
			hurtID,
			num,
			pos,
			0,
			0
		});
		this.hurtOtherCount++;
	}

	// Token: 0x04010981 RID: 67969
	protected int mCurrentStage;

	// Token: 0x04010982 RID: 67970
	protected int mMaxStage;

	// Token: 0x04010983 RID: 67971
	protected int mCurrentDamageCount;

	// Token: 0x04010984 RID: 67972
	protected int mDamageCount;

	// Token: 0x04010985 RID: 67973
	protected bool markDead;

	// Token: 0x04010986 RID: 67974
	protected int delayDead = 10;

	// Token: 0x04010987 RID: 67975
	protected bool canTakeDamage = true;

	// Token: 0x04010988 RID: 67976
	protected int hurtOtherCount;

	// Token: 0x04010989 RID: 67977
	protected UnionCell mSplit;

	// Token: 0x0401098A RID: 67978
	protected string mDeadEffect = string.Empty;
}
