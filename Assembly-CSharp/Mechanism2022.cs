using System;
using GameClient;

// Token: 0x0200434C RID: 17228
public class Mechanism2022 : BeMechanism
{
	// Token: 0x06017DA5 RID: 97701 RVA: 0x0075F63D File Offset: 0x0075DA3D
	public Mechanism2022(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017DA6 RID: 97702 RVA: 0x0075F668 File Offset: 0x0075DA68
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onReplaceSkill, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			if (array[0] == this.originSkillID01 && base.owner.sgGetCurrentState() == 6)
			{
				BeSkill skill = base.owner.GetSkill(this.originSkillID01);
				if (skill == null)
				{
					return;
				}
				if (!skill.isCooldown)
				{
					BeSkill skill2 = base.owner.GetSkill(this.m_ReplaceJumpAttackId);
					if (skill2 != null)
					{
						skill2.level = skill.level;
						array[0] = this.m_ReplaceJumpAttackId;
						skill.StartCoolDown();
					}
				}
				else if (skill.isCooldown && base.owner.isLocalActor && base.owner.m_pkGeActor != null)
				{
					base.owner.m_pkGeActor.CreateHeadText(HitTextType.SKILL_CANNOTUSE, "UI/Font/new_font/pic_incd.png", false, null);
				}
			}
		});
	}

	// Token: 0x0401129F RID: 70303
	protected int m_ReplaceJumpAttackId = 11042;

	// Token: 0x040112A0 RID: 70304
	private int originSkillID01 = 1104;

	// Token: 0x040112A1 RID: 70305
	private int originSkillID02 = 11040;
}
