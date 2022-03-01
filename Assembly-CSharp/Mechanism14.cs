using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x02004312 RID: 17170
public class Mechanism14 : BeMechanism
{
	// Token: 0x06017C14 RID: 97300 RVA: 0x00754641 File Offset: 0x00752A41
	public Mechanism14(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C15 RID: 97301 RVA: 0x00754674 File Offset: 0x00752A74
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			if (valueFromUnionCell > 0 && !this.abnormalTypes.Contains(valueFromUnionCell))
			{
				this.abnormalTypes.Add(valueFromUnionCell);
			}
		}
		for (int j = 0; j < this.data.ValueB.Count; j++)
		{
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true);
			if (valueFromUnionCell2 > 0 && !this.buffInfos.Contains(valueFromUnionCell2))
			{
				this.buffInfos.Add(valueFromUnionCell2);
			}
		}
		if (this.data.ValueC.Count > 0)
		{
			this.buffTargetIsSelf = false;
		}
		for (int k = 0; k < this.data.ValueD.Count; k++)
		{
			Mechanism14.StateEnum valueFromUnionCell3 = (Mechanism14.StateEnum)TableManager.GetValueFromUnionCell(this.data.ValueD[k], this.level, true);
			if (!this.stateTypes.Contains(valueFromUnionCell3))
			{
				this.stateTypes.Add(valueFromUnionCell3);
			}
		}
		this.mUseNewEventType = (TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true) != 0);
	}

	// Token: 0x06017C16 RID: 97302 RVA: 0x0075480C File Offset: 0x00752C0C
	public override void OnStart()
	{
		if (base.owner != null)
		{
			if (!this.mUseNewEventType)
			{
				this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeHit, delegate(object[] args)
				{
					BeActor target = (BeActor)args[0];
					this.FilterTarget(target);
				});
			}
			else if (base.owner.CurrentBeScene != null)
			{
				this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onHurtEntity, new BeEvent.BeEventHandleNew.Function(this.OnHurtEntity));
			}
		}
	}

	// Token: 0x06017C17 RID: 97303 RVA: 0x00754888 File Offset: 0x00752C88
	protected void OnHurtEntity(BeEvent.BeEventParam param)
	{
		BeEntity beEntity = param.m_Obj as BeEntity;
		if (beEntity == null)
		{
			return;
		}
		if (!base.owner.IsSameTopOwner(beEntity))
		{
			return;
		}
		BeActor beActor = param.m_Obj2 as BeActor;
		if (beActor == null)
		{
			return;
		}
		VInt3 vint = param.m_Vint3;
		EffectTable hurtData = param.m_Obj3 as EffectTable;
		this.FilterTarget(beActor, vint, hurtData);
	}

	// Token: 0x06017C18 RID: 97304 RVA: 0x007548EC File Offset: 0x00752CEC
	protected void FilterTarget(BeActor target)
	{
		if (target != null && this.HasAbnormalType(target, this.abnormalTypes))
		{
			if (this.buffTargetIsSelf)
			{
				this.AddBuff(base.owner, this.buffInfos);
			}
			else
			{
				this.AddBuff(target, this.buffInfos);
			}
		}
	}

	// Token: 0x06017C19 RID: 97305 RVA: 0x00754940 File Offset: 0x00752D40
	protected void FilterTarget(BeActor target, VInt3 hitPos, EffectTable hurtData = null)
	{
		if (target != null && (this.HasAbnormalType(target, this.abnormalTypes) || this.InRightState(target, this.stateTypes, hitPos, hurtData)))
		{
			if (this.buffTargetIsSelf)
			{
				this.AddBuff(base.owner, this.buffInfos);
			}
			else
			{
				this.AddBuff(target, this.buffInfos);
			}
		}
	}

	// Token: 0x06017C1A RID: 97306 RVA: 0x007549A8 File Offset: 0x00752DA8
	private bool HasAbnormalType(BeActor actor, List<int> abnormalTypes)
	{
		for (int i = 0; i < abnormalTypes.Count; i++)
		{
			BeBuffStateType target = (BeBuffStateType)(1 << abnormalTypes[i]);
			if (actor.stateController.HasBuffState(target))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06017C1B RID: 97307 RVA: 0x007549F0 File Offset: 0x00752DF0
	private void AddBuff(BeActor actor, List<int> buffInfos)
	{
		for (int i = 0; i < buffInfos.Count; i++)
		{
			BuffInfoData info = new BuffInfoData(buffInfos[i], this.level, 0);
			actor.buffController.TryAddBuff(info, base.owner, false, default(VRate), null);
		}
	}

	// Token: 0x06017C1C RID: 97308 RVA: 0x00754A4C File Offset: 0x00752E4C
	private bool InRightState(BeActor actor, List<Mechanism14.StateEnum> stateTypes, VInt3 hitPos, EffectTable hurtData = null)
	{
		for (int i = 0; i < stateTypes.Count; i++)
		{
			switch (stateTypes[i])
			{
			case Mechanism14.StateEnum.FALL_NO_FALLCLICK:
				return actor.HasTag(1) && !actor.HasTag(4);
			case Mechanism14.StateEnum.BACK_HIT:
				return actor.stateController.HasAbility(BeAbilityType.CAN_HIT_BACK) && hurtData != null && hurtData.IsFriendDamage == 0 && base.owner.IsFacingAway(actor);
			}
		}
		return false;
	}

	// Token: 0x04011145 RID: 69957
	private List<int> abnormalTypes = new List<int>();

	// Token: 0x04011146 RID: 69958
	private List<int> buffInfos = new List<int>();

	// Token: 0x04011147 RID: 69959
	protected bool buffTargetIsSelf = true;

	// Token: 0x04011148 RID: 69960
	private List<Mechanism14.StateEnum> stateTypes = new List<Mechanism14.StateEnum>();

	// Token: 0x04011149 RID: 69961
	protected bool mUseNewEventType;

	// Token: 0x02004313 RID: 17171
	private enum StateEnum
	{
		// Token: 0x0401114B RID: 69963
		NONE,
		// Token: 0x0401114C RID: 69964
		FALL_NO_FALLCLICK,
		// Token: 0x0401114D RID: 69965
		BACK_HIT
	}
}
