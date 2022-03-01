using System;
using Protocol;

// Token: 0x020046BA RID: 18106
public class RecordFrameData
{
	// Token: 0x06019A77 RID: 105079 RVA: 0x00813EFC File Offset: 0x008122FC
	public RecordFrameData(Frame[] frames, int tick)
	{
		this.serverFrames = frames;
		this.tickTime = tick;
	}

	// Token: 0x04012479 RID: 74873
	public Frame[] serverFrames;

	// Token: 0x0401247A RID: 74874
	public int tickTime;
}
