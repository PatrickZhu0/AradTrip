using System;
using System.Collections.Generic;

// Token: 0x02004134 RID: 16692
public class BDEntityRes
{
	// Token: 0x06016B7E RID: 93054 RVA: 0x006EB200 File Offset: 0x006E9600
	public void SetActionName(string s)
	{
		this.currentActionName = s;
	}

	// Token: 0x06016B7F RID: 93055 RVA: 0x006EB209 File Offset: 0x006E9609
	public string GetCurrentActionName()
	{
		return this.currentActionName;
	}

	// Token: 0x06016B80 RID: 93056 RVA: 0x006EB211 File Offset: 0x006E9611
	public bool HasAction(string key)
	{
		return key != null && this._vkActionsMap.ContainsKey(key);
	}

	// Token: 0x06016B81 RID: 93057 RVA: 0x006EB227 File Offset: 0x006E9627
	public void Reset()
	{
		this._vkActionsMap.Clear();
	}

	// Token: 0x06016B82 RID: 93058 RVA: 0x006EB234 File Offset: 0x006E9634
	public void AddActionInfo(BDEntityActionInfo info, string path)
	{
		if (info.weaponTag == 0)
		{
			if (!this._vkActionsMap.ContainsKey(info.moveName))
			{
				this._vkActionsMap.Add(info.moveName, info);
			}
			if (info.skillID != 0 && !this.skillData.ContainsKey(info.skillID))
			{
				this.skillData.Add(info.skillID, info.moveName);
			}
			return;
		}
		if (!this.HasTagActionInfo(info.weaponTag))
		{
			this.tagActionInfo[info.weaponTag] = new BDEntityRes.TagActionInfo();
		}
		this.tagActionInfo[info.weaponTag].AddActionInfo(info);
	}

	// Token: 0x06016B83 RID: 93059 RVA: 0x006EB2F0 File Offset: 0x006E96F0
	public void SetWeaponInfo(int tag, int type = 0)
	{
		if (!this.HasTagActionInfo(tag))
		{
			return;
		}
		List<string> list = this.tagActionInfo[tag].weaponTypeSkillDataInfo[0];
		if (list != null)
		{
			this.ReplaceActionInfo(list, this.tagActionInfo[tag]);
		}
		if (type != 0 && this.tagActionInfo[tag].HasWeaponType(type))
		{
			this.ReplaceActionInfo(this.tagActionInfo[tag].weaponTypeSkillDataInfo[type], this.tagActionInfo[tag]);
		}
	}

	// Token: 0x06016B84 RID: 93060 RVA: 0x006EB370 File Offset: 0x006E9770
	public void ReplaceActionInfo(List<string> lst, BDEntityRes.TagActionInfo tagInfo)
	{
		for (int i = 0; i < lst.Count; i++)
		{
			string text = lst[i];
			BDEntityActionInfo actionInfo = tagInfo.GetActionInfo(text);
			if (!this._vkActionsMap.ContainsKey(text))
			{
				this._vkActionsMap.Add(text, actionInfo);
			}
			else
			{
				this._vkActionsMap[text] = actionInfo;
			}
			if (!this.skillData.ContainsKey(actionInfo.skillID))
			{
				this.skillData.Add(actionInfo.skillID, text);
			}
			else
			{
				this.skillData[actionInfo.skillID] = text;
			}
		}
	}

	// Token: 0x06016B85 RID: 93061 RVA: 0x006EB413 File Offset: 0x006E9813
	private bool HasTagActionInfo(int tag)
	{
		return this.tagActionInfo[tag] != null;
	}

	// Token: 0x040103EF RID: 66543
	public Dictionary<string, BDEntityActionInfo> _vkActionsMap = new Dictionary<string, BDEntityActionInfo>();

	// Token: 0x040103F0 RID: 66544
	public Dictionary<int, string> skillData = new Dictionary<int, string>();

	// Token: 0x040103F1 RID: 66545
	public BDEntityRes.TagActionInfo[] tagActionInfo = new BDEntityRes.TagActionInfo[10];

	// Token: 0x040103F2 RID: 66546
	protected string currentActionName = string.Empty;

	// Token: 0x02004135 RID: 16693
	public class TagActionInfo
	{
		// Token: 0x06016B87 RID: 93063 RVA: 0x006EB444 File Offset: 0x006E9844
		public void AddActionInfo(BDEntityActionInfo info)
		{
			if (!this.weaponTypeSkillDataInfo.ContainsKey(info.weaponType))
			{
				this.weaponTypeSkillDataInfo.Add(info.weaponType, new List<string>());
			}
			this.weaponTypeSkillDataInfo[info.weaponType].Add(info.moveName);
			if (!this.actionMap.ContainsKey(info.moveName))
			{
				this.actionMap.Add(info.moveName, info);
			}
		}

		// Token: 0x06016B88 RID: 93064 RVA: 0x006EB4C1 File Offset: 0x006E98C1
		public BDEntityActionInfo GetActionInfo(string res)
		{
			return this.actionMap[res];
		}

		// Token: 0x06016B89 RID: 93065 RVA: 0x006EB4CF File Offset: 0x006E98CF
		public bool HasWeaponType(int weaponType)
		{
			return this.weaponTypeSkillDataInfo.ContainsKey(weaponType);
		}

		// Token: 0x040103F3 RID: 66547
		public Dictionary<string, BDEntityActionInfo> actionMap = new Dictionary<string, BDEntityActionInfo>();

		// Token: 0x040103F4 RID: 66548
		public Dictionary<int, List<string>> weaponTypeSkillDataInfo = new Dictionary<int, List<string>>();
	}
}
