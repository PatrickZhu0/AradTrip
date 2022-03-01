using System;

// Token: 0x020044BA RID: 17594
public class Skill3100 : BeSkill
{
	// Token: 0x0601879C RID: 100252 RVA: 0x007A3F44 File Offset: 0x007A2344
	public Skill3100(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601879D RID: 100253 RVA: 0x007A3F4E File Offset: 0x007A234E
	public override void OnInit()
	{
		base.OnInit();
		if (!BattleMain.IsModePvP(base.battleType))
		{
			this.pressMode = SkillPressMode.PRESS_AGAIN_CANCEL_OUT;
		}
	}

	// Token: 0x0601879E RID: 100254 RVA: 0x007A3F6D File Offset: 0x007A236D
	public override void OnStart()
	{
		base.OnStart();
		if (!BattleMain.IsModePvP(base.battleType))
		{
			this.SetButtonMode(false);
		}
	}

	// Token: 0x0601879F RID: 100255 RVA: 0x007A3F8C File Offset: 0x007A238C
	public override void OnClickAgainCancel()
	{
		base.OnClickAgainCancel();
		this.SetButtonMode(true);
		this.RemoveBuffs();
	}

	// Token: 0x060187A0 RID: 100256 RVA: 0x007A3FA4 File Offset: 0x007A23A4
	protected void SetButtonMode(bool isRestore = false)
	{
		if (!isRestore)
		{
			this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
			if (base.button != null)
			{
				base.button.AddEffect(ETCButton.eEffectType.onContinue, true);
			}
		}
		else
		{
			this.skillButtonState = BeSkill.SkillState.NORMAL;
			if (base.button != null)
			{
				base.button.RemoveEffect(ETCButton.eEffectType.onContinue, true);
			}
		}
	}

	// Token: 0x060187A1 RID: 100257 RVA: 0x007A4008 File Offset: 0x007A2408
	protected void RemoveBuffs()
	{
		for (int i = 0; i < this.skillData.ValueA.Count; i++)
		{
			base.owner.buffController.RemoveBuff(TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true), 0, 0);
		}
	}
}
