using System;
using FBSceneData;
using ProtoTable;
using UnityEngine;

// Token: 0x02004B50 RID: 19280
public class SceneEntityInfo : ISceneEntityInfoData
{
	// Token: 0x0601C551 RID: 116049 RVA: 0x0089C0DF File Offset: 0x0089A4DF
	public SceneEntityInfo(FBSceneData.DEntityInfo data)
	{
		this.mData = data;
	}

	// Token: 0x0601C552 RID: 116050 RVA: 0x0089C0F0 File Offset: 0x0089A4F0
	public Color GetColor()
	{
		return new Color(this.mData.Color.R, this.mData.Color.G, this.mData.Color.B, this.mData.Color.A);
	}

	// Token: 0x0601C553 RID: 116051 RVA: 0x0089C142 File Offset: 0x0089A542
	public string GetDescription()
	{
		return this.mData.Description;
	}

	// Token: 0x0601C554 RID: 116052 RVA: 0x0089C14F File Offset: 0x0089A54F
	public int GetGlobalid()
	{
		return this.mData.Globalid;
	}

	// Token: 0x0601C555 RID: 116053 RVA: 0x0089C15C File Offset: 0x0089A55C
	public virtual string GetModelPathByResID()
	{
		ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(this.GetResid(), string.Empty, string.Empty);
		if (tableItem == null)
		{
			return string.Empty;
		}
		return tableItem.ModelPath;
	}

	// Token: 0x0601C556 RID: 116054 RVA: 0x0089C196 File Offset: 0x0089A596
	public string GetName()
	{
		return this.mData.Name;
	}

	// Token: 0x0601C557 RID: 116055 RVA: 0x0089C1A3 File Offset: 0x0089A5A3
	public string GetPath()
	{
		return this.mData.Path;
	}

	// Token: 0x0601C558 RID: 116056 RVA: 0x0089C1B0 File Offset: 0x0089A5B0
	public Vector3 GetPosition()
	{
		return new Vector3(this.mData.Position.X, this.mData.Position.Y, this.mData.Position.Z);
	}

	// Token: 0x0601C559 RID: 116057 RVA: 0x0089C1E7 File Offset: 0x0089A5E7
	public int GetResid()
	{
		return this.mData.Resid;
	}

	// Token: 0x0601C55A RID: 116058 RVA: 0x0089C1F4 File Offset: 0x0089A5F4
	public float GetScale()
	{
		return this.mData.Scale;
	}

	// Token: 0x0601C55B RID: 116059 RVA: 0x0089C201 File Offset: 0x0089A601
	public string GetTypename()
	{
		return this.mData.TypeName;
	}

	// Token: 0x0601C55C RID: 116060 RVA: 0x0089C20E File Offset: 0x0089A60E
	global::DEntityType ISceneEntityInfoData.GetType()
	{
		return (global::DEntityType)this.mData.Type;
	}

	// Token: 0x040137EB RID: 79851
	private FBSceneData.DEntityInfo mData;
}
