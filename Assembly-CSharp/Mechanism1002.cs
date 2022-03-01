using System;
using System.Collections.Generic;

// Token: 0x0200424A RID: 16970
public class Mechanism1002 : BeMechanism
{
	// Token: 0x060177B1 RID: 96177 RVA: 0x00738706 File Offset: 0x00736B06
	public Mechanism1002(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177B2 RID: 96178 RVA: 0x00738734 File Offset: 0x00736B34
	public override void OnInit()
	{
		base.OnInit();
		this.watchSkillId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.watchMonsterTypeList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueC.Count; j++)
		{
			this.addBuffIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true));
		}
		for (int k = 0; k < this.data.ValueD.Count; k++)
		{
			this.addBuffTimeList.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[k], this.level, true));
		}
	}

	// Token: 0x060177B3 RID: 96179 RVA: 0x00738859 File Offset: 0x00736C59
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onExcuteGrab, delegate(object[] args)
		{
			int skillId = (int)args[0];
			BeActor target = (BeActor)args[1];
			this.AddBuffId(skillId, target);
		});
	}

	// Token: 0x060177B4 RID: 96180 RVA: 0x00738880 File Offset: 0x00736C80
	protected void AddBuffId(int skillId, BeActor target)
	{
		if (skillId != this.watchSkillId)
		{
			return;
		}
		if (target == null)
		{
			return;
		}
		int index = 0;
		if (target.GetEntityData().monsterData != null)
		{
			int type = (int)target.GetEntityData().monsterData.Type;
			for (int i = 0; i < this.watchMonsterTypeList.Count; i++)
			{
				int num = this.watchMonsterTypeList[i];
				if (num == type)
				{
					index = i;
				}
			}
		}
		BeSkill skill = base.owner.GetSkill(this.watchSkillId);
		int buffLevel = 1;
		if (skill != null)
		{
			buffLevel = skill.level;
		}
		base.owner.buffController.TryAddBuff(this.addBuffIdList[index], this.addBuffTimeList[index], buffLevel);
	}

	// Token: 0x04010DF2 RID: 69106
	protected int watchSkillId;

	// Token: 0x04010DF3 RID: 69107
	protected List<int> watchMonsterTypeList = new List<int>();

	// Token: 0x04010DF4 RID: 69108
	protected List<int> addBuffIdList = new List<int>();

	// Token: 0x04010DF5 RID: 69109
	protected List<int> addBuffTimeList = new List<int>();
}
