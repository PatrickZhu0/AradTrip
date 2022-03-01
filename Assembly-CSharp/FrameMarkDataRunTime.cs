using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020046BD RID: 18109
public class FrameMarkDataRunTime
{
	// Token: 0x06019A86 RID: 105094 RVA: 0x00814C38 File Offset: 0x00813038
	public void Recycle()
	{
		this.curFrame = 0U;
		this.sequence = 0U;
		foreach (KeyValuePair<uint, MarkDataRunTime> keyValuePair in this.m_FrameDatas)
		{
			MarkDataRunTimePool.Release(keyValuePair.Value);
		}
		this.m_FrameDatas.Clear();
	}

	// Token: 0x0401248D RID: 74893
	public uint curFrame;

	// Token: 0x0401248E RID: 74894
	public uint sequence;

	// Token: 0x0401248F RID: 74895
	public Dictionary<uint, MarkDataRunTime> m_FrameDatas = new Dictionary<uint, MarkDataRunTime>();
}
