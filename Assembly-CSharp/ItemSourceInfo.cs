using System;

// Token: 0x02001297 RID: 4759
[Serializable]
public class ItemSourceInfo : IComparable<ItemSourceInfo>
{
	// Token: 0x0600B740 RID: 46912 RVA: 0x0029CF37 File Offset: 0x0029B337
	public int CompareTo(ItemSourceInfo other)
	{
		return this.itemID - other.itemID;
	}

	// Token: 0x04006762 RID: 26466
	public int itemID;

	// Token: 0x04006763 RID: 26467
	public SourceInfo[] sources = new SourceInfo[0];
}
