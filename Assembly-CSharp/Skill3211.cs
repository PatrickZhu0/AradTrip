using System;

// Token: 0x020044C4 RID: 17604
public class Skill3211 : BeSkill
{
	// Token: 0x060187ED RID: 100333 RVA: 0x007A5BF8 File Offset: 0x007A3FF8
	public Skill3211(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060187EE RID: 100334 RVA: 0x007A5C0D File Offset: 0x007A400D
	public override void OnStart()
	{
		this.handle = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, delegate(object[] args)
		{
			string a = (string)args[0];
			if (a == this.frame)
			{
				this.frameFlag = true;
				if (base.button != null)
				{
					base.button.AddEffect(ETCButton.eEffectType.onContinue, false);
				}
			}
		});
	}

	// Token: 0x060187EF RID: 100335 RVA: 0x007A5C30 File Offset: 0x007A4030
	public override void OnClickAgain()
	{
		if (this.frameFlag)
		{
			int[] currSkillPhase = new int[]
			{
				3211,
				32112,
				32113,
				32114
			};
			base.owner.SetCurrSkillPhase(currSkillPhase);
			if (this.curPhase == 2)
			{
				((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
			}
			this.frameFlag = false;
			this.Release();
		}
	}

	// Token: 0x060187F0 RID: 100336 RVA: 0x007A5C94 File Offset: 0x007A4094
	private void Release()
	{
		this.skillButtonState = BeSkill.SkillState.NORMAL;
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
		if (base.button != null)
		{
			base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
		}
	}

	// Token: 0x060187F1 RID: 100337 RVA: 0x007A5CE3 File Offset: 0x007A40E3
	public override void OnCancel()
	{
		this.Release();
	}

	// Token: 0x060187F2 RID: 100338 RVA: 0x007A5CEB File Offset: 0x007A40EB
	public override void OnFinish()
	{
		this.Release();
	}

	// Token: 0x04011AC9 RID: 72393
	private string frame = "321120";

	// Token: 0x04011ACA RID: 72394
	private bool frameFlag;

	// Token: 0x04011ACB RID: 72395
	private BeEventHandle handle;
}
