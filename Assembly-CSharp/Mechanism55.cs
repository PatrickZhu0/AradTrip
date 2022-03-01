using System;

// Token: 0x020043F6 RID: 17398
public class Mechanism55 : BeMechanism
{
	// Token: 0x06018266 RID: 98918 RVA: 0x007832C3 File Offset: 0x007816C3
	public Mechanism55(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018267 RID: 98919 RVA: 0x007832E3 File Offset: 0x007816E3
	public override void OnStart()
	{
		this.RemoveHandle();
		this.m_ReplaceSkillHandle = base.owner.RegisterEvent(BeEventType.onReplaceSkill, delegate(object[] args)
		{
			if (base.owner.sgGetCurrentState() == 5 || base.owner.sgGetCurrentState() == 6)
			{
				BeSkill skill = base.owner.GetSkill(this.m_OriginalSkillId);
				if (skill != null && !skill.isCooldown)
				{
					int[] array = (int[])args[0];
					if (array[0] == this.m_OriginalSkillId)
					{
						array[0] = this.m_ReplaceAttackId;
						skill.StartCoolDown();
					}
				}
			}
		});
	}

	// Token: 0x06018268 RID: 98920 RVA: 0x0078330A File Offset: 0x0078170A
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x06018269 RID: 98921 RVA: 0x00783312 File Offset: 0x00781712
	protected void RemoveHandle()
	{
		if (this.m_ReplaceSkillHandle != null)
		{
			this.m_ReplaceSkillHandle.Remove();
		}
	}

	// Token: 0x040116BE RID: 71358
	protected int m_ReplaceAttackId = 2016;

	// Token: 0x040116BF RID: 71359
	protected int m_OriginalSkillId = 2006;

	// Token: 0x040116C0 RID: 71360
	protected BeEventHandle m_ReplaceSkillHandle;
}
