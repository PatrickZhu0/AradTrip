using System;

// Token: 0x02000DE8 RID: 3560
public class MessageHandleAttribute : Attribute
{
	// Token: 0x06008F5A RID: 36698 RVA: 0x001A89E0 File Offset: 0x001A6DE0
	public MessageHandleAttribute(uint id, bool bNeedCache = false, int order = 0)
	{
		this.id = id;
		this.bNeedCache = bNeedCache;
		this.order = order;
	}

	// Token: 0x04004729 RID: 18217
	public uint id;

	// Token: 0x0400472A RID: 18218
	public bool bNeedCache;

	// Token: 0x0400472B RID: 18219
	public int order;
}
