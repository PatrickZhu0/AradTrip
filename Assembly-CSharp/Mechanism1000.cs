using System;
using System.Collections.Generic;

// Token: 0x02004249 RID: 16969
public class Mechanism1000 : BeMechanism
{
	// Token: 0x060177AB RID: 96171 RVA: 0x0073853F File Offset: 0x0073693F
	public Mechanism1000(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177AC RID: 96172 RVA: 0x00738554 File Offset: 0x00736954
	public override void OnInit()
	{
		base.OnInit();
		this.walkSpeedAdd = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueB.Count > 0)
		{
			for (int i = 0; i < this.data.ValueB.Count; i++)
			{
				this.relateSkillList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
			}
		}
	}

	// Token: 0x060177AD RID: 96173 RVA: 0x007385F3 File Offset: 0x007369F3
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onSkillPostInit, delegate(object[] args)
		{
			int num = (int)args[0];
			if (this.relateSkillList != null && this.relateSkillList.Contains(num))
			{
				this.ChangeSkillWalkSpeed(num, true);
			}
		});
	}

	// Token: 0x060177AE RID: 96174 RVA: 0x0073861C File Offset: 0x00736A1C
	public override void OnFinish()
	{
		if (this.relateSkillList == null)
		{
			return;
		}
		base.OnFinish();
		for (int i = 0; i < this.relateSkillList.Count; i++)
		{
			this.ChangeSkillWalkSpeed(this.relateSkillList[i], false);
		}
	}

	// Token: 0x060177AF RID: 96175 RVA: 0x0073866C File Offset: 0x00736A6C
	protected void ChangeSkillWalkSpeed(int skillId, bool isAdd = false)
	{
		BeSkill skill = base.owner.GetSkill(skillId);
		if (skill == null)
		{
			return;
		}
		int num = (int)skill.walkSpeed.nom;
		if (isAdd)
		{
			num += this.walkSpeedAdd;
		}
		else
		{
			num -= this.walkSpeedAdd;
		}
		skill.walkSpeed = new VFactor((long)num, (long)GlobalLogic.VALUE_1000);
	}

	// Token: 0x04010DF0 RID: 69104
	protected int walkSpeedAdd;

	// Token: 0x04010DF1 RID: 69105
	protected List<int> relateSkillList = new List<int>();
}
