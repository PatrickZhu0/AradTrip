using System;

// Token: 0x02004BBA RID: 19386
[AttributeUsage(AttributeTargets.Class)]
public class DSFFrameEventTypeAttribute : Attribute
{
	// Token: 0x0601C767 RID: 116583 RVA: 0x0089F4B0 File Offset: 0x0089D8B0
	public DSFFrameEventTypeAttribute(string name)
	{
		this._name = name;
	}

	// Token: 0x170027DF RID: 10207
	// (get) Token: 0x0601C768 RID: 116584 RVA: 0x0089F4BF File Offset: 0x0089D8BF
	public string name
	{
		get
		{
			return this._name;
		}
	}

	// Token: 0x04013A2F RID: 80431
	protected string _name;
}
