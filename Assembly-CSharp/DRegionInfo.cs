using System;
using System.ComponentModel;
using ProtoTable;
using UnityEngine;

// Token: 0x02004B6A RID: 19306
[Serializable]
public class DRegionInfo : DEntityInfo, ISceneRegionInfoData
{
	// Token: 0x0601C644 RID: 116292 RVA: 0x0089DD98 File Offset: 0x0089C198
	public override string GetModelPathByResID()
	{
		SceneRegionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SceneRegionTable>(this.resid, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return string.Empty;
		}
		ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.ResID, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			return string.Empty;
		}
		return tableItem2.ModelPath;
	}

	// Token: 0x0601C645 RID: 116293 RVA: 0x0089DDFC File Offset: 0x0089C1FC
	public override void Duplicate(DEntityInfo info)
	{
		base.Duplicate(info);
		DRegionInfo dregionInfo = info as DRegionInfo;
		if (dregionInfo != null)
		{
			this.regiontype = dregionInfo.regiontype;
			this.rect = dregionInfo.rect;
			this.radius = dregionInfo.radius;
			this.rotation = dregionInfo.rotation;
		}
	}

	// Token: 0x0601C646 RID: 116294 RVA: 0x0089DE4D File Offset: 0x0089C24D
	public DRegionInfo.RegionType GetRegiontype()
	{
		return this.regiontype;
	}

	// Token: 0x0601C647 RID: 116295 RVA: 0x0089DE55 File Offset: 0x0089C255
	public Vector2 GetRect()
	{
		return this.rect;
	}

	// Token: 0x0601C648 RID: 116296 RVA: 0x0089DE5D File Offset: 0x0089C25D
	public float GetRadius()
	{
		return this.radius;
	}

	// Token: 0x0601C649 RID: 116297 RVA: 0x0089DE65 File Offset: 0x0089C265
	public Quaternion GetRotation()
	{
		return this.rotation;
	}

	// Token: 0x0601C64A RID: 116298 RVA: 0x0089DE6D File Offset: 0x0089C26D
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x0601C64B RID: 116299 RVA: 0x0089DE70 File Offset: 0x0089C270
	public void SetRegiontype(DRegionInfo.RegionType type)
	{
		this.regiontype = type;
	}

	// Token: 0x0601C64C RID: 116300 RVA: 0x0089DE79 File Offset: 0x0089C279
	public void SetRadius(float r)
	{
		this.radius = r;
	}

	// Token: 0x0401386C RID: 79980
	public DRegionInfo.RegionType regiontype;

	// Token: 0x0401386D RID: 79981
	public Vector2 rect = Vector2.one;

	// Token: 0x0401386E RID: 79982
	public float radius = 1f;

	// Token: 0x0401386F RID: 79983
	public Quaternion rotation;

	// Token: 0x02004B6B RID: 19307
	public enum RegionType
	{
		// Token: 0x04013871 RID: 79985
		[Description("圆形")]
		Circle,
		// Token: 0x04013872 RID: 79986
		[Description("矩形")]
		Rectangle
	}
}
