using System;
using System.Collections.Generic;

// Token: 0x02000117 RID: 279
public abstract class ListViewBase
{
	// Token: 0x06000627 RID: 1575 RVA: 0x000256EB File Offset: 0x00023AEB
	public void Clear()
	{
		this.Context.Clear();
	}

	// Token: 0x06000628 RID: 1576 RVA: 0x000256F8 File Offset: 0x00023AF8
	public void RemoveAt(int index)
	{
		this.Context.RemoveAt(index);
	}

	// Token: 0x06000629 RID: 1577 RVA: 0x00025706 File Offset: 0x00023B06
	public void RemoveRange(int index, int count)
	{
		this.Context.RemoveRange(index, count);
	}

	// Token: 0x0600062A RID: 1578 RVA: 0x00025715 File Offset: 0x00023B15
	public void Reverse()
	{
		this.Context.Reverse();
	}

	// Token: 0x0600062B RID: 1579 RVA: 0x00025722 File Offset: 0x00023B22
	public void Sort()
	{
		this.Context.Sort();
	}

	// Token: 0x1700006E RID: 110
	// (get) Token: 0x0600062C RID: 1580 RVA: 0x0002572F File Offset: 0x00023B2F
	public int Count
	{
		get
		{
			return this.Context.Count;
		}
	}

	// Token: 0x04000512 RID: 1298
	protected List<object> Context;
}
