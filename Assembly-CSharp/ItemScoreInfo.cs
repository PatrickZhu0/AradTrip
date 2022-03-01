using System;

// Token: 0x02001298 RID: 4760
[Serializable]
public class ItemScoreInfo : IComparable<ItemScoreInfo>
{
	// Token: 0x0600B742 RID: 46914 RVA: 0x0029CF4E File Offset: 0x0029B34E
	public int CompareTo(ItemScoreInfo other)
	{
		return this.itemID - other.itemID;
	}

	// Token: 0x04006764 RID: 26468
	public int itemID;

	// Token: 0x04006765 RID: 26469
	public int score;
}
