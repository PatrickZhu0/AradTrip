using System;
using System.Collections.Generic;

// Token: 0x0200430B RID: 17163
internal class Mechanism133 : BeMechanism
{
	// Token: 0x06017BEC RID: 97260 RVA: 0x00753269 File Offset: 0x00751669
	public Mechanism133(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BED RID: 97261 RVA: 0x00753294 File Offset: 0x00751694
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.skillIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueB.Count; j++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true);
			if (!this.replaceSkillIdDic.ContainsKey(valueFromUnionCell))
			{
				this.replaceSkillIdDic.Add(valueFromUnionCell, this.level);
			}
		}
	}

	// Token: 0x06017BEE RID: 97262 RVA: 0x0075335B File Offset: 0x0075175B
	public override void OnStart()
	{
		base.OnStart();
		this.AddSkill();
		this.RecordBackupSkills();
		this.ReplaceSkills(true);
	}

	// Token: 0x06017BEF RID: 97263 RVA: 0x00753376 File Offset: 0x00751776
	public override void OnFinish()
	{
		base.OnFinish();
		this.RestoreAddSkills();
		this.ReplaceSkills(false);
	}

	// Token: 0x06017BF0 RID: 97264 RVA: 0x0075338C File Offset: 0x0075178C
	private void AddSkill()
	{
		if (this.skillIdList.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < this.skillIdList.Count; i++)
		{
			this.AddSkill(this.skillIdList[i], this.level);
		}
		this.RefreshAISkillList();
	}

	// Token: 0x06017BF1 RID: 97265 RVA: 0x007533EC File Offset: 0x007517EC
	private void RestoreAddSkills()
	{
		if (this.skillIdList.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < this.skillIdList.Count; i++)
		{
			this.RemoveSkillById(this.skillIdList[i]);
		}
		this.RefreshAISkillList();
	}

	// Token: 0x06017BF2 RID: 97266 RVA: 0x00753440 File Offset: 0x00751840
	private void ReplaceSkills(bool isReplace = true)
	{
		if (this.replaceSkillIdDic.Count <= 0)
		{
			return;
		}
		Dictionary<int, int> dictionary = (!isReplace) ? this.replaceSkillIdDic : this.backUpSkillDic;
		Dictionary<int, int> dictionary2 = (!isReplace) ? this.backUpSkillDic : this.replaceSkillIdDic;
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			if (!dictionary2.ContainsKey(key))
			{
				this.RemoveSkillById(key);
			}
		}
		foreach (KeyValuePair<int, int> keyValuePair2 in dictionary2)
		{
			int key2 = keyValuePair2.Key;
			Dictionary<int, int>.Enumerator enumerator2;
			KeyValuePair<int, int> keyValuePair3 = enumerator2.Current;
			int value = keyValuePair3.Value;
			if (!dictionary.ContainsKey(key2))
			{
				this.AddSkill(key2, value);
			}
		}
		this.RefreshAISkillList();
	}

	// Token: 0x06017BF3 RID: 97267 RVA: 0x00753528 File Offset: 0x00751928
	private void RecordBackupSkills()
	{
		Dictionary<int, BeSkill> skills = base.owner.GetSkills();
		foreach (KeyValuePair<int, BeSkill> keyValuePair in skills)
		{
			int key = keyValuePair.Key;
			Dictionary<int, BeSkill>.Enumerator enumerator;
			KeyValuePair<int, BeSkill> keyValuePair2 = enumerator.Current;
			BeSkill value = keyValuePair2.Value;
			if (!this.backUpSkillDic.ContainsKey(key))
			{
				this.backUpSkillDic.Add(key, value.level);
			}
		}
	}

	// Token: 0x06017BF4 RID: 97268 RVA: 0x007535A0 File Offset: 0x007519A0
	private void AddSkill(int skillId, int skillLevel = 1)
	{
		base.owner.LoadOneSkill(skillId, skillLevel);
		BeSkill skill = base.owner.GetSkill(skillId);
		if (skill != null)
		{
			skill.StartInitCD(BattleMain.IsModePvP(base.battleType));
		}
	}

	// Token: 0x06017BF5 RID: 97269 RVA: 0x007535DF File Offset: 0x007519DF
	private void RemoveSkillById(int skillId)
	{
		base.owner.RemoveSkill(skillId);
	}

	// Token: 0x06017BF6 RID: 97270 RVA: 0x007535ED File Offset: 0x007519ED
	private void RefreshAISkillList()
	{
		base.owner.aiManager.ReloadSkillInfos(base.owner.GetEntityData().monsterData);
	}

	// Token: 0x04011133 RID: 69939
	protected List<int> skillIdList = new List<int>();

	// Token: 0x04011134 RID: 69940
	protected Dictionary<int, int> replaceSkillIdDic = new Dictionary<int, int>();

	// Token: 0x04011135 RID: 69941
	protected Dictionary<int, int> backUpSkillDic = new Dictionary<int, int>();
}
