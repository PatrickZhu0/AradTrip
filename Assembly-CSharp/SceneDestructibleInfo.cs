using System;
using FBSceneData;
using ProtoTable;
using UnityEngine;

// Token: 0x02004B53 RID: 19283
public class SceneDestructibleInfo : SceneEntityInfo, ISceneDestructibleInfoData
{
	// Token: 0x0601C56A RID: 116074 RVA: 0x0089C4AA File Offset: 0x0089A8AA
	public SceneDestructibleInfo(FBSceneData.DDestructibleInfo data) : base(data.Super)
	{
		this.mData = data;
	}

	// Token: 0x0601C56B RID: 116075 RVA: 0x0089C4C0 File Offset: 0x0089A8C0
	public override string GetModelPathByResID()
	{
		DestrucTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DestrucTable>(base.GetResid(), string.Empty, string.Empty);
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

	// Token: 0x0601C56C RID: 116076 RVA: 0x0089C521 File Offset: 0x0089A921
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x0601C56D RID: 116077 RVA: 0x0089C524 File Offset: 0x0089A924
	public int GetFlushGroupID()
	{
		return this.mData.FlushGroupID;
	}

	// Token: 0x0601C56E RID: 116078 RVA: 0x0089C531 File Offset: 0x0089A931
	public int GetLevel()
	{
		return this.mData.Level;
	}

	// Token: 0x0601C56F RID: 116079 RVA: 0x0089C540 File Offset: 0x0089A940
	public Quaternion GetRotation()
	{
		return new Quaternion(this.mData.Rotation.X, this.mData.Rotation.Y, this.mData.Rotation.Z, this.mData.Rotation.W);
	}

	// Token: 0x040137EF RID: 79855
	private FBSceneData.DDestructibleInfo mData;
}
