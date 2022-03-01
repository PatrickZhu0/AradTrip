using System;

// Token: 0x020041D6 RID: 16854
public struct DelayCallUnitHandle
{
	// Token: 0x06017421 RID: 95265 RVA: 0x0072710C File Offset: 0x0072550C
	public bool IsValid()
	{
		return this.unit != null && this.unit.id == this.id;
	}

	// Token: 0x06017422 RID: 95266 RVA: 0x00727134 File Offset: 0x00725534
	public void SetRemove(bool isRemoved)
	{
		if (!this.IsValid())
		{
			return;
		}
		this.unit.SetRemove(isRemoved);
	}

	// Token: 0x04010BC1 RID: 68545
	public DelayCallUnit unit;

	// Token: 0x04010BC2 RID: 68546
	public uint id;
}
