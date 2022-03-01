using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;

// Token: 0x0200445C RID: 17500
public class Skill1609 : BeSkill
{
	// Token: 0x06018506 RID: 99590 RVA: 0x0079248D File Offset: 0x0079088D
	public Skill1609(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018507 RID: 99591 RVA: 0x007924C4 File Offset: 0x007908C4
	public override void OnInit()
	{
		this.replaceNormalAttackID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.healBuffID = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.buffID = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
		this.hpReduce = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true) / 10;
	}

	// Token: 0x06018508 RID: 99592 RVA: 0x00792560 File Offset: 0x00790960
	public override void OnPostInit()
	{
		base.OnPostInit();
		this.hpReduce = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true) / 10;
		if (!BattleMain.IsModePvP(base.battleType))
		{
			this.RemoveHandle();
			this.RegisterHandle();
		}
	}

	// Token: 0x06018509 RID: 99593 RVA: 0x007925B5 File Offset: 0x007909B5
	public override void OnStart()
	{
		if (!this.started)
		{
			this.started = true;
			this.DoEffect();
		}
		else
		{
			this.started = false;
			this.Restore();
		}
	}

	// Token: 0x0601850A RID: 99594 RVA: 0x007925E1 File Offset: 0x007909E1
	protected void RegisterHandle()
	{
		this.m_HandleComboHandle = base.owner.RegisterEvent(BeEventType.onReplaceComboSkill, new BeEventHandle.Del(this.OnReplaceComboSkill));
	}

	// Token: 0x0601850B RID: 99595 RVA: 0x00792602 File Offset: 0x00790A02
	protected void RemoveHandle()
	{
		if (this.m_HandleComboHandle != null)
		{
			this.m_HandleComboHandle.Remove();
			this.m_HandleComboHandle = null;
		}
	}

	// Token: 0x0601850C RID: 99596 RVA: 0x00792624 File Offset: 0x00790A24
	protected void OnReplaceComboSkill(object[] args)
	{
		if (base.owner.buffController.HasBuffByID(this.m_ShixueBuffIdPve) == null)
		{
			return;
		}
		int[] array = (int[])args[0];
		if (array[0] != this.m_RegisterComboSkillId)
		{
			return;
		}
		array[0] = this.m_ReplaceComboSkillId;
	}

	// Token: 0x0601850D RID: 99597 RVA: 0x00792670 File Offset: 0x00790A70
	private void DoEffect()
	{
		if (base.owner != null)
		{
			int num = GlobalLogic.VALUE_1000;
			for (int i = 0; i < base.owner.MechanismList.Count; i++)
			{
				Mechanism123 mechanism = base.owner.MechanismList[i] as Mechanism123;
				if (mechanism != null)
				{
					num += mechanism.hpRate;
				}
			}
			this.hpReduce = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true) * VFactor.NewVFactor(num, GlobalLogic.VALUE_10000);
			this.backupAttackID = base.owner.GetEntityData().normalAttackID;
			base.owner.GetEntityData().normalAttackID = this.replaceNormalAttackID;
			base.owner.GetEntityData().ChangeHPReduce(this.hpReduce);
			this.AddBuff(false);
			this.AddSkillBuff(false);
			this.handler = base.owner.RegisterEvent(BeEventType.onKill, delegate(object[] args)
			{
				BeActor target = args[0] as BeActor;
				if (target != null && target.buffController.HasBuffByType(BuffType.BLEEDING) != null)
				{
					target.RegisterEvent(BeEventType.onRemove, delegate(object[] args2)
					{
						VInt3 position = target.GetPosition();
						VInt3 position2 = this.owner.GetPosition();
						Vector3 startVel;
						startVel..ctor(0f, 0f, 0f);
						ParabolaBehaviour parabolaBehaviour = this.TrailManager.AddParabolaTrail(target.GetGePosition() + Global.Settings.offset, this.owner, startVel, Vector3.zero, this.effect);
						this.AddHealBuff();
					});
				}
			});
			this.handler2 = base.owner.RegisterEvent(BeEventType.onHPChange, delegate(object[] args3)
			{
				if (base.owner.GetEntityData().GetHP() <= this.hpReduce)
				{
					base.PressAgainCancel();
				}
			});
		}
	}

	// Token: 0x0601850E RID: 99598 RVA: 0x00792798 File Offset: 0x00790B98
	private void AddSkillBuff(bool remove = false)
	{
		for (int i = 0; i < this.skillData.ValueC.Count; i++)
		{
			int fixInitValue = this.skillData.ValueC[i].fixInitValue;
			int fixLevelGrow = this.skillData.ValueC[i].fixLevelGrow;
			if (!remove)
			{
				int level = base.level;
				base.owner.buffController.AddBuffForSkill(fixLevelGrow, level, -1, new List<int>
				{
					fixInitValue
				});
			}
			else
			{
				int level2 = base.level;
				base.owner.buffController.RemoveBuff(fixLevelGrow, 0, 0);
			}
		}
	}

	// Token: 0x0601850F RID: 99599 RVA: 0x00792848 File Offset: 0x00790C48
	private void AddBuff(bool remove = false)
	{
		if (remove)
		{
			base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
		}
		else
		{
			int level = base.level;
			base.owner.buffController.TryAddBuff(this.buffID, -1, level);
		}
	}

	// Token: 0x06018510 RID: 99600 RVA: 0x00792898 File Offset: 0x00790C98
	private void AddHealBuff()
	{
		int bid = (!BattleMain.IsModePvP(base.owner.battleType)) ? 162209 : 162210;
		if (base.owner.buffController.HasBuffByID(bid) != null)
		{
			BeSkill skill = base.owner.GetSkill(1622);
			if (skill != null)
			{
				int num = (!BattleMain.IsModePvP(base.owner.battleType)) ? 162203 : 162204;
				base.owner.buffController.TryAddBuff(num, GlobalLogic.VALUE_1000, skill.level);
			}
		}
		base.owner.buffController.TryAddBuff(this.healBuffID, GlobalLogic.VALUE_1000, base.level);
	}

	// Token: 0x06018511 RID: 99601 RVA: 0x0079295C File Offset: 0x00790D5C
	private void Restore()
	{
		if (base.owner != null)
		{
			if (base.owner.CurrentBeBattle != null && !base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.ShiXueShuangDaoBug))
			{
				base.owner.SetAttackButtonState(ButtonState.RELEASE, true);
			}
			base.owner.GetEntityData().normalAttackID = this.backupAttackID;
			base.owner.GetEntityData().ChangeHPReduce(-this.hpReduce);
			if (this.handler != null)
			{
				this.handler.Remove();
				this.handler = null;
			}
			if (this.handler2 != null)
			{
				this.handler2.Remove();
				this.handler2 = null;
			}
			this.AddBuff(true);
			this.AddSkillBuff(true);
		}
	}

	// Token: 0x06018512 RID: 99602 RVA: 0x00792A1E File Offset: 0x00790E1E
	public override void OnCancel()
	{
		if (this.started)
		{
			this.started = false;
			this.Restore();
		}
	}

	// Token: 0x040118B5 RID: 71861
	private BeEventHandle handler;

	// Token: 0x040118B6 RID: 71862
	private BeEventHandle handler2;

	// Token: 0x040118B7 RID: 71863
	private int replaceNormalAttackID;

	// Token: 0x040118B8 RID: 71864
	private int backupAttackID;

	// Token: 0x040118B9 RID: 71865
	private int healBuffID;

	// Token: 0x040118BA RID: 71866
	private int buffID;

	// Token: 0x040118BB RID: 71867
	private int hpReduce;

	// Token: 0x040118BC RID: 71868
	private bool started;

	// Token: 0x040118BD RID: 71869
	private string effect = "Effects/Hero_Kuangzhan/Xuezhikuangbaoerdao/Prefab/Eff_xuezhikuangbao_xueqiu";

	// Token: 0x040118BE RID: 71870
	protected BeEventHandle m_HandleComboHandle;

	// Token: 0x040118BF RID: 71871
	protected int m_RegisterComboSkillId = 1601;

	// Token: 0x040118C0 RID: 71872
	protected int m_ReplaceComboSkillId = 1623;

	// Token: 0x040118C1 RID: 71873
	protected int m_ShixueBuffIdPve = 162209;
}
