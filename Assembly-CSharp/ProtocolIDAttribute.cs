using System;

// Token: 0x020006B2 RID: 1714
[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
internal sealed class ProtocolIDAttribute : Attribute
{
	// Token: 0x0600584C RID: 22604 RVA: 0x0010CAE5 File Offset: 0x0010AEE5
	public ProtocolIDAttribute(string IDString)
	{
		this._IDString = IDString;
	}

	// Token: 0x17001817 RID: 6167
	// (get) Token: 0x0600584D RID: 22605 RVA: 0x0010CAF4 File Offset: 0x0010AEF4
	public string IDString
	{
		get
		{
			return this._IDString;
		}
	}

	// Token: 0x04002323 RID: 8995
	private readonly string _IDString;
}
