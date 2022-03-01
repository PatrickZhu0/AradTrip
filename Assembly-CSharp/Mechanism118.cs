using System;
using System.Collections.Generic;

// Token: 0x020042E7 RID: 17127
public class Mechanism118 : BeMechanism
{
	// Token: 0x06017B30 RID: 97072 RVA: 0x0074DD8A File Offset: 0x0074C18A
	public Mechanism118(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B31 RID: 97073 RVA: 0x0074DDB4 File Offset: 0x0074C1B4
	public override void OnInit()
	{
		base.OnInit();
		this.checkSkillId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueB.Count > 0)
		{
			for (int i = 0; i < this.data.ValueB.Count; i++)
			{
				this.replaceComboSkillIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
			}
		}
		this.replaceStartFrame = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.comboSourceId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017B32 RID: 97074 RVA: 0x0074DEA4 File Offset: 0x0074C2A4
	public override void OnStart()
	{
		base.OnStart();
		this.SetComboResourceId();
		this.handleA = base.owner.RegisterEvent(BeEventType.onReplaceComboSkill, delegate(object[] args)
		{
			if (!this.canComboFlag)
			{
				return;
			}
			BeSkill currentSkill = base.owner.GetCurrentSkill();
			if (currentSkill == null || currentSkill.comboSkillSourceID != this.comboSourceId)
			{
				return;
			}
			int[] array = (int[])args[0];
			if (this.curReplaceList.Count > 0)
			{
				array[0] = this.curReplaceList[0];
			}
			if (this.replaceStartFrame > 0)
			{
				array[1] = this.replaceStartFrame;
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.OnChangeWeaponEnd, delegate(object[] args)
		{
			this.SetComboResourceId();
		});
		this.handleC = base.owner.RegisterEvent(BeEventType.onCastSkill, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.checkSkillId)
			{
				this.curReplaceList.Clear();
				this.curReplaceList.AddRange(this.replaceComboSkillIdList);
				this.canComboFlag = true;
			}
			if (this.curReplaceList.Contains(num))
			{
				this.curReplaceList.Remove(num);
			}
			if (this.curReplaceList.Count <= 0)
			{
				this.canComboFlag = false;
			}
		});
	}

	// Token: 0x06017B33 RID: 97075 RVA: 0x0074DF1C File Offset: 0x0074C31C
	protected void SetComboResourceId()
	{
		if (this.replaceComboSkillIdList.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < this.replaceComboSkillIdList.Count; i++)
		{
			BeSkill skill = base.owner.GetSkill(this.replaceComboSkillIdList[i]);
			if (skill != null)
			{
				skill.comboSkillSourceID = this.comboSourceId;
			}
		}
	}

	// Token: 0x04011078 RID: 69752
	protected int checkSkillId;

	// Token: 0x04011079 RID: 69753
	protected List<int> replaceComboSkillIdList = new List<int>();

	// Token: 0x0401107A RID: 69754
	protected int replaceStartFrame = -1;

	// Token: 0x0401107B RID: 69755
	protected int comboSourceId;

	// Token: 0x0401107C RID: 69756
	protected List<int> curReplaceList = new List<int>();

	// Token: 0x0401107D RID: 69757
	protected bool canComboFlag;
}
