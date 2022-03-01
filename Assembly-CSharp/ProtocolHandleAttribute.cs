using System;

// Token: 0x02000DE9 RID: 3561
public class ProtocolHandleAttribute : Attribute
{
	// Token: 0x06008F5B RID: 36699 RVA: 0x001A89FD File Offset: 0x001A6DFD
	public ProtocolHandleAttribute(Type type)
	{
		this.binderType = type;
	}

	// Token: 0x170018DC RID: 6364
	// (get) Token: 0x06008F5C RID: 36700 RVA: 0x001A8A0C File Offset: 0x001A6E0C
	// (set) Token: 0x06008F5D RID: 36701 RVA: 0x001A8A14 File Offset: 0x001A6E14
	public Type binderType { get; private set; }

	// Token: 0x06008F5E RID: 36702 RVA: 0x001A8A1D File Offset: 0x001A6E1D
	public object GetBinder()
	{
		return Activator.CreateInstance(this.binderType);
	}
}
