using System;

// Token: 0x020041C4 RID: 16836
public struct BeTimeLineHandler
{
	// Token: 0x06017387 RID: 95111 RVA: 0x0072364C File Offset: 0x00721A4C
	public BeTimeLineHandler(int frames, BeTimeLineHandler.Del func)
	{
		this.iFrames = frames;
		this.onFrame = func;
	}

	// Token: 0x04010B7E RID: 68478
	public int iFrames;

	// Token: 0x04010B7F RID: 68479
	public BeTimeLineHandler.Del onFrame;

	// Token: 0x020041C5 RID: 16837
	// (Invoke) Token: 0x06017389 RID: 95113
	public delegate void Del(BeStates state);
}
