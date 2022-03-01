using System;
using GameClient;

// Token: 0x020044CE RID: 17614
public class Skill3712 : Skill3703
{
	// Token: 0x06018833 RID: 100403 RVA: 0x007A6E6D File Offset: 0x007A526D
	public Skill3712(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018834 RID: 100404 RVA: 0x007A6E83 File Offset: 0x007A5283
	public override void OnInit()
	{
		base.OnInit();
		this.OnPostInit();
	}

	// Token: 0x06018835 RID: 100405 RVA: 0x007A6E94 File Offset: 0x007A5294
	public override void OnPostInit()
	{
		base.OnPostInit();
		this.useCountMax[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.useCountMax[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true);
		this.maxCount = ((!BattleMain.IsModePvP(base.battleType)) ? this.useCountMax[0] : this.useCountMax[1]);
		base.owner.delayCaller.DelayCall(100, delegate
		{
			this.ResetUseCount(false);
		}, 0, 0, false);
		this.addBuffTag = "371201";
	}

	// Token: 0x06018836 RID: 100406 RVA: 0x007A6F4C File Offset: 0x007A534C
	public override void OnStart()
	{
		base.OnStart();
		this.curUseCount++;
		this.SetUseCount();
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
	}

	// Token: 0x06018837 RID: 100407 RVA: 0x007A7012 File Offset: 0x007A5412
	private void ResetUseCount(bool resetCurCount = true)
	{
		if (resetCurCount)
		{
			this.curUseCount = 0;
		}
		this.SetUseCount();
	}

	// Token: 0x06018838 RID: 100408 RVA: 0x007A7027 File Offset: 0x007A5427
	public override bool CanUseSkill()
	{
		return this.curUseCount < this.maxCount && base.CanUseSkill();
	}

	// Token: 0x06018839 RID: 100409 RVA: 0x007A7042 File Offset: 0x007A5442
	public override BeActor.SkillCannotUseType GetCannotUseType()
	{
		if (this.curUseCount >= this.maxCount)
		{
			return BeActor.SkillCannotUseType.CAN_NOT_USE;
		}
		return base.GetCannotUseType();
	}

	// Token: 0x0601883A RID: 100410 RVA: 0x007A7060 File Offset: 0x007A5460
	private void SetUseCount()
	{
		if (base.owner == null || !base.owner.isLocalActor)
		{
			return;
		}
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle == null)
		{
			return;
		}
		clientSystemBattle.SetSkillUseCount(this.skillID, this.maxCount - this.curUseCount, this.skillData.Icon);
	}

	// Token: 0x0601883B RID: 100411 RVA: 0x007A70C4 File Offset: 0x007A54C4
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

	// Token: 0x04011AEA RID: 72426
	private int[] useCountMax = new int[2];

	// Token: 0x04011AEB RID: 72427
	private int curUseCount;

	// Token: 0x04011AEC RID: 72428
	private int maxCount;

	// Token: 0x04011AED RID: 72429
	private BeEventHandle rebornHandle;

	// Token: 0x04011AEE RID: 72430
	private BeEventHandle deadTowerHandle;

	// Token: 0x04011AEF RID: 72431
	private BeEventHandle switch3v3NextHandle;

	// Token: 0x04011AF0 RID: 72432
	private BeEventHandle trainingPveResetSkillCDHandle;
}
