using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x020042E5 RID: 17125
public class Mechanism1179 : BeMechanism
{
	// Token: 0x06017B2A RID: 97066 RVA: 0x0074DAB7 File Offset: 0x0074BEB7
	public Mechanism1179(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B2B RID: 97067 RVA: 0x0074DACC File Offset: 0x0074BECC
	public override void OnInit()
	{
		this.mBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueBLength > 1)
		{
			this.mSkillRelatedMinLv = TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true);
		}
		if (this.data.ValueBLength > 0)
		{
			this.mSkillRelatedMinLv = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		this.mSkillCondition = (Mechanism1179.BuffRelatedSkillCondition)TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017B2C RID: 97068 RVA: 0x0074DB9B File Offset: 0x0074BF9B
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.handleNewA = base.owner.RegisterEventNew(BeEventType.onAfterCalcBuffInfoSkillLV, new BeEvent.BeEventHandleNew.Function(this.OnChangeBuffInfoSkillIDs));
		}
	}

	// Token: 0x06017B2D RID: 97069 RVA: 0x0074DBCC File Offset: 0x0074BFCC
	protected void OnChangeBuffInfoSkillIDs(BeEvent.BeEventParam param)
	{
		BuffInfoData buffInfoData = param.m_Obj as BuffInfoData;
		if (buffInfoData == null || buffInfoData.buffInfoID != this.mBuffInfoID)
		{
			return;
		}
		if (base.owner == null)
		{
			return;
		}
		Dictionary<int, BeSkill> skills = base.owner.GetSkills();
		if (skills == null)
		{
			return;
		}
		foreach (KeyValuePair<int, BeSkill> keyValuePair in skills)
		{
			BeSkill value = keyValuePair.Value;
			if (this.FixLevel(value))
			{
				if (this.FixCondition(value))
				{
					if (!buffInfoData.skillIDs.Contains(value.skillID))
					{
						buffInfoData.skillIDs.Add(value.skillID);
					}
				}
			}
		}
	}

	// Token: 0x06017B2E RID: 97070 RVA: 0x0074DC98 File Offset: 0x0074C098
	protected bool FixLevel(BeSkill skill)
	{
		return skill != null && skill.skillData != null && ((this.data.ValueBLength == 1 && skill.skillData.LevelLimit == this.mSkillRelatedMinLv) || (this.data.ValueBLength == 2 && skill.skillData.LevelLimit >= this.mSkillRelatedMinLv && skill.skillData.LevelLimit <= this.mSkillRelatedMaxLv));
	}

	// Token: 0x06017B2F RID: 97071 RVA: 0x0074DD24 File Offset: 0x0074C124
	protected bool FixCondition(BeSkill skill)
	{
		if (skill == null || skill.skillData == null)
		{
			return false;
		}
		switch (this.mSkillCondition)
		{
		case Mechanism1179.BuffRelatedSkillCondition.NONE:
			return true;
		case Mechanism1179.BuffRelatedSkillCondition.ACTIVE_NOT_BUFF:
			return skill.skillData.SkillType == SkillTable.eSkillType.ACTIVE && skill.skillData.IsBuff == 0;
		case Mechanism1179.BuffRelatedSkillCondition.COUNT:
			return false;
		default:
			return false;
		}
	}

	// Token: 0x04011070 RID: 69744
	protected int mBuffInfoID;

	// Token: 0x04011071 RID: 69745
	protected int mSkillRelatedMinLv;

	// Token: 0x04011072 RID: 69746
	protected int mSkillRelatedMaxLv = 100;

	// Token: 0x04011073 RID: 69747
	protected Mechanism1179.BuffRelatedSkillCondition mSkillCondition;

	// Token: 0x020042E6 RID: 17126
	public enum BuffRelatedSkillCondition
	{
		// Token: 0x04011075 RID: 69749
		NONE,
		// Token: 0x04011076 RID: 69750
		ACTIVE_NOT_BUFF,
		// Token: 0x04011077 RID: 69751
		COUNT
	}
}
