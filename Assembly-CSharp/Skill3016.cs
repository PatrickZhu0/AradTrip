using System;

// Token: 0x020044B7 RID: 17591
public class Skill3016 : BeSkill
{
	// Token: 0x06018785 RID: 100229 RVA: 0x007A3A11 File Offset: 0x007A1E11
	public Skill3016(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018786 RID: 100230 RVA: 0x007A3A24 File Offset: 0x007A1E24
	public override void OnInit()
	{
		base.OnInit();
		if (this.skillData.ValueA.Length > 0)
		{
			this.m_CanJianding = (TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true) == 0);
		}
	}

	// Token: 0x06018787 RID: 100231 RVA: 0x007A3A73 File Offset: 0x007A1E73
	public override void OnStart()
	{
		base.OnStart();
		if (this.m_CanJianding)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onCastNormalAttack, new BeEventHandle.Del(this.OnNormalAttack));
		}
	}

	// Token: 0x06018788 RID: 100232 RVA: 0x007A3AA5 File Offset: 0x007A1EA5
	private void OnNormalAttack(object[] args)
	{
		base.owner.UseSkill(3004, true);
	}

	// Token: 0x04011A8B RID: 72331
	private bool m_CanJianding = true;
}
