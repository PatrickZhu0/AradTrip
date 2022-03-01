using System;
using ProtoTable;
using UnityEngine;

// Token: 0x02004B69 RID: 19305
[Serializable]
public class DDestructibleInfo : DEntityInfo, ISceneDestructibleInfoData
{
	// Token: 0x0601C63D RID: 116285 RVA: 0x0089DCCC File Offset: 0x0089C0CC
	public override string GetModelPathByResID()
	{
		DestrucTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DestrucTable>(this.resid, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return string.Empty;
		}
		ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			return string.Empty;
		}
		return tableItem2.ModelPath;
	}

	// Token: 0x0601C63E RID: 116286 RVA: 0x0089DD30 File Offset: 0x0089C130
	public override void Duplicate(DEntityInfo info)
	{
		base.Duplicate(info);
		DDestructibleInfo ddestructibleInfo = info as DDestructibleInfo;
		if (ddestructibleInfo != null)
		{
			this.rotation = ddestructibleInfo.rotation;
		}
	}

	// Token: 0x0601C63F RID: 116287 RVA: 0x0089DD5D File Offset: 0x0089C15D
	public Quaternion GetRotation()
	{
		return this.rotation;
	}

	// Token: 0x0601C640 RID: 116288 RVA: 0x0089DD65 File Offset: 0x0089C165
	public int GetLevel()
	{
		return this.level;
	}

	// Token: 0x0601C641 RID: 116289 RVA: 0x0089DD6D File Offset: 0x0089C16D
	public int GetFlushGroupID()
	{
		return this.flushGroupID;
	}

	// Token: 0x0601C642 RID: 116290 RVA: 0x0089DD75 File Offset: 0x0089C175
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x04013869 RID: 79977
	public Quaternion rotation;

	// Token: 0x0401386A RID: 79978
	public int level;

	// Token: 0x0401386B RID: 79979
	public int flushGroupID;
}
