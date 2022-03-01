using System;
using System.Collections.Generic;

// Token: 0x02004471 RID: 17521
public class Skill1811 : BeSkill
{
	// Token: 0x060185C8 RID: 99784 RVA: 0x007971B2 File Offset: 0x007955B2
	public Skill1811(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060185C9 RID: 99785 RVA: 0x007971D4 File Offset: 0x007955D4
	public override void OnInit()
	{
		this.m_RemoveBuffList.Clear();
		if (this.skillData.ValueA.Count > 0)
		{
			for (int i = 0; i < this.skillData.ValueA.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true);
				this.m_RemoveBuffList.Add(valueFromUnionCell);
			}
		}
	}

	// Token: 0x060185CA RID: 99786 RVA: 0x00797250 File Offset: 0x00795650
	public override void OnStart()
	{
		base.OnStart();
		BeSkill skill = base.owner.GetSkill(this.m_ReplaceSkillId);
		if (skill != null)
		{
			skill.ResetCoolDown();
		}
	}

	// Token: 0x060185CB RID: 99787 RVA: 0x00797281 File Offset: 0x00795681
	public override void OnPostInit()
	{
		this.pressMode = SkillPressMode.TWO_PRESS_OUT;
	}

	// Token: 0x060185CC RID: 99788 RVA: 0x0079728A File Offset: 0x0079568A
	public override void OnClickAgain()
	{
		if (base.owner.HasSkill(this.m_ReplaceSkillId))
		{
			base.owner.UseSkill(this.m_ReplaceSkillId, false);
		}
		this.OnCancel();
	}

	// Token: 0x060185CD RID: 99789 RVA: 0x007972BC File Offset: 0x007956BC
	public override void OnCancel()
	{
		if (!BattleMain.IsModePvP(base.battleType))
		{
			return;
		}
		if (this.m_RemoveBuffList.Count > 0)
		{
			for (int i = 0; i < this.m_RemoveBuffList.Count; i++)
			{
				base.owner.buffController.RemoveBuff(this.m_RemoveBuffList[i], 0, 0);
			}
		}
	}

	// Token: 0x04011963 RID: 72035
	protected int m_ReplaceSkillId = 1812;

	// Token: 0x04011964 RID: 72036
	protected List<int> m_RemoveBuffList = new List<int>();
}
