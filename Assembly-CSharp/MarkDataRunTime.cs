using System;
using System.Collections.Generic;

// Token: 0x020046BC RID: 18108
public class MarkDataRunTime
{
	// Token: 0x06019A84 RID: 105092 RVA: 0x00814C10 File Offset: 0x00813010
	public void Recycle()
	{
		this.curCallNum = 0U;
		this.m_CallData.Clear();
	}

	// Token: 0x0401248B RID: 74891
	public uint curCallNum;

	// Token: 0x0401248C RID: 74892
	public List<NodeData> m_CallData = new List<NodeData>();
}
