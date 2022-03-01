using System;

// Token: 0x020044BD RID: 17597
internal class Skill3113 : BeSkill
{
	// Token: 0x060187B3 RID: 100275 RVA: 0x007A47C0 File Offset: 0x007A2BC0
	public Skill3113(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060187B4 RID: 100276 RVA: 0x007A47D8 File Offset: 0x007A2BD8
	public override void OnStart()
	{
		base.owner.SetMoveSpeedZ(0);
		if (base.owner.GetPosition().z > GlobalLogic.VALUE_5000)
		{
			int[] currSkillPhase = new int[]
			{
				3113,
				31131
			};
			base.owner.SetCurrSkillPhase(currSkillPhase);
		}
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

	// Token: 0x060187B5 RID: 100277 RVA: 0x007A4858 File Offset: 0x007A2C58
	public override void OnClickAgain()
	{
		if (this.frameFlag)
		{
			int[] currSkillPhase = new int[]
			{
				3113,
				31131,
				31133,
				31134
			};
			base.owner.SetCurrSkillPhase(currSkillPhase);
			if (this.curPhase == 1)
			{
				VInt3 position = base.owner.GetPosition();
				position.z += GlobalLogic.VALUE_5000;
				base.owner.SetPosition(position, false, true, false);
				((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
				((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
			}
			else if (this.curPhase == 2)
			{
				VInt3 position2 = base.owner.GetPosition();
				position2.z += GlobalLogic.VALUE_5000;
				base.owner.SetPosition(position2, false, true, false);
				((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
			}
			this.frameFlag = false;
			this.Release();
		}
	}

	// Token: 0x060187B6 RID: 100278 RVA: 0x007A4953 File Offset: 0x007A2D53
	public override bool CanUseSkill()
	{
		return base.CanUseSkill() && base.owner.moveZSpeed < 72000;
	}

	// Token: 0x060187B7 RID: 100279 RVA: 0x007A4978 File Offset: 0x007A2D78
	private void Release()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
		this.skillButtonState = BeSkill.SkillState.NORMAL;
		if (base.button != null)
		{
			base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
		}
	}

	// Token: 0x060187B8 RID: 100280 RVA: 0x007A49C7 File Offset: 0x007A2DC7
	public override void OnCancel()
	{
		this.Release();
	}

	// Token: 0x060187B9 RID: 100281 RVA: 0x007A49CF File Offset: 0x007A2DCF
	public override void OnFinish()
	{
		this.Release();
	}

	// Token: 0x04011AA3 RID: 72355
	private string frame = "311310";

	// Token: 0x04011AA4 RID: 72356
	private bool frameFlag;

	// Token: 0x04011AA5 RID: 72357
	private BeEventHandle handle;
}
