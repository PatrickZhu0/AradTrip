using System;
using ProtoTable;
using UnityEngine;

// Token: 0x02004B60 RID: 19296
[Serializable]
public class DEntityInfo : ISceneEntityInfoData
{
	// Token: 0x0601C605 RID: 116229 RVA: 0x0089D790 File Offset: 0x0089BB90
	public virtual void Duplicate(DEntityInfo info)
	{
		this.resid = info.resid;
		this.name = info.name;
		this.path = info.path;
		this.description = info.description;
		this.type = info.type;
		this.typename = info.typename;
		this.position = info.position;
		this.scale = info.scale;
		this.color = info.color;
	}

	// Token: 0x0601C606 RID: 116230 RVA: 0x0089D80C File Offset: 0x0089BC0C
	public virtual string GetModelPathByResID()
	{
		ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(this.resid, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return string.Empty;
		}
		return tableItem.ModelPath;
	}

	// Token: 0x0601C607 RID: 116231 RVA: 0x0089D846 File Offset: 0x0089BC46
	public int GetGlobalid()
	{
		return this.globalid;
	}

	// Token: 0x0601C608 RID: 116232 RVA: 0x0089D84E File Offset: 0x0089BC4E
	public int GetResid()
	{
		return this.resid;
	}

	// Token: 0x0601C609 RID: 116233 RVA: 0x0089D856 File Offset: 0x0089BC56
	public string GetName()
	{
		return this.name;
	}

	// Token: 0x0601C60A RID: 116234 RVA: 0x0089D85E File Offset: 0x0089BC5E
	public string GetPath()
	{
		return this.path;
	}

	// Token: 0x0601C60B RID: 116235 RVA: 0x0089D866 File Offset: 0x0089BC66
	public string GetDescription()
	{
		return this.description;
	}

	// Token: 0x0601C60C RID: 116236 RVA: 0x0089D86E File Offset: 0x0089BC6E
	DEntityType ISceneEntityInfoData.GetType()
	{
		return this.type;
	}

	// Token: 0x0601C60D RID: 116237 RVA: 0x0089D876 File Offset: 0x0089BC76
	public string GetTypename()
	{
		return this.typename;
	}

	// Token: 0x0601C60E RID: 116238 RVA: 0x0089D87E File Offset: 0x0089BC7E
	public Vector3 GetPosition()
	{
		return this.position;
	}

	// Token: 0x0601C60F RID: 116239 RVA: 0x0089D886 File Offset: 0x0089BC86
	public float GetScale()
	{
		return this.scale;
	}

	// Token: 0x0601C610 RID: 116240 RVA: 0x0089D88E File Offset: 0x0089BC8E
	public Color GetColor()
	{
		return this.color;
	}

	// Token: 0x04013839 RID: 79929
	public int globalid;

	// Token: 0x0401383A RID: 79930
	public int resid;

	// Token: 0x0401383B RID: 79931
	public string name;

	// Token: 0x0401383C RID: 79932
	public string path;

	// Token: 0x0401383D RID: 79933
	public string description;

	// Token: 0x0401383E RID: 79934
	public DEntityType type;

	// Token: 0x0401383F RID: 79935
	public string typename;

	// Token: 0x04013840 RID: 79936
	public Vector3 position;

	// Token: 0x04013841 RID: 79937
	public float scale = 1f;

	// Token: 0x04013842 RID: 79938
	public Color color = Color.white;
}
