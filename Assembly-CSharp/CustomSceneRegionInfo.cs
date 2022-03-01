using System;
using ProtoTable;
using UnityEngine;

// Token: 0x020041F9 RID: 16889
public class CustomSceneRegionInfo : ISceneEntityInfoData, ISceneRegionInfoData
{
	// Token: 0x060175D8 RID: 95704 RVA: 0x0072E197 File Offset: 0x0072C597
	public CustomSceneRegionInfo(int resId, VInt3 pos, int globalId)
	{
		this.mResId = resId;
		this.mPos = pos;
		this.mGlobalId = globalId;
	}

	// Token: 0x060175D9 RID: 95705 RVA: 0x0072E1B4 File Offset: 0x0072C5B4
	public string GetModelPathByResID()
	{
		SceneRegionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SceneRegionTable>(this.GetResid(), string.Empty, string.Empty);
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

	// Token: 0x060175DA RID: 95706 RVA: 0x0072E215 File Offset: 0x0072C615
	public VInt3 GetLogicPosition()
	{
		return this.mPos;
	}

	// Token: 0x060175DB RID: 95707 RVA: 0x0072E21D File Offset: 0x0072C61D
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x060175DC RID: 95708 RVA: 0x0072E220 File Offset: 0x0072C620
	public float GetRadius()
	{
		return 1f;
	}

	// Token: 0x060175DD RID: 95709 RVA: 0x0072E227 File Offset: 0x0072C627
	public Vector2 GetRect()
	{
		return new Vector2(1f, 1f);
	}

	// Token: 0x060175DE RID: 95710 RVA: 0x0072E238 File Offset: 0x0072C638
	public DRegionInfo.RegionType GetRegiontype()
	{
		return DRegionInfo.RegionType.Circle;
	}

	// Token: 0x060175DF RID: 95711 RVA: 0x0072E23B File Offset: 0x0072C63B
	public Quaternion GetRotation()
	{
		return new Quaternion(1f, 1f, 1f, 1f);
	}

	// Token: 0x060175E0 RID: 95712 RVA: 0x0072E256 File Offset: 0x0072C656
	public void SetRadius(float r)
	{
	}

	// Token: 0x060175E1 RID: 95713 RVA: 0x0072E258 File Offset: 0x0072C658
	public void SetRegiontype(DRegionInfo.RegionType type)
	{
	}

	// Token: 0x060175E2 RID: 95714 RVA: 0x0072E25A File Offset: 0x0072C65A
	public int GetGlobalid()
	{
		return this.mGlobalId;
	}

	// Token: 0x060175E3 RID: 95715 RVA: 0x0072E262 File Offset: 0x0072C662
	public int GetResid()
	{
		return this.mResId;
	}

	// Token: 0x060175E4 RID: 95716 RVA: 0x0072E26A File Offset: 0x0072C66A
	public string GetName()
	{
		return string.Empty;
	}

	// Token: 0x060175E5 RID: 95717 RVA: 0x0072E271 File Offset: 0x0072C671
	public string GetPath()
	{
		return string.Empty;
	}

	// Token: 0x060175E6 RID: 95718 RVA: 0x0072E278 File Offset: 0x0072C678
	public string GetDescription()
	{
		return string.Empty;
	}

	// Token: 0x060175E7 RID: 95719 RVA: 0x0072E27F File Offset: 0x0072C67F
	public new DEntityType GetType()
	{
		return DEntityType.REGION;
	}

	// Token: 0x060175E8 RID: 95720 RVA: 0x0072E282 File Offset: 0x0072C682
	public string GetTypename()
	{
		return string.Empty;
	}

	// Token: 0x060175E9 RID: 95721 RVA: 0x0072E289 File Offset: 0x0072C689
	public Vector3 GetPosition()
	{
		return this.mPos.vector3;
	}

	// Token: 0x060175EA RID: 95722 RVA: 0x0072E296 File Offset: 0x0072C696
	public float GetScale()
	{
		return 1f;
	}

	// Token: 0x060175EB RID: 95723 RVA: 0x0072E29D File Offset: 0x0072C69D
	public Color GetColor()
	{
		return Color.white;
	}

	// Token: 0x04010C7B RID: 68731
	private int mResId;

	// Token: 0x04010C7C RID: 68732
	private VInt3 mPos;

	// Token: 0x04010C7D RID: 68733
	private int mGlobalId;
}
