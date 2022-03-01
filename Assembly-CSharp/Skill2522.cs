using System;

// Token: 0x020044A7 RID: 17575
public class Skill2522 : BeSkill
{
	// Token: 0x06018736 RID: 100150 RVA: 0x0078C863 File Offset: 0x0078AC63
	public Skill2522(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018737 RID: 100151 RVA: 0x0078C89C File Offset: 0x0078AC9C
	public override void OnStart()
	{
		base.OnStart();
		this.leftBulletNum = this.GetBulletNum();
		this.handleA = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, new BeEventHandle.Del(this.OnSkillCurFrame));
		this.handleB = base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, new BeEventHandle.Del(this.OnAfterFinalDamageNew));
	}

	// Token: 0x06018738 RID: 100152 RVA: 0x0078C8FC File Offset: 0x0078ACFC
	protected virtual int GetBulletNum()
	{
		Skill2524 skill = (Skill2524)base.owner.GetSkill(this.skillId);
		if (skill == null)
		{
			return 0;
		}
		return skill.GetLeftBulletNum();
	}

	// Token: 0x06018739 RID: 100153 RVA: 0x0078C930 File Offset: 0x0078AD30
	protected virtual void SetSilverBulletCount()
	{
		Skill2524 skill = (Skill2524)base.owner.GetSkill(this.skillId);
		if (skill == null)
		{
			return;
		}
		skill.ConsumBulletCount();
	}

	// Token: 0x0601873A RID: 100154 RVA: 0x0078C964 File Offset: 0x0078AD64
	protected virtual void OnSkillCurFrame(object[] args)
	{
		string a = (string)args[0];
		if (a == this.curFrameFlag && this.leftBulletNum > 0)
		{
			this.leftBulletNum--;
			this.SetSilverBulletCount();
		}
	}

	// Token: 0x0601873B RID: 100155 RVA: 0x0078C9AC File Offset: 0x0078ADAC
	protected virtual void OnAfterFinalDamageNew(object[] args)
	{
		int num = (int)args[2];
		BeActor beActor = (BeActor)args[1];
		if (num == this.effectId && beActor != null && this.leftBulletNum > 0)
		{
			base.owner.DoAttackTo(beActor, this.attachEffectId, false, true);
		}
	}

	// Token: 0x04011A3C RID: 72252
	protected int effectId = 25221;

	// Token: 0x04011A3D RID: 72253
	protected int attachEffectId = 25240;

	// Token: 0x04011A3E RID: 72254
	protected string curFrameFlag = "252201";

	// Token: 0x04011A3F RID: 72255
	protected int skillId = 2524;

	// Token: 0x04011A40 RID: 72256
	protected int leftBulletNum;
}
