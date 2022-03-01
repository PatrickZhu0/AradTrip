using System;

// Token: 0x020041C6 RID: 16838
public struct BeEventsHandler
{
	// Token: 0x0601738C RID: 95116 RVA: 0x0072365C File Offset: 0x00721A5C
	public BeEventsHandler(int events, BeEventsHandler.Del func)
	{
		this.iEvents = events;
		this.onEvent = func;
	}

	// Token: 0x04010B80 RID: 68480
	public int iEvents;

	// Token: 0x04010B81 RID: 68481
	public BeEventsHandler.Del onEvent;

	// Token: 0x020041C7 RID: 16839
	// (Invoke) Token: 0x0601738E RID: 95118
	public delegate void Del(BeStates state);
}
