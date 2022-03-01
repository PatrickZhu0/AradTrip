using System;

// Token: 0x02001296 RID: 4758
[Serializable]
public class SourceInfo : IComparable<SourceInfo>, ISourceInfo
{
	// Token: 0x0600B738 RID: 46904 RVA: 0x0029CE14 File Offset: 0x0029B214
	public int CompareTo(SourceInfo other)
	{
		if (this.type != other.type)
		{
			return this.type - other.type;
		}
		if (this.data != other.data)
		{
			return this.data - other.data;
		}
		if (this.openFunctionID != other.openFunctionID)
		{
			return this.openFunctionID - other.openFunctionID;
		}
		int num = string.Compare(this.linkParm, other.linkParm);
		if (num != 0)
		{
			return num;
		}
		int num2 = string.Compare(this.name, other.name);
		if (num2 != 0)
		{
			return num2;
		}
		if (this.linkParmIndex != other.linkParmIndex)
		{
			return this.linkParmIndex - other.linkParmIndex;
		}
		return this.nameIndex - other.nameIndex;
	}

	// Token: 0x0600B739 RID: 46905 RVA: 0x0029CEDE File Offset: 0x0029B2DE
	public int GetData()
	{
		return this.data;
	}

	// Token: 0x0600B73A RID: 46906 RVA: 0x0029CEE6 File Offset: 0x0029B2E6
	public int GetOpenFunctionID()
	{
		return this.openFunctionID;
	}

	// Token: 0x0600B73B RID: 46907 RVA: 0x0029CEEE File Offset: 0x0029B2EE
	public int GetNameIndex()
	{
		return this.nameIndex;
	}

	// Token: 0x0600B73C RID: 46908 RVA: 0x0029CEF6 File Offset: 0x0029B2F6
	public int GetParmIndex()
	{
		return this.linkParmIndex;
	}

	// Token: 0x0600B73D RID: 46909 RVA: 0x0029CEFE File Offset: 0x0029B2FE
	public override string ToString()
	{
		return string.Format("{0} {1}", this.type, this.name);
	}

	// Token: 0x0600B73E RID: 46910 RVA: 0x0029CF1B File Offset: 0x0029B31B
	eItemSourceType ISourceInfo.GetType()
	{
		return this.type;
	}

	// Token: 0x0400675B RID: 26459
	public eItemSourceType type;

	// Token: 0x0400675C RID: 26460
	public int data = -1;

	// Token: 0x0400675D RID: 26461
	public int openFunctionID = -1;

	// Token: 0x0400675E RID: 26462
	[NonSerialized]
	public string linkParm;

	// Token: 0x0400675F RID: 26463
	[NonSerialized]
	public string name;

	// Token: 0x04006760 RID: 26464
	public int linkParmIndex;

	// Token: 0x04006761 RID: 26465
	public int nameIndex;
}
