using System;
using GameClient;

// Token: 0x0200449E RID: 17566
public class Skill2302 : BeSkill
{
	// Token: 0x060186DD RID: 100061 RVA: 0x0079E380 File Offset: 0x0079C780
	public Skill2302(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060186DE RID: 100062 RVA: 0x0079E398 File Offset: 0x0079C798
	public override void OnInit()
	{
		base.OnInit();
		int accSpeed = 200;
		if (this.skillData.ValueA.Count > 0)
		{
			accSpeed = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		}
		this.mLaunchHelper.Init(base.owner, base.level, accSpeed);
		this.SetSkillMode();
	}

	// Token: 0x060186DF RID: 100063 RVA: 0x0079E403 File Offset: 0x0079C803
	public override bool CanUseSkill()
	{
		return this.CanLaunch();
	}

	// Token: 0x060186E0 RID: 100064 RVA: 0x0079E40B File Offset: 0x0079C80B
	public override bool CheckSpellCondition(ActionState state)
	{
		return true;
	}

	// Token: 0x060186E1 RID: 100065 RVA: 0x0079E410 File Offset: 0x0079C810
	public override void OnClickAgain()
	{
		if (this.CanLaunch() && this.mLaunchHelper.Launch())
		{
			if (base.owner != null)
			{
				base.owner.buffController.TriggerBuffs(BuffCondition.RELEASE_SEPCIFY_SKILL, null, 2302);
			}
			base.StartCoolDown();
			this.SetDisable();
		}
		else if (base.owner.isLocalActor && base.owner.m_pkGeActor != null)
		{
			base.owner.m_pkGeActor.CreateHeadText(HitTextType.SKILL_CANNOTUSE, "UI/Font/new_font/pic_ylbmzfstj.png", false, null);
		}
	}

	// Token: 0x060186E2 RID: 100066 RVA: 0x0079E4AA File Offset: 0x0079C8AA
	private void SetSkillMode()
	{
		this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		this.pressMode = SkillPressMode.PRESS_MANY_TWO;
	}

	// Token: 0x060186E3 RID: 100067 RVA: 0x0079E4BA File Offset: 0x0079C8BA
	public override bool CanForceUseSkill()
	{
		return true;
	}

	// Token: 0x060186E4 RID: 100068 RVA: 0x0079E4BD File Offset: 0x0079C8BD
	private bool CanLaunch()
	{
		return this.IsActive() && this.HasChaser() && !base.isCooldown && this.mLaunchHelper.CanLaunch() && base.CanUseSkill();
	}

	// Token: 0x060186E5 RID: 100069 RVA: 0x0079E4FC File Offset: 0x0079C8FC
	private bool IsActive()
	{
		if (base.owner == null)
		{
			return false;
		}
		BeMechanism mechanism = base.owner.GetMechanism(5284);
		if (mechanism == null)
		{
			return false;
		}
		Mechanism2079 mechanism2 = mechanism as Mechanism2079;
		return mechanism2 != null && mechanism2.IsActive();
	}

	// Token: 0x060186E6 RID: 100070 RVA: 0x0079E544 File Offset: 0x0079C944
	private void SetDisable()
	{
		BeMechanism mechanism = base.owner.GetMechanism(5284);
		if (mechanism == null)
		{
			return;
		}
		Mechanism2079 mechanism2 = mechanism as Mechanism2079;
		if (mechanism2 != null)
		{
			mechanism2.SetActive(false);
		}
	}

	// Token: 0x060186E7 RID: 100071 RVA: 0x0079E580 File Offset: 0x0079C980
	private bool HasChaser()
	{
		if (base.owner == null)
		{
			return false;
		}
		BeMechanism mechanism = base.owner.GetMechanism(Mechanism2072.ChaserMgrID);
		if (mechanism == null)
		{
			return false;
		}
		Mechanism2072 mechanism2 = mechanism as Mechanism2072;
		return mechanism2 != null && mechanism2.GetChaserCount() > 0;
	}

	// Token: 0x060186E8 RID: 100072 RVA: 0x0079E5CB File Offset: 0x0079C9CB
	public override void OnFinish()
	{
		base.OnFinish();
		if (this.mLaunchHelper != null)
		{
			this.mLaunchHelper.Destroy();
			this.mLaunchHelper = null;
		}
	}

	// Token: 0x04011A06 RID: 72198
	private LaunchChaser mLaunchHelper = new LaunchChaser();
}
