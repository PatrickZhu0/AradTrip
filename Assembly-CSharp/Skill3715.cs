using System;
using GameClient;

// Token: 0x020044D4 RID: 17620
public class Skill3715 : BeSkill
{
	// Token: 0x0601885B RID: 100443 RVA: 0x007A7983 File Offset: 0x007A5D83
	public Skill3715(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601885C RID: 100444 RVA: 0x007A79B3 File Offset: 0x007A5DB3
	public override void OnInit()
	{
		base.OnInit();
		this.OnPostInit();
	}

	// Token: 0x0601885D RID: 100445 RVA: 0x007A79C4 File Offset: 0x007A5DC4
	public override void OnPostInit()
	{
		base.OnPostInit();
		this.useCountMax[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.useCountMax[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true);
		this.maxCount = ((!BattleMain.IsModePvP(base.battleType)) ? this.useCountMax[0] : this.useCountMax[1]);
		if (this.skillData.ValueB.Count > 0)
		{
			this.monsterIdArr[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
			this.monsterIdArr[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[1], base.level, true);
		}
		if (base.owner != null && base.owner.CurrentBeBattle != null && !base.owner.CurrentBeBattle.HasFlag(BattleFlagType.SkillSpecialBug))
		{
			this.canPressJumpBackCancel = false;
		}
		this.startJumpBackCnacelFlag = "371501";
		this.endJumpBackCnacelFlag = "371502";
		if (!BattleMain.IsModePvP(base.battleType))
		{
			this.pveNeedCheckFlag = false;
		}
		base.owner.delayCaller.DelayCall(100, delegate
		{
			this.ResetUseCount(false);
		}, 0, 0, false);
	}

	// Token: 0x0601885E RID: 100446 RVA: 0x007A7B38 File Offset: 0x007A5F38
	public override void OnStart()
	{
		base.OnStart();
		this.curUseCount++;
		this.SetUseCount();
		this.monster = null;
		this.RemoveHandles();
		this.rebornHandle = base.owner.RegisterEvent(BeEventType.onReborn, delegate(object[] args)
		{
			this.ResetUseCount(true);
		});
		if (base.owner.CurrentBeScene != null)
		{
			this.deadTowerHandle = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onDeadTowerPassFiveLayer, delegate(object[] args)
			{
				this.ResetUseCount(true);
			});
			this.switch3v3NextHandle = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.on3v3SwitchNext, delegate(object[] args)
			{
				this.ResetUseCount(true);
			});
		}
		this.trainingPveResetSkillCDHandle = base.owner.RegisterEvent(BeEventType.onTrainingPveResetSkillCD, delegate(object[] args)
		{
			this.ResetUseCount(true);
		});
		if (this.cancelSetMonsterDead)
		{
			this.RegisterSummon();
		}
	}

	// Token: 0x0601885F RID: 100447 RVA: 0x007A7C16 File Offset: 0x007A6016
	private void ResetUseCount(bool resetCurCount = true)
	{
		if (resetCurCount)
		{
			this.curUseCount = 0;
		}
		this.SetUseCount();
	}

	// Token: 0x06018860 RID: 100448 RVA: 0x007A7C2B File Offset: 0x007A602B
	public override bool CanUseSkill()
	{
		return (!this.pveNeedCheckFlag || this.curUseCount < this.maxCount) && base.CanUseSkill();
	}

	// Token: 0x06018861 RID: 100449 RVA: 0x007A7C51 File Offset: 0x007A6051
	public override BeActor.SkillCannotUseType GetCannotUseType()
	{
		if (this.pveNeedCheckFlag && this.curUseCount >= this.maxCount)
		{
			return BeActor.SkillCannotUseType.CAN_NOT_USE;
		}
		return base.GetCannotUseType();
	}

	// Token: 0x06018862 RID: 100450 RVA: 0x007A7C78 File Offset: 0x007A6078
	public override void OnCancel()
	{
		base.OnCancel();
		if (this.cancelSetMonsterDead)
		{
			this.SetMonsterDead();
		}
	}

	// Token: 0x06018863 RID: 100451 RVA: 0x007A7C94 File Offset: 0x007A6094
	private void RegisterSummon()
	{
		int monsterId = (!BattleMain.IsModePvP(base.battleType)) ? this.monsterIdArr[0] : this.monsterIdArr[1];
		this.handleB = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor != null && beActor.GetEntityData().MonsterIDEqual(monsterId))
			{
				this.monster = beActor;
				this.handleC = beActor.RegisterEvent(BeEventType.onDead, delegate(object[] args1)
				{
					this.owner.Locomote(new BeStateData(0, 0), true);
				});
			}
		});
	}

	// Token: 0x06018864 RID: 100452 RVA: 0x007A7CF8 File Offset: 0x007A60F8
	private void RemoveHandles()
	{
		if (this.rebornHandle != null)
		{
			this.rebornHandle.Remove();
			this.rebornHandle = null;
		}
		if (this.deadTowerHandle != null)
		{
			this.deadTowerHandle.Remove();
			this.deadTowerHandle = null;
		}
		if (this.switch3v3NextHandle != null)
		{
			this.switch3v3NextHandle.Remove();
			this.switch3v3NextHandle = null;
		}
		if (this.trainingPveResetSkillCDHandle != null)
		{
			this.trainingPveResetSkillCDHandle.Remove();
			this.trainingPveResetSkillCDHandle = null;
		}
	}

	// Token: 0x06018865 RID: 100453 RVA: 0x007A7D79 File Offset: 0x007A6179
	private void SetMonsterDead()
	{
		if (this.monster == null || this.monster.IsDead())
		{
			return;
		}
		this.monster.DoDead(false);
		this.monster.m_pkGeActor.SetActorVisible(false);
	}

	// Token: 0x06018866 RID: 100454 RVA: 0x007A7DB4 File Offset: 0x007A61B4
	private void SetUseCount()
	{
		if (!this.pveNeedCheckFlag)
		{
			return;
		}
		if (base.owner != null && base.owner.isLocalActor)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.SetSkillUseCount(this.skillID, this.maxCount - this.curUseCount, this.skillData.Icon);
			}
		}
	}

	// Token: 0x04011B04 RID: 72452
	private int[] useCountMax = new int[2];

	// Token: 0x04011B05 RID: 72453
	private int[] monsterIdArr = new int[2];

	// Token: 0x04011B06 RID: 72454
	private int curUseCount;

	// Token: 0x04011B07 RID: 72455
	private int maxCount;

	// Token: 0x04011B08 RID: 72456
	public bool cancelSetMonsterDead = true;

	// Token: 0x04011B09 RID: 72457
	private BeActor monster;

	// Token: 0x04011B0A RID: 72458
	private BeEventHandle rebornHandle;

	// Token: 0x04011B0B RID: 72459
	private BeEventHandle deadTowerHandle;

	// Token: 0x04011B0C RID: 72460
	private BeEventHandle switch3v3NextHandle;

	// Token: 0x04011B0D RID: 72461
	private BeEventHandle trainingPveResetSkillCDHandle;

	// Token: 0x04011B0E RID: 72462
	private bool pveNeedCheckFlag = true;
}
