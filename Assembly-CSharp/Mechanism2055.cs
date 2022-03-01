using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x0200436F RID: 17263
public class Mechanism2055 : BeMechanism
{
	// Token: 0x06017E91 RID: 97937 RVA: 0x00766906 File Offset: 0x00764D06
	public Mechanism2055(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017E92 RID: 97938 RVA: 0x0076692C File Offset: 0x00764D2C
	public override void OnInit()
	{
		base.OnInit();
		if (this.data.ValueA.Count == 2)
		{
			this.monsterIDs[0] = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
			this.monsterIDs[1] = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		}
	}

	// Token: 0x06017E93 RID: 97939 RVA: 0x007669AC File Offset: 0x00764DAC
	public override void OnStart()
	{
		base.OnStart();
		this.SetActorVisible(false);
		this.SetSkillBtn(false);
		this.RegistSummon();
		this.ClearDelayHandle();
		this.mSummonDelayCallHandle = base.owner.delayCaller.DelayCall(100, delegate
		{
			this.SummonMonster();
		}, 0, 0, false);
	}

	// Token: 0x06017E94 RID: 97940 RVA: 0x00766A00 File Offset: 0x00764E00
	private void RegistSummon()
	{
		this.handleB = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onSummon, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			BeActor beActor2 = args[1] as BeActor;
			if (Array.IndexOf<int>(this.monsterIDs, beActor.GetEntityData().monsterID) != -1)
			{
				if (beActor2 != null && beActor2.GetPID() != base.owner.GetPID() && base.owner.isLocalActor)
				{
					beActor.m_pkGeActor.HideActor(true);
				}
				if (beActor != null && beActor.GetEntityData().MonsterIDEqual(this.monsterIDs[1]) && beActor.aiManager != null && beActor2 != null)
				{
					beActor.aiManager.ForceAssignAiTarget(beActor2);
				}
			}
		});
	}

	// Token: 0x06017E95 RID: 97941 RVA: 0x00766A28 File Offset: 0x00764E28
	private void SummonMonster()
	{
		for (int i = 0; i < this.monsterIDs.Length; i++)
		{
			VInt3 vint = base.owner.CurrentBeScene.GetRandomPos(10);
			if (base.owner.CurrentBeScene.IsInBlockPlayer(vint))
			{
				vint = base.owner.GetPosition();
			}
			base.owner.CurrentBeScene.SummonMonster(this.monsterIDs[i], vint, 1, base.owner, false, 0, true, 0, false, false);
		}
	}

	// Token: 0x06017E96 RID: 97942 RVA: 0x00766AAA File Offset: 0x00764EAA
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (base.owner.GetCurrentBtnState() == ButtonState.PRESS)
		{
			base.owner.SetAttackButtonState(ButtonState.RELEASE, true);
		}
	}

	// Token: 0x06017E97 RID: 97943 RVA: 0x00766AD4 File Offset: 0x00764ED4
	private void SetSkillBtn(bool flag)
	{
		base.owner.SetAttackButtonState(ButtonState.RELEASE, true);
		if (flag)
		{
			base.owner.stateController.SetAbilityEnable(BeAbilityType.CAN_DO_SKILL_CMD, true);
		}
		else
		{
			base.owner.stateController.SetAbilityEnable(BeAbilityType.CAN_DO_SKILL_CMD, false);
			if (base.owner.IsCastingSkill())
			{
				BeSkill currentSkill = base.owner.GetCurrentSkill();
				if (currentSkill != null && BeUtility.IsActorUseCanChargeSkill(base.owner))
				{
					base.owner.CancelSkill(currentSkill.skillID, true);
					base.owner.Locomote(new BeStateData(0, 0), true);
				}
			}
		}
		if (base.owner.isLocalActor)
		{
			InputManager.instance.SetVisible(true, flag);
		}
	}

	// Token: 0x06017E98 RID: 97944 RVA: 0x00766B94 File Offset: 0x00764F94
	private void SetActorVisible(bool flag)
	{
		if (base.owner.isLocalActor)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.GetFilterTarget(list, new BeCampFilter(base.owner.GetCamp()), false);
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] != null && list[i].m_pkGeActor != null)
				{
					if (list[i].GetPID() != base.owner.GetPID())
					{
						list[i].m_pkGeActor.HideActor(!flag);
					}
				}
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x06017E99 RID: 97945 RVA: 0x00766C4A File Offset: 0x0076504A
	private void ClearDelayHandle()
	{
		this.mSummonDelayCallHandle.SetRemove(true);
	}

	// Token: 0x06017E9A RID: 97946 RVA: 0x00766C58 File Offset: 0x00765058
	public override void OnFinish()
	{
		base.OnFinish();
		this.SetActorVisible(true);
		this.SetSkillBtn(true);
		this.ClearDelayHandle();
	}

	// Token: 0x04011366 RID: 70502
	private int[] monsterIDs = new int[]
	{
		81120011,
		81110011
	};

	// Token: 0x04011367 RID: 70503
	private DelayCallUnitHandle mSummonDelayCallHandle;
}
