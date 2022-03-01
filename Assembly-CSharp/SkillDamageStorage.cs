using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020010E0 RID: 4320
public class SkillDamageStorage : DataManager<SkillDamageStorage>
{
	// Token: 0x0600A387 RID: 41863 RVA: 0x00218203 File Offset: 0x00216603
	public void SaveSkillDamageData(List<SkillDamageData> list)
	{
		this.skillDataStorageList = list;
	}

	// Token: 0x0600A388 RID: 41864 RVA: 0x0021820C File Offset: 0x0021660C
	public List<SkillDamageData> GetSkillDamageData()
	{
		return this.skillDataStorageList;
	}

	// Token: 0x0600A389 RID: 41865 RVA: 0x00218214 File Offset: 0x00216614
	public override void Initialize()
	{
		this.skillDataStorageList.Clear();
	}

	// Token: 0x0600A38A RID: 41866 RVA: 0x00218221 File Offset: 0x00216621
	public override void Clear()
	{
		this.ResetData();
	}

	// Token: 0x0600A38B RID: 41867 RVA: 0x00218229 File Offset: 0x00216629
	public void ResetData()
	{
		this.skillDataStorageList.Clear();
	}

	// Token: 0x04005B34 RID: 23348
	private List<SkillDamageData> skillDataStorageList = new List<SkillDamageData>();
}
