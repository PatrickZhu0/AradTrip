using System;
using GameClient;

// Token: 0x0200440C RID: 17420
public class Mechanism74 : BeMechanism
{
	// Token: 0x06018316 RID: 99094 RVA: 0x00787A45 File Offset: 0x00785E45
	public Mechanism74(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018317 RID: 99095 RVA: 0x00787A65 File Offset: 0x00785E65
	public override void OnStart()
	{
		base.OnStart();
		this.m_JumpBackHandle = base.owner.RegisterEvent(BeEventType.onJumpBackAttack, delegate(object[] args)
		{
			BeSkill skill = base.owner.GetSkill(this.jumpBackAttackID);
			if (skill == null)
			{
				return;
			}
			if (!skill.isCooldown)
			{
				base.owner.UseSkill(this.m_ReplaceJumpAttackId, true);
				BeSkill skill2 = base.owner.GetSkill(this.jumpBackAttackID);
				if (skill2 != null)
				{
					skill2.StartCoolDown();
				}
			}
			else if (skill.isCooldown && base.owner.isLocalActor)
			{
				base.owner.m_pkGeActor.CreateHeadText(HitTextType.SKILL_CANNOTUSE, "UI/Font/new_font/pic_incd.png", false, null);
			}
		});
	}

	// Token: 0x06018318 RID: 99096 RVA: 0x00787A8C File Offset: 0x00785E8C
	public override void OnFinish()
	{
		if (this.m_JumpBackHandle != null)
		{
			this.m_JumpBackHandle.Remove();
			this.m_JumpBackHandle = null;
		}
	}

	// Token: 0x0401175B RID: 71515
	protected int m_ReplaceJumpAttackId = 1919;

	// Token: 0x0401175C RID: 71516
	protected BeEventHandle m_JumpBackHandle;

	// Token: 0x0401175D RID: 71517
	private int jumpBackAttackID = 1907;
}
