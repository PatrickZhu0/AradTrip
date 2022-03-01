using System;

// Token: 0x020044B8 RID: 17592
public class Skill3017 : BeSkill
{
	// Token: 0x06018789 RID: 100233 RVA: 0x007A3AB9 File Offset: 0x007A1EB9
	public Skill3017(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601878A RID: 100234 RVA: 0x007A3AF8 File Offset: 0x007A1EF8
	public override void OnPostInit()
	{
		this.maxCount = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.count = this.maxCount;
		if (this.handle0 == null)
		{
			this.handle0 = base.owner.RegisterEvent(BeEventType.onReplaceSkill, delegate(object[] args)
			{
				if (base.owner.sgGetCurrentState() == 5)
				{
					return;
				}
				if (base.owner.HasTag(2))
				{
					return;
				}
				int[] array = (int[])args[0];
				if (array[0] == this.originalSkillId)
				{
					BeSkill skill = base.owner.GetSkill(this.replaceSkillId);
					if (skill != null && skill.CanUseSkill())
					{
						array[0] = this.replaceSkillId;
					}
				}
			});
		}
	}

	// Token: 0x0601878B RID: 100235 RVA: 0x007A3B60 File Offset: 0x007A1F60
	public override void OnStart()
	{
		this.canUseFlag = false;
		this.handle1 = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			BeEntity beEntity = args[0] as BeEntity;
			int num = (int)args[2];
			if (num == 3017)
			{
				base.owner.SetMoveSpeedZ(this.upSpeed);
				base.owner.sgSwitchStates(new BeStateData(5, 0));
				base.owner.delayCaller.DelayCall(this.shortCD, delegate
				{
					this.canUseFlag = true;
				}, 0, 0, false);
			}
		});
		this.handle2 = base.owner.RegisterEvent(BeEventType.onTouchGround, delegate(object[] args)
		{
			this.StartCD();
		});
		this.count--;
		if (this.count > 0)
		{
			base.SetIgnoreCD(true, false);
		}
		else
		{
			base.SetIgnoreCD(false, false);
			int[] currSkillPhase = new int[]
			{
				3017,
				30173,
				30174
			};
			base.owner.SetCurrSkillPhase(currSkillPhase);
			this.walk = false;
		}
	}

	// Token: 0x0601878C RID: 100236 RVA: 0x007A3C06 File Offset: 0x007A2006
	public void StartCD()
	{
		if (!base.isCooldown)
		{
			base.SetIgnoreCD(false, false);
			base.StartCoolDown();
			this.count = this.maxCount;
			this.canUseFlag = true;
		}
	}

	// Token: 0x0601878D RID: 100237 RVA: 0x007A3C34 File Offset: 0x007A2034
	public override bool CanUseSkill()
	{
		if (!this.canUseFlag || !base.CanUseSkill())
		{
			return false;
		}
		if (base.owner.HasTag(2) || base.owner.sgGetCurrentState() == 5)
		{
			bool flag = base.owner.GetPosition().z > GlobalLogic.VALUE_10000;
			if (base.button != null)
			{
				if (flag)
				{
					base.button.AddEffect(ETCButton.eEffectType.onContinue, false);
				}
				else
				{
					base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
				}
			}
			return flag;
		}
		return true;
	}

	// Token: 0x0601878E RID: 100238 RVA: 0x007A3CCF File Offset: 0x007A20CF
	public override void OnCancel()
	{
		this.Release();
	}

	// Token: 0x0601878F RID: 100239 RVA: 0x007A3CD7 File Offset: 0x007A20D7
	public override void OnFinish()
	{
		this.Release();
	}

	// Token: 0x06018790 RID: 100240 RVA: 0x007A3CDF File Offset: 0x007A20DF
	private void Release()
	{
		if (this.count <= 0)
		{
			base.StartCoolDown();
			this.count = this.maxCount;
			this.canUseFlag = true;
		}
		this.walk = true;
		this.RemoveButtonEffect();
		this.RemoveHandle();
	}

	// Token: 0x06018791 RID: 100241 RVA: 0x007A3D19 File Offset: 0x007A2119
	public void RemoveButtonEffect()
	{
		if (base.button != null)
		{
			base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
		}
	}

	// Token: 0x06018792 RID: 100242 RVA: 0x007A3D39 File Offset: 0x007A2139
	private void RemoveHandle()
	{
		if (this.handle1 != null)
		{
			this.handle1.Remove();
			this.handle1 = null;
		}
		if (this.handle2 != null)
		{
			this.handle2.Remove();
			this.handle2 = null;
		}
	}

	// Token: 0x04011A8C RID: 72332
	private int maxCount;

	// Token: 0x04011A8D RID: 72333
	private int originalSkillId = 3017;

	// Token: 0x04011A8E RID: 72334
	private int replaceSkillId = 3018;

	// Token: 0x04011A8F RID: 72335
	private int shortCD = 200;

	// Token: 0x04011A90 RID: 72336
	private int upSpeed = 80000;

	// Token: 0x04011A91 RID: 72337
	private BeEventHandle handle0;

	// Token: 0x04011A92 RID: 72338
	private BeEventHandle handle1;

	// Token: 0x04011A93 RID: 72339
	private BeEventHandle handle2;

	// Token: 0x04011A94 RID: 72340
	private bool canUseFlag = true;

	// Token: 0x04011A95 RID: 72341
	private int count;
}
